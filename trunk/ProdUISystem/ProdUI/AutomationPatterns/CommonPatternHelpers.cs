/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.Controls;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.AutomationPatterns
{
    /// <summary>
    ///   Provides methods common across all pattern helpers. mostly to determine support
    /// </summary>
    internal static class CommonPatternHelpers
    {
        /// <summary>
        ///   Gets UIAutomation target control ready for manipulation
        /// </summary>
        /// <param name = "pattern"><see cref = "System.Windows.Automation.AutomationPattern" /> to be used</param>
        /// <param name = "controlHandle">Handle to control to be worked with</param>
        /// <returns>UI Automation element</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Error, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static AutomationElement Prologue(AutomationPattern pattern, IntPtr controlHandle)
        {
            AutomationElement control = AutomationElement.FromHandle(controlHandle);
            ControlSetFocus(control);

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
        /// Gets UIAutomation target control ready for manipulation
        /// </summary>
        /// <param name="prodwindow">The ProdWindow.</param>
        /// <param name="pattern"><see cref="System.Windows.Automation.AutomationPattern"/> to be used</param>
        /// <param name="automationId">The automation id.</param>
        /// <returns>
        /// UI Automation element
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Error, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static AutomationElement Prologue(ProdWindow prodwindow, AutomationPattern pattern, string automationId)
        {
            AutomationElement control = null;

            AutomationElementCollection controls = GetControlId(prodwindow, automationId);

            /* Nothing. bail */
            if (controls.Count == 0)
            {
                throw new ProdOperationException("Cannot find control");
            }


            control = VerifyByPattern(pattern, control, controls);

            if (control == null)
            {
                throw new ProdOperationException("Cannot find control");
            }


            /* control found...proceed */
            ControlSetFocus(control);

            return control;
        }

        private static AutomationElement VerifyByPattern(AutomationPattern pattern, AutomationElement control, AutomationElementCollection controls)
        {
            /* we have some items that match the criteria, but some wpf apps name the parent the same as the child
             * so, we need to loop through to make sure they support the desired pattern*/
            foreach (AutomationElement item in controls)
            {
                try
                {
                    item.GetCurrentPattern(pattern);
                    control = item;
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            return control;
        }

        private static AutomationElementCollection GetControlId(ProdWindow prodwindow, string automationId)
        {
            /* first, try using the Automation ID */
            Condition condId = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            AutomationElementCollection controls = prodwindow.Window.FindAll(TreeScope.Descendants, condId);

            /* then we'll try the name...who knows? */
            if (controls.Count == 0)
            {
                /* try the name */
                Condition condName = new PropertyCondition(AutomationElement.NameProperty, automationId);
                controls = prodwindow.Window.FindAll(TreeScope.Descendants, condName);
            }
            return controls;
        }

        /// <summary>
        /// Attempts to bring control to the top of the z-order and set input focus
        /// </summary>
        /// <param name="control">UI Automation element to be worked with</param>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static void ControlSetFocus(AutomationElement control)
        {
            try
            {
                if ((bool)control.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty))
                {
                    if ((bool)control.GetCurrentPropertyValue(AutomationElement.IsExpandCollapsePatternAvailableProperty))
                    {
                        ExpandCollapseHelper.Expand(control);
                    }
                    control.SetFocus();
                }
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>
        /// Performs <see cref="System.Windows.Automation.AutomationPattern"/> verification
        /// </summary>
        /// <param name="pattern"><see cref="System.Windows.Automation.AutomationPattern"/> to be used</param>
        /// <param name="control">UI Automation element to be worked with</param>
        /// <returns>
        ///   <c>true</c> if pattern is supported by the control, <c>false</c> if not. a null value is returned in the event of a recoverable error
        /// </returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        internal static object CheckPatternSupport(AutomationPattern pattern, AutomationElement control)
        {
            object pat;
            try
            {
                control.TryGetCurrentPattern(pattern, out pat);
                ControlSetFocus(control);
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

        /// <summary>
        /// Gets the ReadOnly status of the control.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>
        ///   <c>true</c> if control is in a ReadOnly state <c>false</c> otherwise
        /// </returns>
        internal static bool ReadOnly(AutomationElement control)
        {
            object pattern;
            if (control.TryGetCurrentPattern(ValuePattern.Pattern, out pattern))
            {
                return ((ValuePattern)pattern).Current.IsReadOnly;
            }
            if (control.TryGetCurrentPattern(TextPattern.Pattern, out pattern))
            {
                object d = ((TextPattern)pattern).DocumentRange.GetAttributeValue(TextPattern.IsReadOnlyAttribute);

                return (bool)d;
            }

            return false;
        }

    }
}