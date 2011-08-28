/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Windows.Automation;
using ProdUI.AutomationPatterns;
using ProdUI.Controls.Native;
using ProdUI.Exceptions;
using ProdUI.Logging;

namespace ProdUI.Controls
{
    /// <summary>
    /// This handles items with ControlType.Text (labels)
    /// </summary>
    public sealed class ProdText : BaseProdControl
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
        public ProdText(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdText(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdText(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>Set label text to an empty string</summary>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Clear()
        {
            Logmessage = "Cleared";

            try
            {
                SubscribeToEvent(ValuePattern.ValueProperty);
                if (CommonPatternHelpers.ReadOnly(ThisElement))
                {
                    throw new ProdOperationException("Text Control is Read Only");
                }

                if (ValuePatternHelper.SetValue(ThisElement, "") == 0)
                {
                    return;
                }


                if (Handle != IntPtr.Zero)
                {
                    NativeTextProds.ClearTextNative(Handle);
                    return;
                }

                /* If it doesn't have one, send keys, then */
                ValuePatternHelper.SendKeysSetText(ThisElement, string.Empty);              
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }


        /// <summary>Gets the number of characters in Text Control</summary>
        /// <returns>The number of characters in the Text Control</returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>Will attempt to match AutomationId, then Name</remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetTextLength()
        {
            try
            {
                string txt = GetText();
                if (txt != null && Handle != IntPtr.Zero)
                {
                    txt = NativeTextProds.GetTextNative(Handle);
                }

                int retVal = txt.Length;
                Logmessage = "Length: " + retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>Gets or sets the text contained in the current Text Control</summary>
        /// <returns>The text currently in the Text Control</returns>
        /// <exception cref="ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetText()
        {
            string ret = ValuePatternHelper.GetValue(ThisElement);

            if (ret == null && ThisElement.Current.NativeWindowHandle != 0)
            {
                ret = NativeTextProds.GetTextNative(Handle);
            }

            Logmessage = "Text: " + ret;
            LogEntry();

            return ret;
        }

        /// <summary>
        ///   Gets or sets the text contained in the current Text Control
        /// </summary>
        /// <param name = "text">The text to place into the Text Control.</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetText(string text)
        {
            Logmessage = "Text: " + text;

            try
            {
                SubscribeToEvent(ValuePattern.ValueProperty);

                if (CommonPatternHelpers.ReadOnly(ThisElement))
                {
                    throw new ProdOperationException("Text Control is Read Only");
                }

                if (ValuePatternHelper.SetValue(ThisElement, text) == 0)
                {
                    return;
                }


                /* If control has a handle, use native method */
                if (ThisElement.Current.NativeWindowHandle != 0)
                {
                    if (NativeTextProds.SetTextNative(Handle, text))
                    {
                        return;
                    }

                }

                /* If it doesn't have one, send keys, then */
                ValuePatternHelper.SendKeysSetText(ThisElement, text);

            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
            }
        }
    }
}
