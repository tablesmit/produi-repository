﻿// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using ProdUI.Adapters;
using ProdUI.Interaction;
using ProdUI.Interaction.Bridge;
using ProdUI.Logging;

/* Notes
 * Supported Patterns:
 * IInvokeProvider
 * (IToggleProvider) -> ToggleButton
 */

namespace ProdControls
{
    /// <summary>
    /// Methods to work with Button controls using the UI Automation framework
    /// </summary>
    public sealed class ProdButton : BaseProdControl, InvokeAdapter
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="automationId">The UI Automation element</param>
        /// <remarks>
        /// Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdButton(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdButton(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        public ProdButton(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors

        /// <summary>
        /// Performs a "Click" on the current ProdButton
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void Invoke()
        {
            this.InvokeHook(this);
        }
    }
}