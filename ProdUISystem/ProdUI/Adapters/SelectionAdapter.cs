// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;


namespace ProdUI.Interaction.Bridge
{
    internal interface SelectionAdapter
    {
        /// <summary>
        /// Gets a value that specifies whether the container allows more than one child element to be selected concurrently.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can select multiple; otherwise, <c>false</c>.
        /// </value>
        bool CanSelectMultiple { get; }

        /// <summary>
        /// Gets a value that specifies whether the container requires at least one child item to be selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is selection required; otherwise, <c>false</c>.
        /// </value>
        bool IsSelectionRequired { get; }

        /// <summary>
        /// Gets the list of all items.
        /// </summary>
        AutomationElementCollection ListItems { get; }

        /// <summary>
        /// Gets an array containing all selected items.
        /// </summary>
        AutomationElement[] SelectedItems { get; }
    }
}