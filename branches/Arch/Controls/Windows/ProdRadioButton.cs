/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Logging;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Interaction.Native;


namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///   Methods to work with Radio Button controls using the UI Automation framework
    /// </summary>
    public sealed class ProdRadioButton : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the ProdRadioButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///   Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdRadioButton(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdRadioButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdRadioButton(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdRadioButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdRadioButton(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion


        /// <summary>Gets a value indicating whether the control is checked</summary>
        /// <returns></returns>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        ///   
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public bool GetChecked()
        {
            try
            {
                bool retVal = SelectionPatternHelper.IsSelected(UIAElement);

                LogText = retVal.ToString(CultureInfo.CurrentCulture);
                LogMessage();

                return retVal;
            }
            catch (InvalidOperationException)
            {
                return ProdRadioButtonNative.GetCheckStateNative(NativeWindowHandle);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>Selects a radio button, deselecting others in its group</summary>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Select()
        {
            LogText = "Selection verified";
            try
            {
               
                RegisterEvent(SelectionItemPattern.ElementSelectedEvent);
                SelectionPatternHelper.Select(UIAElement);
            }
            catch (InvalidOperationException)
            {
                ProdRadioButtonNative.SetCheckStateNative(NativeWindowHandle);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

    }
}