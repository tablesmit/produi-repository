// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;




namespace ProdUI.Adapters
{
    internal interface SelectionItemAdapter
    {
        /// <summary>
        /// Gets a value that indicates whether an item is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        bool IsSelected { get; }

        /// <summary>
        /// Gets the AutomationElement that supports the SelectionPattern control pattern and acts as the container for the calling object.
        /// </summary>
        AutomationElement SelectionContainer { get; }

        /// <summary>
        /// Adds the current element to the collection of selected items.
        /// </summary>
        void AddToSelection(string text);
        /// <summary>
        /// Adds the current element to the collection of selected items.
        /// </summary>
        /// <param name="index">The index of the item.</param>
        void AddToSelection(int index);

        /// <summary>
        /// Removes the current element from the collection of selected items.
        /// </summary>
        void RemoveFromSelection(string text);
        /// <summary>
        /// Removes the current element from the collection of selected items.
        /// </summary>
        /// <param name="index">The index of the item.</param>
        void RemoveFromSelection(int index);

        /// <summary>
        /// Deselects any selected items and then selects the current element
        /// </summary>
        /// <param name="text">The text of the item to select.</param>
        void Select(string text);
        /// <summary>
        /// Deselects any selected items and then selects the current element
        /// </summary>
        /// <param name="index">The index of the item to select.</param>
        void Select(int index);

    }
}