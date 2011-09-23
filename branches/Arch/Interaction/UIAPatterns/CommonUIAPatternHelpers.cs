// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Interaction.UIAPatterns
{
    /// <summary>
    ///     Provides methods common across all pattern helpers. mostly to determine support
    /// </summary>
    internal static class CommonUIAPatternHelpers
    {
        /// <summary>
        ///     Gets UIAutomation target control ready for manipulation
        /// </summary>
        /// <param name = "pattern"><see cref = "System.Windows.Automation.AutomationPattern" /> to be used</param>
        /// <param name = "controlHandle">NativeWindowHandle to control to be worked with</param>
        /// <returns>
        ///     UI Automation element
        /// </returns>
        [ProdLogging(LoggingLevels.Error, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static AutomationElement Prologue(AutomationPattern pattern, IntPtr controlHandle)
        {
            AutomationElement control = AutomationElement.FromHandle(controlHandle);
            control.SetFocus();

            try
            {
                CheckPatternSupport(pattern, control);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            return control;
        }

        /// <summary>
        ///     Gets UIAutomation target control ready for manipulation
        /// </summary>
        /// <param name = "prodwindow">The ProdWindow.</param>
        /// <param name = "pattern"><see cref = "System.Windows.Automation.AutomationPattern" /> to be used</param>
        /// <param name = "automationId">The automation id.</param>
        /// <returns>
        ///     UI Automation element
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Error, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static AutomationElement Prologue(ProdWindow prodwindow, AutomationPattern pattern, string automationId)
        {
            AutomationElement control = GetControl(prodwindow, automationId);
            /* control found...proceed */
            control.SetFocus();

            /* Nothing. bail */
            if (control == null)
            {
                throw new ProdOperationException("Cannot find control");
            }

            try
            {
                CheckPatternSupport(pattern, control);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }

            return control;
        }


        /// <summary>
        ///     Gets the controls with matching automationId inside a ProdWindow
        /// </summary>
        /// <param name = "prodwindow">The ProdWindow.</param>
        /// <param name = "automationId">The automation id.</param>
        /// <returns>A list of matching elements/returns></returns>
        private static AutomationElement GetControl(ProdWindow prodwindow, string automationId)
        {
            /* first, try using the Automation ID */
            Condition condId = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            AutomationElement control = prodwindow.UIAElement.FindFirst(TreeScope.Descendants, condId);

            /* then we'll try the name...who knows? */
            if (control == null)
            {
                /* try the name */
                Condition condName = new PropertyCondition(AutomationElement.NameProperty, automationId);
                control = prodwindow.UIAElement.FindFirst(TreeScope.Descendants, condName);
            }
            return control;
        }


        /// <summary>
        ///     Performs <see cref = "System.Windows.Automation.AutomationPattern" /> verification
        /// </summary>
        /// <param name = "pattern"><see cref = "System.Windows.Automation.AutomationPattern" /> to be used</param>
        /// <param name = "control">UI Automation element to be worked with</param>
        /// <returns>
        ///     <c>true</c> if pattern is supported by the control, <c>false</c> if not. a <c>null</c> value is returned in the event of a recoverable error
        /// </returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        internal static object CheckPatternSupport(AutomationPattern pattern, AutomationElement control)
        {
            try
            {
                object pat;
                control.TryGetCurrentPattern(pattern, out pat);
                control.SetFocus();
                return pat;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (Exception)
            {
                throw new ProdOperationException("Does not support " + pattern.ProgrammaticName);
            }
        }
    }
}