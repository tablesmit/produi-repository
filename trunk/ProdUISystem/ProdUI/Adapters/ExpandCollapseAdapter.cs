namespace ProdUI.Adapters
{
    /// <summary>
    /// Represents controls that visually expand to display content and collapse to hide content.
    /// </summary>
    public interface ExpandCollapseAdapter
    {
        /// <summary>
        /// Displays all child nodes, controls, or content of the AutomationElement.
        /// </summary>
        /// <example>this.Expand(this);</example>
        void Expand();

        /// <summary>
        /// Hides all descendant nodes, controls, or content of the AutomationElement.
        /// </summary>
        /// <example>this.Collapse(this);</example>
        void Collapse();

        /// <summary>
        /// Gets the state, expanded or collapsed, of the control.
        /// </summary>
        /// <value>
        /// The state of the control.
        /// </value>
        System.Windows.Automation.ExpandCollapseState ExpandCollapseState { get; }
    }
}