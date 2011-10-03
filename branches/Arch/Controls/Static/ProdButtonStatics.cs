﻿// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System;
using System.Windows.Automation;
using ProdUI.Controls.Windows;
using ProdUI.Interaction.Bridge;
using ProdUI.Interaction.UIAPatterns;
using ProdUI.Logging;

namespace ProdUI.Controls.Static
{
    public static partial class Prod
    {
        /// <summary>
        /// Performs a "Click" on the specified static ProdButton
        /// </summary>
        /// <param name="controlHandle">NativeWindowHandle of the target control</param>
        /// <remarks>
        /// This overload is invalid for WPF controls
        /// </remarks>
        public static void ButtonClick(IntPtr controlHandle)
        {
            AutomationElement control = CommonUIAPatternHelpers.Prologue(InvokePattern.Pattern, controlHandle);
            StaticEvents.RegisterEvent(InvokePattern.InvokedEvent, control);
            InvokePatternHelper.Invoke(control);
            LogController.ReceiveLogMessage(new LogMessage(control.Current.Name));
        }

        /// <summary>
        /// Clicks this ProdButton.
        /// </summary>
        /// <param name="prodwindow">The ProdWindow that contains this control..</param>
        /// <param name="automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        /// The program will also attempt to identify using the name property if the AutomationId fails
        /// </remarks>
        public static void ButtonClick(ProdWindow prodwindow, string automationId)
        {
            BaseProdControl control = new BaseProdControl(prodwindow, automationId);
            InvokeBridge.ClickBridge(null, control);
        }
    }
}