﻿// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Collections.Generic;
using System.Windows.Automation;
using System.Windows.Automation.Text;
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

namespace ProdControls
{
    /// <summary>
    ///     Methods to work with Text (Label) controls using the UI Automation framework
    ///     A text control can be used alone as a label or as static text on a form.
    /// </summary>
    public sealed class ProdDocument : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation element</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdDocument(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdDocument(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdDocument(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        ///     Gets all text in the control.
        /// </summary>
        /// <param name = "control">The UI Automation element</param>
        /// <returns>Text contained in control</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetAllText(AutomationElement control)
        {
            try
            {
                string retVal = TextPatternHelper.GetText(UIAElement, -1);
                LogText = "Text: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets the selected text in a control that supports multiple, disjointed text selection
        /// </summary>
        /// <returns>List containing all selected TextRanges</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public List<object> GetMultiSelectedText()
        {
            if (TextPatternHelper.GetSupportedTextSelection(UIAElement) == SupportedTextSelection.Single)
            {
                return null;
            }

            try
            {
                TextPatternRange[] selected = TextPatternHelper.GetSelection(UIAElement);
                List<object> retVal = new List<object>(selected);

                LogText = "Text";
                VerboseInformation = retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }


        /// <summary>
        ///     Gets the selected text in a control that supports single text range selection.
        /// </summary>
        /// <returns>Text that is currently selected</returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetSelectedText()
        {
            try
            {
                TextPatternRange[] selected = TextPatternHelper.GetSelection(UIAElement);

                string retVal = selected[0].GetText(-1);
                LogText = "Text: " + retVal;
                LogMessage();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }
    }
}