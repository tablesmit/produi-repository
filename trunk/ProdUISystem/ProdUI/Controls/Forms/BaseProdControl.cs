/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Utility;

[assembly: InternalsVisibleTo("ProdUITests")]
namespace ProdUI.Controls
{
    delegate void ProdEventHandler();

    /// <summary>
    ///   Provides a base for all ProdUI elements
    /// </summary>
    public class BaseProdControl
    {
        private AutomationEventHandler _eventHandler;
        private AutomationPropertyChangedEventHandler _propertyChangeHandler;
        private AutomationEvent _patternEventType;
        private LogMessage _currentMessage;

        internal ProdWindow ParentWindow;
        internal AutomationElement ThisElement;
        internal string Logmessage = string.Empty;
        internal List<object> VerboseInformation;

        /// <summary>
        /// This variable is here pretty much for unit testing.
        /// it is set upon event confirm and cleared after handler has been removed
        /// </summary>
        internal bool eventTriggered;



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseProdControl"/> class.
        /// </summary>
        /// <param name="prodWindow">The prodWindow.</param>
        /// <param name="automationId">The automation id.</param>
        /// <remarks>
        /// Will attempt to match AutomationId, then Name
        /// </remarks>
        public BaseProdControl(ProdWindow prodWindow, string automationId)
        {
            if (prodWindow == null)
            {
                throw new ProdOperationException("ProdWindow cannot be null");
            }
            Condition cond = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            ThisElement = prodWindow.Window.FindFirst(TreeScope.Descendants, cond);

            /* then we'll try the name...who knows? */
            if (ThisElement == null)
            {
                /* try the name */
                Condition condName = new PropertyCondition(AutomationElement.NameProperty, automationId, PropertyConditionFlags.IgnoreCase);
                ThisElement = prodWindow.Window.FindFirst(TreeScope.Descendants, condName);
            }

            ParentWindow = prodWindow;
            VerboseInformation = new List<object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseProdControl"/> class.
        /// </summary>
        /// <param name="prodWindow">The prod window.</param>
        /// <param name="treePosition">The tree position.</param>
        public BaseProdControl(ProdWindow prodWindow, int treePosition)
        {
            if (prodWindow == null)
            {
                throw new ProdOperationException("ProdWindow cannot be null");
            }

            try
            {
                ControlTree tree = new ControlTree((IntPtr)prodWindow.Window.Current.NativeWindowHandle);
                ThisElement = tree.FindElement(treePosition);
                ParentWindow = prodWindow;
                VerboseInformation = new List<object>();
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ProdUI.Controls class using the supplied handle
        /// </summary>
        /// <param name="prodWindow">The prod window.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        internal BaseProdControl(ProdWindow prodWindow, IntPtr controlHandle)
        {
            try
            {
                ThisElement = AutomationElement.FromHandle(controlHandle);
                ParentWindow = prodWindow;
                VerboseInformation = new List<object>();
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the window handle for the component
        /// </summary>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public IntPtr Handle
        {
            get
            {
                try
                {
                    return (IntPtr)ThisElement.Current.NativeWindowHandle;
                }
                catch (InvalidOperationException)
                {
                    return IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Gets the name of the control at the time it was initialized
        /// </summary>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        public string Name
        {
            get
            {
                try
                {
                    return ThisElement.Current.Name;
                }
                catch (InvalidOperationException)
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled
        {
            get
            {
                return ThisElement.Current.IsEnabled;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Registers a method that handles UI Automation events
        /// </summary>
        /// <param name="eventType">The specific event type to monitor</param>
        public void SubscribeToEvent(AutomationEvent eventType)
        {
            eventTriggered = false; 
            CreateMessage();

            if (eventType.Id == InvokePattern.InvokedEvent.Id)
            {
                _eventHandler = new AutomationEventHandler(OnAutomationEvent);
                Automation.AddAutomationEventHandler(eventType, ThisElement, TreeScope.Element, _eventHandler);
                _patternEventType = eventType;
                return;
            }

            SubscribeToChildNotification(eventType);
        }

        /// <summary>
        /// Registers a method that will handle property-changed events
        /// </summary>
        /// <param name="property">The automation property to monitor for a state change</param>
        public void SubscribeToEvent(AutomationProperty property)
        {
            eventTriggered = false; 
            CreateMessage();
            _propertyChangeHandler = new AutomationPropertyChangedEventHandler(OnPropertyChange);
            Automation.AddAutomationPropertyChangedEventHandler(ThisElement, TreeScope.Element, _propertyChangeHandler, property);
        }

        /// <summary>
        /// Registers a method that handles UI Automation events inside containers
        /// </summary>
        /// <param name="eventType">The specific event type to monitor</param>
        public void SubscribeToChildNotification(AutomationEvent eventType)
        {
            eventTriggered = false; 
            _patternEventType = eventType;
            _eventHandler = new AutomationEventHandler(OnAutomationEvent);
            Automation.AddAutomationEventHandler(_patternEventType, ThisElement, TreeScope.Descendants, _eventHandler);

        }

        /// <summary>
        /// Automation Event handler
        /// </summary>
        /// <param name="src">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Automation.AutomationEventArgs"/> instance containing the event data.</param>
        private void OnAutomationEvent(object src, AutomationEventArgs e)
        {
            if (src == null)
            {
                return;
            }

            if (e.EventId != _patternEventType)
            {
                return;
            }

            if (_eventHandler == null)
            {
                return;
            }

            eventTriggered = true;
            LogEntry();

            RemoveHandler();
        }

        /// <summary>
        /// Handler for property change events
        /// </summary>
        /// <param name="src">The source whose properties changed.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPropertyChange(object src, AutomationPropertyChangedEventArgs e)
        {
            if (src == null)
            {
                return;
            }

            if (_propertyChangeHandler == null)
            {
                return;
            }
            eventTriggered = true;
            LogEntry();
            RemovePropertyChangeHandler();
        }

        /// <summary>Removes the handler.</summary>
        private void RemoveHandler()
        {
            Automation.RemoveAutomationEventHandler(_patternEventType, ThisElement, _eventHandler);
            _eventHandler = null;
        }

        private void RemovePropertyChangeHandler()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(ThisElement, _propertyChangeHandler);
            _propertyChangeHandler = null;
        }

        #endregion


        /// <summary>
        /// Checks the pattern support for a given control.
        /// </summary>
        /// <param name="pattern">The automation pattern to check for</param>
        /// <param name="control">The target control.</param>
        /// <returns>
        ///   <c>true</c> if control supports the pattern, <c>false</c> otherwise
        /// </returns>
        internal static bool CheckPatternSupport(AutomationPattern pattern, AutomationElement control)
        {
            try
            {
                object pat;
                if (control.TryGetCurrentPattern(pattern, out pat))
                {
                    return true;
                }
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Central location to send any log messages up the log pipe
        /// </summary>
        internal void LogEntry()
        {
            
            if (_currentMessage == null)
            {
                CreateMessage();
            }
             
            ProdLogger.Log(_currentMessage, ParentWindow.AttachedLoggers);
        }


        /// <summary>
        /// Creates the proper LogMessage.
        /// </summary>
        private void CreateMessage()
        {
            if (VerboseInformation.Count == 0)
            {
                _currentMessage = new LogMessage(Logmessage);
            }
            else
            {
                _currentMessage = new LogMessage(Logmessage, VerboseInformation);
            }
        }
    }
}