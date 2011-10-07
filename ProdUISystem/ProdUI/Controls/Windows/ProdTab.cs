// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.Generic;
using System.Windows.Automation;
using ProdUI.Interaction.Bridge;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    /// Methods to work with Tab controls using the UI Automation framework
    /// A tab control is analogous to the dividers in a notebook or the labels in a file cabinet. By using a tab control, an application can define multiple pages for the same area of a window or dialog box
    /// </summary>
    public sealed class ProdTab : BaseProdControl, ISingleSelectList
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdTab class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="automationId">The UI Automation element</param>
        /// <remarks>
        /// Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdTab(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdTab class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdTab(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdTab class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        public ProdTab(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors

        /// <summary>
        /// Gets the number of tabs in a TabControl.
        /// </summary>
        /// <returns>
        /// The number of tabs in a TabControl
        /// </returns>
        public int GetItemCount()
        {
            return this.GetItemCountBridge(this);
        }

        /// <summary>
        /// Gets a collection of all tabs in the TabControl
        /// </summary>
        /// <returns>
        /// list containing all items
        /// </returns>
        public List<object> GetItems()
        {
            return this.GetItemsBridge(this);
        }

        /// <summary>
        /// Gets the number of child tabs contained in the tab control
        /// </summary>
        /// <returns>
        /// The number of tabs
        /// </returns>
        public int TabCount()
        {
            return this.GetItemCountBridge(this);
        }

        /// <summary>
        /// Retrieves the selected tab
        /// </summary>
        /// <returns>
        /// Selected TabItem
        /// </returns>
        public AutomationElement SelectedTab()
        {
            return this.GetSelectedItemBridge(this);
        }

        /// <summary>
        /// Select a TabItem within the TabControl
        /// </summary>
        /// <param name="index">The zero based index of the TabItem</param>
        public void SelectTab(int index)
        {
            this.SetSelectedIndexBridge(this, index);
        }

        /// <summary>
        /// Select a TabItem within the TabControl
        /// </summary>
        /// <param name="text">The text on the tab to be selected.</param>
        public void SelectTab(string text)
        {
            this.SetSelectedItemBridge(this, text);
        }

        /// <summary>
        /// Determines whether the Tab with the specified index is selected.
        /// </summary>
        /// <param name="index">The zero based index of the tab to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified index is selected; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSelected(int index)
        {
            return this.IsItemSelectedBridge(this, index);
        }

        /// <summary>
        /// Determines whether the Tab with the specified title is selected.
        /// </summary>
        /// <param name="itemText">The item text of the tab to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified item text is selected; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSelected(string itemText)
        {
            return this.IsItemSelectedBridge(this, itemText);
        }
    }
}