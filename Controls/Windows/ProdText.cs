// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Windows.Automation;
using ProdUI.Exceptions;
using ProdUI.Interaction.Native;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///     This handles items with ControlType.Text (labels)
    /// </summary>
    public sealed class ProdText : BaseProdControl
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdText(ProdWindow prodWindow, string automationId) : base(prodWindow, automationId)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdText(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdText(ProdWindow prodWindow, IntPtr controlHandle) : base(prodWindow, controlHandle)
        {
        }

        #endregion

        public bool ReadOnly
        {
            get
            {
                TextPattern tp = (TextPattern) UIAElement.GetCurrentPattern(TextPattern.Pattern);
                return (bool) tp.DocumentRange.GetAttributeValue(TextPattern.IsReadOnlyAttribute);
            }
        }

        /// <summary>
        ///     Set label text to an empty string
        /// </summary>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Clear()
        {
            LogText = "Cleared";

            try
            {
                RegisterEvent(ValuePattern.ValueProperty);
                if (ReadOnly)
                {
                    throw new ProdOperationException("Text Control is Read Only");
                }

                if (ValuePatternHelper.SetValue(UIAElement, "") == 0)
                {
                    return;
                }


                if (NativeWindowHandle != IntPtr.Zero)
                {
                    NativeTextProds.ClearTextNative(NativeWindowHandle);
                    return;
                }

                /* If it doesn't have one, send keys, then */
                //TODO: convert ValuePatternHelper.SendKeysSetText(UIAElement, string.Empty);              
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }


        /// <summary>
        ///     Gets the number of characters in Text Control
        /// </summary>
        /// <returns>The number of characters in the Text Control</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        /// <remarks>
        ///     Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetTextLength()
        {
            try
            {
                string txt = GetText();
                if (txt != null && NativeWindowHandle != IntPtr.Zero)
                {
                    txt = NativeTextProds.GetTextNative(NativeWindowHandle);
                }

                if (txt != null)
                {
                    int retVal = txt.Length;
                    LogText = "Length: " + retVal;
                    LogMessage();

                    return retVal;
                }
            }
            catch (ProdOperationException err)
            {
                throw;
            }
            return 0;
        }

        /// <summary>
        ///     Gets or sets the text contained in the current Text Control
        /// </summary>
        /// <returns>The text currently in the Text Control</returns>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string GetText()
        {
            string ret = ValuePatternHelper.GetValue(UIAElement);

            if (ret == null && UIAElement.Current.NativeWindowHandle != 0)
            {
                ret = NativeTextProds.GetTextNative(NativeWindowHandle);
            }

            LogText = "Text: " + ret;
            LogMessage();

            return ret;
        }

        /// <summary>
        ///     Gets or sets the text contained in the current Text Control
        /// </summary>
        /// <param name = "text">The text to place into the Text Control.</param>
        /// <exception cref = "ProdOperationException">Thrown if element is no longer available</exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SetText(string text)
        {
            LogText = "Text: " + text;

            try
            {
                RegisterEvent(ValuePattern.ValueProperty);

                if (ReadOnly)
                {
                    throw new ProdOperationException("Text Control is Read Only");
                }

                if (ValuePatternHelper.SetValue(UIAElement, text) == 0)
                {
                    return;
                }


                /* If control has a handle, use native method */
                if (UIAElement.Current.NativeWindowHandle != 0)
                {
                    if (NativeTextProds.SetTextNative(NativeWindowHandle, text))
                    {
                        return;
                    }
                }

                /* If it doesn't have one, send keys, then */
                //TODO: convert   ValuePatternHelper.SendKeysSetText(UIAElement, text);
            }
            catch (ProdOperationException err)
            {
                throw;
            }
        }
    }
}