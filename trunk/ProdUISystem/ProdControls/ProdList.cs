// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Interaction;
using ProdUI.Logging;

namespace ProdControls
{
    /// <summary>
    /// Methods to work with ListBox controls using the UI Automation framework
    /// </summary>
    public sealed class ProdList : BaseProdControl, SelectionAdapter
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="automationId">The UI Automation element</param>
        /// <remarks>
        /// Will attempt to match AutomationId, then ReadOnly
        /// </remarks>
        public ProdList(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdList(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProdListBox class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="controlHandle">Window handle of the control</param>
        public ProdList(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion Constructors


        /// <summary>
        /// Determines whether this instance [can select multiple items].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can select multiple items; otherwise, <c>false</c>.
        /// </value>
        public bool CanSelectMultiple
        {
            get { return true; }
        }

        /// <summary>
        /// Gets or sets the zero based index of the selected item
        /// </summary>
        /// <value>
        /// The zero based index.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int SelectedIndex
        {
            get { return this.GetSelectedIndexBridge(this); }
            set { this.SetSelectedIndexBridge(this, value); }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public string SelectedItem
        {
            get { return this.GetSelectedItemBridge(this).Current.Name; }
            set { this.SetSelectedItemBridge(this, value); }
        }

        /// <summary>
        /// Gets or sets the selected indexes.
        /// </summary>
        /// <value>
        /// The selected indexes.
        /// </value>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public Collection<int> SelectedIndexes
        {
            get { return this.GetSelectedIndexesBridge((this)); }
            set { this.SetSelectedIndexesBridge(this, value); }
        }

        ///// <summary>
        ///// Gets or sets the selected items.
        ///// </summary>
        ///// <value>
        ///// The selected items.
        ///// </value>
        //[ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        //public Collection<string> SelectedItems
        //{
        //    get { return this.GetSelectedItemsBridge(this); }
        //    set { this.SetSelectedItemsBridge(this, value); }
        //}

        /// <summary>
        /// Gets the number of items in the List control
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int ItemCount
        {
            get
            {
                return this.GetItemCountBridge(this);
            }
        }



        /// <summary>
        /// Gets the items in a List control.
        /// </summary>
        /// <returns>
        /// an ArrayList containing the items in a List control
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public Collection<object> GetItems()
        {
            return this.GetItemsBridge(this);
        }


        /// <summary>
        /// Adds the selected list item to the current selection.
        /// </summary>
        /// <param name="index">The zero-based index of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(int index)
        {
            this.AddToSelectionBridge(this, index);
        }

        /// <summary>
        /// Adds the selected list item to the current selection.
        /// </summary>
        /// <param name="itemText">The text of the item to select.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void AddToSelection(string itemText)
        {
            this.AddToSelectionBridge(this, itemText);
        }


        /// <summary>
        /// Gets the selected item count.
        /// </summary>
        /// <returns>
        /// The count of selected items
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetSelectedItemCount()
        {
            return this.GetSelectedItemCountBridge(this);
        }

        /// <summary>
        /// Removes the selected list item from the current selection.
        /// </summary>
        /// <param name="index">The index of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(int index)
        {
            this.RemoveFromSelectionBridge(this, index);
        }

        /// <summary>
        ///     Removes the selected list item from the current selection.
        /// </summary>
        /// <param name = "itemText">The text of the item to deselect.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void RemoveFromSelection(string itemText)
        {
            this.RemoveFromSelectionBridge(this, itemText);
        }

        /// <summary>
        /// Selects all items in a ListBox.
        /// </summary>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectAll()
        {
            this.SelectAllBridge(this);
        }



        public bool IsSelectionRequired
        {
            get { throw new NotImplementedException(); }
        }

        public AutomationElementCollection ListItems
        {
            get { throw new NotImplementedException(); }
        }

        public AutomationElement[] SelectedItems
        {
            get { throw new NotImplementedException(); }
        }
    }
}