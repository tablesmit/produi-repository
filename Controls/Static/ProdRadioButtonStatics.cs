// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Windows.Automation;
using ProdUI.Configuration;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;
using ProdUI.Utility;

namespace ProdUI.Controls.Static
{
    public static partial class Prod
    {
        /// <summary>
        ///     Determines whether specified RadioButton is selected
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target control</param>
        /// <returns>
        ///     True if selected, false if not
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool GetRadioState(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
            bool ret = SelectionPatternHelper.IsSelected(control);
            string logmessage = "RadioButton state: " + ret;
            ProdStaticSession.Log(logmessage);
            return ret;
        }

        /// <summary>
        ///     Selects the specified RadioButton
        /// </summary>
        /// <param name = "controlHandle">NativeWindowHandle to the target control</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SelectRadio(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);

                SelectionPatternHelper.Select(control);

                const string logmessage = "RadioButton selected";
                ProdStaticSession.Log(logmessage);
            }
            catch (InvalidOperationException)
            {
                ProdRadioButtonNative.SetCheckStateNative(controlHandle);
            }
        }

        /// <summary>
        ///     Determines whether specified RadioButton is selected
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <returns>
        ///     True if selected, false if not
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool GetRadioState(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            bool ret = SelectionPatternHelper.IsSelected(control);


            string logmessage = "RadioButton state: " + ret;
            ProdStaticSession.Log(logmessage);
            return ret;
        }

        /// <summary>
        ///     Selects the specified RadioButton
        /// </summary>
        /// <param name = "prodwindow">The containing ProdWindow.</param>
        /// <param name = "automationId">The automation id (or caption).</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SelectRadio(ProdWindow prodwindow, string automationId)
        {
            AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
            StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);

            SelectionPatternHelper.Select(control);

            const string logmessage = "RadioButton selected";
            ProdStaticSession.Log(logmessage);
        }
    }
}