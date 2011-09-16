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
using ProdUI.Verification;

[assembly: InternalsVisibleTo("ProdUITests")]
namespace ProdUI.Controls.Windows
{

    /// <summary>
    ///   Provides a base for all ProdUI elements
    /// </summary>
    public class BaseProdControl
    {
        internal bool EventVerified;
        internal ProdWindow ParentWindow;
        internal AutomationElement UIAElement;
        internal List<AutomationProperty> SupportedProperties;
        protected List<object> VerboseInformation;
        protected string LogText;

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
        /// Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public BaseProdControl(ProdWindow prodWindow, string automationId)
        {
            if (prodWindow == null)
            {
                throw new ProdOperationException("ProdWindow cannot be null");
            }
            Condition cond = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            UIAElement = prodWindow.Window.FindFirst(TreeScope.Descendants, cond);

            /* then we'll try the name...who knows? */
            if (UIAElement == null)
            {
                /* try the name */
                Condition condName = new PropertyCondition(AutomationElement.NameProperty, automationId, PropertyConditionFlags.IgnoreCase);
                UIAElement = prodWindow.Window.FindFirst(TreeScope.Descendants, condName);
            }

            ParentWindow = prodWindow;

            VerboseInformation = new List<object>();

            AutomationProperty[] supported = UIAElement.GetSupportedProperties();
            SupportedProperties = new List<AutomationProperty>(supported);

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
                UIAElement = tree.FindElement(treePosition);
                ParentWindow = prodWindow;
                VerboseInformation = new List<object>();
                AutomationProperty[] supported = UIAElement.GetSupportedProperties();
                SupportedProperties = new List<AutomationProperty>(supported);
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
                UIAElement = AutomationElement.FromHandle(controlHandle);
                ParentWindow = prodWindow;
                VerboseInformation = new List<object>();
                AutomationProperty[] supported = UIAElement.GetSupportedProperties();
                SupportedProperties = new List<AutomationProperty>(supported);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        /// <summary>
        /// specifies whether the user interface (UI) item referenced by the AutomationElement is enabled
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return (bool)UIAElement.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty);
            }
        }

        public void SetFocus()
        {
            if (UIAElement != null)
                UIAElement.SetFocus();
        }

        public void WaitForControlEnabled(int waitSeconds = -1)
        {
            int ctr = 0;
            int limit = waitSeconds * 1000;

            while (ctr <= limit)
            {
                if ((bool)UIAElement.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty)) { return; }
                ctr += 1000;
            }

            throw new ProdOperationException("Timer expired");
        }

        internal object GetUIAPropertyValue(AutomationProperty property)
        {
            if (SupportedProperties.Contains(property)) return 0;

            return UIAElement.GetCurrentPropertyValue(property);

        }

        #region Events

        /// <summary>
        /// Registers an action event event.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        internal void RegisterEvent(AutomationEvent eventType)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(this, eventType));
        }

        /// <summary>
        /// Registers a property change event.
        /// </summary>
        /// <param name="property">The property to monitor.</param>
        internal void RegisterEvent(AutomationProperty property)
        {
            /* create message to pass */
            AutomationEventVerifier.Register(new EventRegistrationMessage(this, property));
        }

        /// <summary>
        /// Receives the event notification message.
        /// </summary>
        /// <param name="eventTriggered">if set to <c>true</c> event triggered.</param>
        internal void ReceiveEventNotification(bool eventTriggered)
        {
            EventVerified = eventTriggered;
        }

        #endregion


        /// <summary>
        /// Creates the proper LogMessage.
        /// </summary>
        protected void LogMessage()
        {
            LogMessage message;
            if (VerboseInformation.Count == 0)
            {
                message = new LogMessage(LogText);
            }
            else
            {
                message = new LogMessage(LogText, VerboseInformation);
            }

            ProdLogger.Log(message, ParentWindow.AttachedLoggers);
        }


    }
}