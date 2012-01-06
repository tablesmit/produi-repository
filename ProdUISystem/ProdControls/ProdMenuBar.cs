// License Rider:
// I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do

using System.Windows.Automation;
using ProdUI.Logging;

//Note CheckItem - if menu item supports check state

namespace ProdControls
{
    /// <summary>
    /// Handles the MenuBar and MenuItem Control Types
    /// </summary>
    public sealed class ProdMenuBar : BaseProdControl, IExpandCollapse, IInvoke
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProdMenuItem"/> class.
        /// </summary>
        /// <param name="prodWindow">The prod window.</param>
        /// <param name="automationId">The automation id. Pass an empty string for the top level menu</param>
        public ProdMenuBar(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
            if (automationId.Length == 0) automationId = "Application";
        }

        /// <summary>
        /// Initializes a new instance of the ProdButton class.
        /// </summary>
        /// <param name="prodWindow">The ProdWindow that contains this control.</param>
        /// <param name="treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdMenuBar(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        #endregion

        /// <summary>
        /// Selects the menu item.
        /// </summary>
        /// <param name="itemPath">The item path, with each item down the path as an item in the list</param>
        /// <remarks>
        /// Menu item text MUST be exact (but not case-sensitive). 'Open' will not match an item 'Open...' but will match 'open'
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectMenuItem(string[] itemPath)
        {
            this.SelectMenuItemBridge(this, itemPath);
        }

        /// <summary>
        /// Invokes the menu item by accelerator key.
        /// </summary>
        /// <param name="keyCombination">The key combination.</param>
        /// <remarks>
        /// Converts from format of "Shift+CTRL+Y" into "+^(Y)"
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void InvokeByAcceleratorKey(string keyCombination)
        {
            this.InvokeByAcceleratorKeyBridge(this, keyCombination);
        }

        /// <summary>
        /// Invokes the menu item by accelerator key.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <remarks>
        /// Retrieves accelerator keys from supplied controls properties
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void InvokeByAcceleratorKey()
        {
            this.InvokeByAcceleratorKeyBridge(this);
        }


        /// <summary>
        /// Invokes the menu item by access key.
        /// </summary>
        /// <param name="control">The menu item element.</param>
        /// <remarks>
        /// Retrieves access keys from supplied controls properties
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void InvokeByAccessKey()
        {
            this.InvokeByAccessKeyBridge(this);
        }

        /// <summary>
        /// Invokes the menu item by access key.
        /// </summary>
        /// <param name="keyCombination">The key combination.</param>
        /// <remarks>
        /// Converts from format of "Shift+CTRL+Y" into "+^(Y)"
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void InvokeByAccessKey(string keyCombination)
        {
            this.InvokeByAccessKeyBridge(this, keyCombination);
        }


        /// <summary>
        /// Gets the menu items.
        /// </summary>
        /// <returns>
        /// A collection of top-level menu items
        /// </returns>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public AutomationElementCollection GetMenuItems()
        {
            return this.GetMenuItemsBridge(this);
        }

    }
}