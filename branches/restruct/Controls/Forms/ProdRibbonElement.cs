/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System.Windows.Automation;
using ProdUI.Interaction.UIAPatterns;

namespace ProdUI.Controls.Windows
{
    /// <summary>
    ///   Provides methods for working with Ribbon control elements
    /// </summary>
    public sealed class ProdRibbonElement : BaseProdControl
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "ProdRibbonElement" /> class.
        /// </summary>
        /// <param name = "prodwindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        public ProdRibbonElement(ProdWindow prodwindow, string automationId) : base(prodwindow, automationId)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "ProdButton" /> class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree</param>
        public ProdRibbonElement(ProdWindow prodWindow, int treePosition) : base(prodWindow, treePosition)
        {
        }


        /// <summary>
        ///   Clicks this instance.
        /// </summary>
        public void Click()
        {
            LogText = "Click Verified";

            RegisterEvent(InvokePattern.InvokedEvent);
            InvokePatternHelper.Invoke(UIAElement);            
        }
    }
}