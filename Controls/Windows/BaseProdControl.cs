// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Utility;

[assembly: InternalsVisibleTo("ProdUITests")]

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Provides a base for all ProdUI elements
    /// </summary>
    public class BaseProdControl
    {
        internal bool EventVerified;

        internal IntPtr NativeWindowHandle;
        internal ProdWindow ParentWindow;
        internal List<AutomationProperty> SupportedProperties;
        internal AutomationElement UIAElement;

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref = "BaseProdControl" /> class.
        /// </summary>
        /// <param name = "prodWindow">The prodWindow.</param>
        /// <param name = "automationId">The automation id.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public BaseProdControl(ProdWindow prodWindow, string automationId)
        {
            if (prodWindow == null)
            {
                throw new ProdOperationException("ProdWindow cannot be null");
            }

            try
            {
                /* get the element using automationID*/
                Condition cond = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
                UIAElement = prodWindow.UIAElement.FindFirst(TreeScope.Descendants, cond);

                /* then we'll try the name...who knows? */
                if (UIAElement == null)
                {
                    /* try the name */
                    Condition condName = new PropertyCondition(AutomationElement.NameProperty, automationId, PropertyConditionFlags.IgnoreCase);
                    UIAElement = prodWindow.UIAElement.FindFirst(TreeScope.Descendants, condName);
                }

                ParentWindow = prodWindow;
                //SessionLoggers = ParentWindow.AttachedSession.logController;
                GetSupportedProperties();
                NativeWindowHandle = (IntPtr) UIAElement.Current.NativeWindowHandle;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref = "BaseProdControl" /> class.
        /// </summary>
        /// <param name = "prodWindow">The prod window.</param>
        /// <param name = "treePosition">The tree position.</param>
        public BaseProdControl(ProdWindow prodWindow, int treePosition)
        {
            if (prodWindow == null)
            {
                throw new ProdOperationException("ProdWindow cannot be null");
            }

            try
            {
                ControlTree tree = new ControlTree((IntPtr) prodWindow.UIAElement.Current.NativeWindowHandle);
                UIAElement = tree.FindElement(treePosition);
                ParentWindow = prodWindow;
                //SessionLoggers = ParentWindow.AttachedSession.logController;
                GetSupportedProperties();
                NativeWindowHandle = (IntPtr) UIAElement.Current.NativeWindowHandle;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the ProdUI.Controls class using the supplied handle
        /// </summary>
        /// <param name = "prodWindow">The prod window.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        internal BaseProdControl(ProdWindow prodWindow, IntPtr controlHandle)
        {
            try
            {
                UIAElement = AutomationElement.FromHandle(controlHandle);
                ParentWindow = prodWindow;
                //SessionLoggers = ParentWindow.AttachedSession.logController;
                GetSupportedProperties();
                NativeWindowHandle = (IntPtr) UIAElement.Current.NativeWindowHandle;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        //unused vars
        //internal LogController SessionLoggers;
        //protected List<object> VerboseInformation;
        //protected string LogText;

        /// <summary>
        ///     specifies whether the user interface (UI) item referenced by the AutomationElement is enabled
        /// </summary>
        public bool IsEnabled
        {
            get { return (bool) UIAElement.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty); }
        }

        private void GetSupportedProperties()
        {
            SupportedProperties = new List<AutomationProperty>(UIAElement.GetSupportedProperties());
        }

        public void SetFocus()
        {
            try
            {
                UIAElement.SetFocus();
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err);
            }
        }

        public void WaitForControlEnabled(int waitSeconds = -1)
        {
            int ctr = 0;
            int limit = waitSeconds * 1000;

            while (ctr <= limit)
            {
                if ((bool) UIAElement.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty))
                {
                    return;
                }
                ctr += 1000;
            }

            throw new ProdOperationException("Timer expired");
        }

        internal object GetUIAPropertyValue(AutomationProperty property)
        {
            if (SupportedProperties.Contains(property)) return 0;

            return UIAElement.GetCurrentPropertyValue(property);
        }

        /////
        ///// <summary>
        /////     Creates and sends the proper LogMessage.
        ///// </summary>
        //protected void LogMessage()
        //{
        //    LogMessage message;
        //    if (VerboseInformation.Count == 0)
        //    {
        //        message = new LogMessage(LogText);
        //    }
        //    else
        //    {
        //        VerboseInformation = new List<object>();
        //        message = new LogMessage(LogText, VerboseInformation);
        //    }

        //    LogController.ReceiveLogMessage(message);
        //}

        /////// <summary>
        /////// Registers an action event event.
        /////// </summary>
        /////// <param name="eventType">Type of the event.</param>
        //internal void RegisterEvent(AutomationEvent eventType)
        //{
        //    // AutomationEventVerifier.Register(new EventRegistrationMessage(this, eventType));
        //}

        /////// <summary>
        /////// Registers a property change event.
        /////// </summary>
        /////// <param name="property">The property to monitor.</param>
        //internal void RegisterEvent(AutomationProperty property)
        //{
        //    /* create message to pass */
        //    //AutomationEventVerifier.Register(new EventRegistrationMessage(this, property));
        //}

        /// <summary>
        ///     Receives the event notification message.
        /// </summary>
        /// <param name = "eventTriggered">if set to <c>true</c> event triggered.</param>
        internal void ReceiveEventNotification(bool eventTriggered)
        {
            EventVerified = eventTriggered;
        }
    }
}