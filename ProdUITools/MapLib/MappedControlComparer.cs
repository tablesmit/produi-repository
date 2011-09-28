/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System.Collections.Generic;
using System.Globalization;

/*
Property		         Fill Rate		    relevance (5 = high)
ClassNameProperty	     always filled		     5 ----- auto fail
ControlTypeProperty	     always filled		     5 ----- auto fail
 * 
HelpTextProperty	     rarely filled		     4
AcceleratorKeyProperty	 rarely filled		     4
AccessKeyProperty	     rarely filled		     4
LabeledByProperty	     rarely filled		     3
ControlTreePosition	     always filled		     3
AutomationIdProperty     usually filled	         2
NameProperty		     usually filled	         2
ItemTypeProperty 	     rarely filled?	         2
                                                24
 */

namespace MapLib
{
    /// <summary>
    /// Used to compare 2 controls to see if they are "Equal"
    /// </summary>
    internal static class MappedControlComparer
    {
        private static List<CompareResult> _results;

        /// <summary>
        /// Compares a loaded map to the supplied map file
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMapControl">The loaded map.</param>
        /// <returns>
        /// The list of compare results for each comparison
        /// </returns>
        internal static List<CompareResult> Compare(MappedControl currentControl, MappedControl loadedMapControl)
        {
            _results = new List<CompareResult>();
            if (!CompareClasses(currentControl, loadedMapControl))
            {
                return _results;
            }

            /* functions to handle comparing the individual criteria */
            CompareHelpText(currentControl, loadedMapControl);
            CompareAcceleratorKey(currentControl, loadedMapControl);
            CompareAccessKey(currentControl, loadedMapControl);
            CompareLabeledBy(currentControl, loadedMapControl);
            CompareTreePosition(currentControl, loadedMapControl);
            CompareAutomationId(currentControl, loadedMapControl);
            CompareName(currentControl, loadedMapControl);
            CompareItemType(currentControl, loadedMapControl);

            return _results;
        }

        /// <summary>
        /// Compares the class and Automation.ControlType values.
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMap">The loaded map.</param>
        /// <returns>
        ///   <c>true</c> if passed <c>false</c> otherwise
        /// </returns>
        /// <remarks>
        /// If this fails, the whole control fails
        /// </remarks>
        private static bool CompareClasses(MappedControl currentControl, MappedControl loadedMap)
        {
            /* 5's */

            /* Do the windows Class comparison */
            CompareResult cr = new CompareResult { Category = "ClassName", LiveValue = currentControl.ClassName, LoadedValue = loadedMap.ClassName };
            if (string.Compare(currentControl.ClassName, loadedMap.ClassName, true, CultureInfo.CurrentCulture) != 0)
            {
                cr.Score = 0;
                cr.Passed = false;
                _results.Add(cr);
                return false;
            }
            cr.Passed = true;
            _results.Add(cr);

            /* and now the Automation ControlType compare */
            cr = new CompareResult { Category = "ControlType", LiveValue = currentControl.ControlType, LoadedValue = loadedMap.ControlType };
            if (string.Compare(currentControl.ControlType, loadedMap.ControlType, true, CultureInfo.CurrentCulture) != 0)
            {
                cr.Score = 0;
                cr.Passed = false;
                _results.Add(cr);
                return false;
            }
            cr.Passed = true;
            _results.Add(cr);

            return true;
        }

        /// <summary>
        /// Compares the help text.
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMap">The loaded map.</param>
        private static void CompareHelpText(MappedControl currentControl, MappedControl loadedMap)
        {
            /* If this is empty, its serialized as a null */
            if (loadedMap.HelpText == null)
            {
                loadedMap.HelpText = string.Empty;
            }


            CompareResult cr = new CompareResult { Category = "HelpText", LiveValue = currentControl.HelpText, LoadedValue = loadedMap.HelpText };
            if (string.Compare(currentControl.HelpText, loadedMap.HelpText, true, CultureInfo.CurrentCulture) != 0)
            {
                cr.Score = -4;
                cr.Passed = false;
            }
            else
            {
                cr.Passed = true;
            }
            _results.Add(cr);
        }

