// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
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
        /// Gets the current state of the specified checkbox
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle of the target control</param>
        /// <returns>
        /// one of the <see cref="System.Windows.Automation.ToggleState"/>ToggleStates
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Invalid for WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static ToggleState GetCheckState(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(TogglePattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(TogglePattern.ToggleStateProperty, control);

                ToggleState ret = TogglePatternHelper.GetToggleState(control);
                if (ret == ToggleState.Indeterminate)
                {
                    /* Otherwise, retry with native method */
                    ret = ProdCheckBoxNative.GetCheckStateNative(controlHandle);
                }

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
        /// Gets the current state of the specified checkbox
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <returns>
        /// one of the <see cref="System.Windows.Automation.ToggleState"/>ToggleStates
        /// </returns>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static ToggleState GetCheckState(ProdWindow prodwindow, string automationId)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                StaticEvents.RegisterEvent(TogglePattern.ToggleStateProperty, control);

                ToggleState ret = TogglePatternHelper.GetToggleState(control);

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
        /// Sets the CheckState of the specified checkbox
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle of the control</param>
        /// <param name="isChecked">One of the <see cref="System.Windows.Automation.ToggleState"/>ToggleStates</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Invalid for WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetCheckState(IntPtr controlHandle, ToggleState isChecked)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(TogglePattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(TogglePattern.ToggleStateProperty, control);

                TogglePatternHelper.SetToggleState(control, isChecked);

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
        /// Sets the CheckState of the specified checkbox
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <param name="isChecked">One of the <see cref="System.Windows.Automation.ToggleState"/>ToggleStates</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void SetCheckState(ProdWindow prodwindow, string automationId, ToggleState isChecked)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                StaticEvents.RegisterEvent(TogglePattern.ToggleStateProperty, control);

                TogglePatternHelper.SetToggleState(control, isChecked);

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
        /// Toggles the state of the specified checkbox
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle of the control</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// A control will cycle through its ToggleState in this order: On, Off and, if supported, Indeterminate.
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void ToggleCheckState(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(TogglePattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(TogglePattern.ToggleStateProperty, control);

                TogglePatternHelper.Toggle(AutomationElement.FromHandle(controlHandle));

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
        /// Toggles the state of the specified checkbox
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// Invalid for WPF controls
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public static void ToggleCheckState(ProdWindow prodwindow, string automationId)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                StaticEvents.RegisterEvent(TogglePattern.ToggleStateProperty, control);

                TogglePatternHelper.Toggle(control);

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
        /// Performs the default "Click" method for a CheckBox
        /// </summary>
        /// <param name="controlHandle">The target controls handle.</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        internal static void CheckBoxClick(IntPtr controlHandle)
        {
            try
            {
                AutomationElement control = CommonUIAPatternHelpers.Prologue(TogglePattern.Pattern, controlHandle);
                StaticEvents.RegisterEvent(TogglePattern.ToggleStateProperty, control);

                TogglePatternHelper.Toggle(control);

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
        /// Performs the default "Click" method for a CheckBox
        /// </summary>
        /// <param name="prodwindow">The containing ProdWindow.</param>
        /// <param name="automationId">The automation id (or caption).</param>
        /// <exception cref="ProdOperationException">Examine inner exception</exception>
        /// <remarks>
        /// This is the WPF version
        /// </remarks>
        internal static void CheckBoxClick(ProdWindow prodwindow, string automationId)
        {
            try
            {
                AutomationElement control = InternalUtilities.GetHandlelessElement(prodwindow, automationId);
                StaticEvents.RegisterEvent(TogglePattern.ToggleStateProperty, control);

                TogglePatternHelper.Toggle(control);

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
    }
}