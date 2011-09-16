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
namespace ProdUI.Controls
{


    /// <summary>
    ///   Provides a base for all ProdUI elements
    /// </summary>
    public class BaseProdControl
    {

        internal ProdWindow ParentWindow;
        internal AutomationElement UIAElement;
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
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        #endregion

        public void GetProperty()
        {
            throw new System.NotImplementedException();
        }

        public void SetFocus()
        {
            throw new System.NotImplementedException();
        }

        public void WaitForControlEnabled()
        {
            throw new System.NotImplementedException();
        }

        public void WaitForControlExist()
        {
            throw new System.NotImplementedException();
        }

        public void SetProperty()
        {
            throw new System.NotImplementedException();
        }

        internal void RegisterEvent(AutomationEvent eventType)
        {
            EventRegistration eventRegistration = new EventRegistration(UIAElement, eventType);
        }

        internal void RegisterEvent(AutomationProperty property)
        {
            EventRegistration eventRegistration = new EventRegistration(UIAElement, property);
        }

        /// <summary>
        /// Creates the proper LogMessage.
        /// </summary>
        private void CreateMessage()
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
        }
    }
}