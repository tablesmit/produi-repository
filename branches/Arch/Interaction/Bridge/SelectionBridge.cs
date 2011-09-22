﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;
using System.Windows.Automation;
using ProdUI.Logging;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Interaction.Native;
using ProdUI.Verification;

namespace ProdUI.Interaction.Bridge
{
    /// <summary>
    /// Handles non-list related items that use the SelectionPatterns
    /// </summary>
    internal static class SelectionBridge
    {
        /// <summary>
        /// Gets a value indicating if a RadioButton is selected
        /// </summary>
        /// <param name="theInterface">The extension interface.</param>
        /// <param name="control">The base ProdUI control</param>
        /// <returns>
        ///   <c>true</c> if selected, <c>false</c> otherwise
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static bool GetIsSelectedBridge(this ISelection theInterface, BaseProdControl control)
        {
            try
            {
                return UiaGetIsSelected(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                if (control.UIAElement.Current.ControlType != ControlType.RadioButton) throw new ProdOperationException("This method only works with selectable RadioButtons");
                return NativeGetIsSelected(control);
            }
        }

        private static bool NativeGetIsSelected(BaseProdControl control)
        {
            return ProdRadioButtonNative.GetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static bool UiaGetIsSelected(BaseProdControl control)
        {
            bool retVal = SelectionPatternHelper.IsSelected(control.UIAElement);
            LogController.ReceiveLogMessage(new LogMessage(retVal.ToString()));
            return retVal;
        }


        /// <summary>
        /// Selects a RadioButton
        /// </summary>
        /// <param name="theInterface">The extension interface.</param>
        /// <param name="control">The base ProdUI control</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        internal static void SetSetSelectedBridge(this ISelection theInterface, BaseProdControl control)
        {
            try
            {
                UiaSetSelected(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                if (control.UIAElement.Current.ControlType != ControlType.RadioButton) throw new ProdOperationException("This method only works with selectable RadioButtons");
                NativeSetSelected(control);
            }
        }

        private static void NativeSetSelected(BaseProdControl control)
        {
            ProdRadioButtonNative.SetCheckStateNative((IntPtr)control.UIAElement.Current.NativeWindowHandle);
        }

        private static void UiaSetSelected(BaseProdControl control)
        {
            AutomationEventVerifier.Register(new EventRegistrationMessage(control, SelectionItemPattern.ElementSelectedEvent));
            SelectionPatternHelper.Select(control.UIAElement);
        }
    }
}