/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections;
using System.Windows.Automation;
using System.Windows.Automation.Text;
using ProdUI.AutomationPatterns;
using ProdUI.Exceptions;
using ProdUI.Logging;

/* Notes
 * Supported Patterns: 
 * ITextProvider 
 * 
 * Proposed functionality:
 * GetText
 * GetAccelorator
 * GetFont
 * GetTextLength
 */

//TODO: In Progress

namespace ProdUI.Controls
{
    /// <summary>
    ///   Methods to work with Text (Label) controls using the UI Automation framework
    ///   A text control can be used alone as a label or as static text on a form.
    /// </summary>
    public sealed class ProdDocument : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///   Will attempt to match AutomationId, then Name
        /// </remarks>
        public ProdDocument(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdDocument(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdDocument(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        ///   Gets all text in the control.
        /// </summary>
        /// <param name = "control">The control.</param>
        /// <returns>Text contained in control</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetAllText(AutomationElement control)
        {
            try
            {
                string retVal = TextPatternHelper.GetText(ThisElement, -1);
                Logmessage = "Text: " + retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>Gets the selected text in a control that supports multiple, disjointed text selection</summary>
        /// <returns>List containing all selected TextRanges</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public ArrayList GetMultiSelectedText()
        {
            if (TextPatternHelper.GetSupportedTextSelection(ThisElement) == SupportedTextSelection.Single)
            {
                return null;
            }

            try
            {
                TextPatternRange[] selected = TextPatternHelper.GetSelection(ThisElement);
                ArrayList retVal = new ArrayList(selected);

                Logmessage = "Text";
                VerboseInformation = retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }


        /// <summary>Gets the selected text in a control that supports single text range selection.</summary>
        /// <returns>Text that is currently selected</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetSelectedText()
        {
            try
            {
                TextPatternRange[] selected = TextPatternHelper.GetSelection(ThisElement);

                string retVal = selected[0].GetText(-1);
                Logmessage = "Text: " + retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

    }
}