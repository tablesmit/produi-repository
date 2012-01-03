// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.Interaction.Bridge
{
    /// <summary>
    /// Handles non-list related items that use the SelectionPatterns
    /// </summary>
    internal static class SelectionBridge
    {

        /// <summary>
        /// Gets a value that specifies whether the container allows more than one child element to be selected concurrently.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can select multiple; otherwise, <c>false</c>.
        /// </value>
        internal static bool CanSelectMultipleBridge(this SelectionAdapter extension, BaseProdControl control)
        {
            try
            {
                /* Try UIA First */
                UiaInvoke(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeInvoke(control);
            }
        }

        /// <summary>
        /// Gets a value that specifies whether the container requires at least one child item to be selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is selection required; otherwise, <c>false</c>.
        /// </value>
        internal static bool IsSelectionRequiredBridge(this SelectionAdapter extension, BaseProdControl control)
        {
            try
            {
                /* Try UIA First */
                UiaInvoke(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeInvoke(control);
            }
        }

        /// <summary>
        /// Gets the list of all items.
        /// </summary>
        internal static AutomationElementCollection ListItemsBridge(this SelectionAdapter extension, BaseProdControl control)
        {
            try
            {
                /* Try UIA First */
                UiaInvoke(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeInvoke(control);
            }
        }

        /// <summary>
        /// Gets an array containing all selected items.
        /// </summary>
        internal static AutomationElement[] SelectedItemsBridge(this SelectionAdapter extension, BaseProdControl control)
        {
            try
            {
                /* Try UIA First */
                UiaInvoke(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException)
            {
                /* now try a native SendMessage */
                NativeInvoke(control);
            }
        }
    }
}