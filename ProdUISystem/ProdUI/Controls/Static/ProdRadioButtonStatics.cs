// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Interaction.Bridge;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;

namespace ProdUI.Controls.Static
{
    public static partial class Prod
    {
        /// <summary>
        /// Determines whether specified RadioButton is selected
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target control</param>
        /// <returns>
        /// True if selected, false if not
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static bool GetRadioState(IntPtr controlHandle)
        {
            try
            {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
            bool ret = (TogglePatternHelper.GetToggleState(control) == ToggleState.On);
            LogController.ReceiveLogMessage(new LogMessage(control.Current.Name));
            return ret;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Selects the specified RadioButton
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle to the target control</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SelectRadio(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(SelectionPattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, control);

                TogglePatternHelper.SetToggleState(control, ToggleState.On);

                LogController.ReceiveLogMessage(new LogMessage(control.Current.Name));
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ArgumentException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Determines whether specified RadioButton is selected
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// True if selected, false if not
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static ToggleState GetRadioState(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            return ToggleBridge.GetCheckStateBridge(null, control);
        }

        /// <summary>
        /// Selects the specified RadioButton
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SelectRadio(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            ToggleBridge.SetCheckStateBridge(null, control, ToggleState.On);
        }
    }
}