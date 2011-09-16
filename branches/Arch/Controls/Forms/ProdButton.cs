/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.AutomationPatterns;
using ProdUI.Controls.Native;
using ProdUI.Exceptions;
using ProdUI.Logging;

/* Notes
 * Supported Patterns: 
 * IInvokeProvider 
 * (IToggleProvider) -> ToggleButton
 */

namespace ProdUI.Controls
{
    /// <summary>
    ///   Methods to work with Button controls using the UI Automation framework
    /// </summary>
    public sealed class ProdButton : BaseProdControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        /// Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdButton(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdButton(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        public ProdButton(ProdWindow prodWindow, IntPtr controlHandle) : base(prodWindow, controlHandle)
        {
        }

        #endregion

        public string Text
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Performs a "Click" on the current ProdButton
        /// </summary>
        /// <example>
        ///   <code>
        /// /* Assuming "Calculator" is running, this will press the "7" button */
        /// ProdSession session = new ProdSession("test.ses");
        /// ProdWindow window = new ProdWindow("Calculator", session.Loggers);
        /// ProdButton ctrl = new ProdButton(window,"7");
        /// ctrl.Click();
        /// or
        /// Statically:
        /// ProdSession session = new ProdSession("test.ses");
        /// ProdWindow window = new ProdWindow("Calculator", session.Loggers);
        /// Prod.ButtonClick(window, "7");
        ///   </code>
        ///   </example>
        ///   
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Click()
        {
            LogText = "Click Verified";

            try
            {
                /* subscribe to any invokes that happen to this control */
                RegisterEvent(InvokePattern.InvokedEvent);
                int ret = InvokePatternHelper.Invoke(UIAElement);
                if (ret == -1 && Handle != IntPtr.Zero)
                {
                    ProdButtonNative.Click(Handle);
                }
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }
    }
}