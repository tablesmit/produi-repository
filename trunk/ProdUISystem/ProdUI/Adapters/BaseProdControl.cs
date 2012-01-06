// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.Generic;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Utility;

namespace ProdUI.Adapters
{
    /// <summary>
    ///     Provides a base for all ProdUI elements
    /// </summary>
    public class BaseProdControl
    {
        internal bool EventVerified;

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
                GetSupportedProperties();
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
                ControlTree tree = new ControlTree((IntPtr)prodWindow.UIAElement.Current.NativeWindowHandle);
                UIAElement = tree.FindElement(treePosition);
                GetSupportedProperties();
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
                GetSupportedProperties();
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion Constructors


        /// <summary>
        ///     specifies whether the user interface (UI) item referenced by the AutomationElement is enabled
        /// </summary>
        public bool IsEnabled
        {
            get { return (bool)UIAElement.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty); }
        }

        private void GetSupportedProperties()
        {
            SupportedProperties = new List<AutomationProperty>(UIAElement.GetSupportedProperties());
        }

        /// <summary>
        /// Sets the focus to this control.
        /// </summary>
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

        /// <summary>
        /// Waits for the control to enter an enabled state.
        /// </summary>
        /// <param name="waitSeconds">The wait in seconds.</param>
        public void WaitForControlEnabled(double waitSeconds)
        {
            int ctr = 0;

            double limit = waitSeconds * 1000;

            if (limit > double.MaxValue)
                throw new ProdOperationException("input must be less than double.MaxValue");

            while (ctr <= limit)
            {
                if ((bool)UIAElement.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty))
                {
                    return;
                }
                ctr += 1000;
            }

            throw new ProdOperationException("Timer expired");
        }

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