        /// <summary>
        /// Compares the accelerator keys.
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMap">The loaded map.</param>
        private static void CompareAcceleratorKey(MappedControl currentControl, MappedControl loadedMap)
        {
            CompareResult cr = new CompareResult { Category = "AcceleratorKey", LiveValue = currentControl.AcceleratorKey, LoadedValue = loadedMap.AcceleratorKey };
            if (string.Compare(currentControl.AcceleratorKey, loadedMap.AcceleratorKey, true, CultureInfo.CurrentCulture) != 0)
            {
                cr.Score = -4;
                cr.Passed = false;
            }
            else
            {
                cr.Passed = true;
            }
            _results.Add(cr);
        }

        /// <summary>
        /// Compares the access keys.
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMap">The loaded map.</param>
        private static void CompareAccessKey(MappedControl currentControl, MappedControl loadedMap)
        {
            CompareResult cr = new CompareResult { Category = "AccessKey", LiveValue = currentControl.AccessKey, LoadedValue = loadedMap.AccessKey };
            if (string.Compare(currentControl.AccessKey, loadedMap.AccessKey, true, CultureInfo.CurrentCulture) != 0)
            {
                cr.Score = -4;
                cr.Passed = false;
            }
            else
            {
                cr.Passed = true;
            }
            _results.Add(cr);
        }

        /// <summary>
        /// Compares the labeledBy value.
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMap">The loaded map.</param>
        private static void CompareLabeledBy(MappedControl currentControl, MappedControl loadedMap)
        {
            CompareResult cr = new CompareResult { Category = "LabeledBy", LiveValue = currentControl.LabeledBy, LoadedValue = loadedMap.LabeledBy };
            if (string.Compare(currentControl.LabeledBy, loadedMap.LabeledBy, true, CultureInfo.CurrentCulture) != 0)
            {
                cr.Score = -3;
                cr.Passed = false;
            }
            else
            {
                cr.Passed = true;
            }
            _results.Add(cr);
        }

        /// <summary>
        /// Compares the control tree positions.
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMap">The loaded map.</param>
        private static void CompareTreePosition(MappedControl currentControl, MappedControl loadedMap)
        {
            CompareResult cr = new CompareResult { Category = "ControlTreePosition", LiveValue = currentControl.ControlTreePosition.ToString(CultureInfo.CurrentCulture), LoadedValue = loadedMap.ControlTreePosition.ToString(CultureInfo.CurrentCulture) };
            if (currentControl.ControlTreePosition != loadedMap.ControlTreePosition)
            {
                cr.Score = -3;
                cr.Passed = false;
            }
            else
            {
                cr.Passed = true;
            }
            _results.Add(cr);
        }

        /// <summary>
        /// Compares the Automation Ids.
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMap">The loaded map.</param>
        private static void CompareAutomationId(MappedControl currentControl, MappedControl loadedMap)
        {
            CompareResult cr = new CompareResult { Category = "AutomationId", LiveValue = currentControl.AutomationId, LoadedValue = loadedMap.AutomationId };
            if (string.Compare(currentControl.AutomationId, loadedMap.AutomationId, true, CultureInfo.CurrentCulture) != 0)
            {
                cr.Score = -2;
                cr.Passed = false;
            }
            else
            {
                cr.Passed = true;
            }
            _results.Add(cr);
        }

        /// <summary>
        /// Compares the name values.
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMap">The loaded map.</param>
        private static void CompareName(MappedControl currentControl, MappedControl loadedMap)
        {
            CompareResult cr = new CompareResult { Category = "Name", LiveValue = currentControl.Name, LoadedValue = loadedMap.Name };
            if (string.Compare(currentControl.Name, loadedMap.Name, true, CultureInfo.CurrentCulture) != 0)
            {
                cr.Score = -2;
                cr.Passed = false;
            }
            else
            {
                cr.Passed = true;
            }
            _results.Add(cr);
        }

        /// <summary>
        /// Compares the ItemType values.
        /// </summary>
        /// <param name="currentControl">The current control.</param>
        /// <param name="loadedMap">The loaded map.</param>
        private static void CompareItemType(MappedControl currentControl, MappedControl loadedMap)
        {
            CompareResult cr = new CompareResult { Category = "ItemType", LiveValue = currentControl.ItemType, LoadedValue = loadedMap.ItemType };
            if (string.Compare(currentControl.ItemType, loadedMap.ItemType, true, CultureInfo.CurrentCulture) != 0)
            {
                cr.Score = -2;
                cr.Passed = false;
            }
            else
            {
                cr.Passed = true;
            }
            _results.Add(cr);
        }
    }
}