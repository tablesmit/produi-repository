// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;

namespace ProdUI.Adapters
{
    public interface ToggleAdapter
    {
        /// <summary>
        /// Gets or sets the ToggleState of the control.
        /// </summary>
        /// <value>
        /// The <see cref="ToggleState"/> to set.
        /// </value>
        ToggleState ToggleState { get; set; }

        /// <summary>
        /// Toggles this control to the next ToggleState
        /// </summary>
        /// <remarks>A control must cycle through its ToggleState in this order: On, Off and if supported, Indeterminate./remarks>
        void Toggle();
    }
}