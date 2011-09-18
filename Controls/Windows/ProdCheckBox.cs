// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;

/* Notes
 * Supported Patterns: 
 * IToggleProvider
 */

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     Methods to work with CheckBox controls using the UI Automation framework
    /// </summary>
    public sealed class ProdCheckBox : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdCheckBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdCheckBox(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdCheckBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdCheckBox(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdCheckBox class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdCheckBox(ProdWindow prodWindow, IntPtr controlHandle) : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        ///     Gets the currentToggleState
        /// </summary>
        /// <returns></returns>
        /// <value>The state of the checkbox.</value>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public ToggleState GetCheckState()
        {
            try
            {
                ToggleState ret = TogglePatternHelper.GetToggleState(UIAElement);
                if (ret == ToggleState.Indeterminate && NativeWindowHandle != IntPtr.Zero)
                {
                    /* Otherwise, retry with native method */
                    ret = ProdCheckBoxNative.GetCheckStateNative((IntPtr) UIAElement.Current.NativeWindowHandle);
                }
                LogText = "CheckState " + ret;
                LogMessage();

                return ret;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Sets the current CheckBoxes state.
        /// </summary>
        /// <param name = "checkstate">The ProdCheckState.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetCheckState(ToggleState checkstate)
        {
            LogText = "Check change verified";

            try
            {
                RegisterEvent(TogglePatternIdentifiers.ToggleStateProperty);
                int ret = TogglePatternHelper.SetToggleState(UIAElement, checkstate);
                if (ret == -1 && NativeWindowHandle != IntPtr.Zero)
                {
                    ProdCheckBoxNative.SetCheckStateNative(NativeWindowHandle, checkstate);
                }
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Changes the CheckState of checkbox to next valid CheckState
        /// </summary>
        /// <exception cref = "ProdVerificationException">Toggle event could not be confirmed</exception>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void ToggleCheckState()
        {
            LogText = "Toggle verified";

            try
            {
                RegisterEvent(TogglePatternIdentifiers.ToggleStateProperty);
                TogglePatternHelper.Toggle(UIAElement);
            }
            catch (ProdVerificationException err)
            {
                throw;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }
    }
}