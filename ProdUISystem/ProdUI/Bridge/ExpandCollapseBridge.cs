using System;
using System.Windows.Automation;
using ProdUI.Adapters;
using ProdUI.Bridge.UIAPatterns;
using ProdUI.Exceptions;

namespace ProdUI.Interaction.Bridge
{
    public static class ExpandCollapseBridge
    {
        /// <summary>
        /// Displays all child nodes, controls, or content of the AutomationElement.
        /// </summary>
        /// <example>this.Expand(this);</example>
        public static void ExpandHook(this ExpandCollapseAdapter extension, BaseProdControl control)
        {
            try
            {
                UiaExpand(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                //Note: Native
                throw new ProdOperationException(err);
            }
        }

        private static void UiaExpand(BaseProdControl control)
        {
            ExpandCollapseHelper.Expand(control.UIAElement);
        }


        /// <summary>
        /// Hides all descendant nodes, controls, or content of the AutomationElement.
        /// </summary>
        /// <example>this.Collapse(this);</example>
        public static void CollapseHook(this ExpandCollapseAdapter extension, BaseProdControl control)
        {
            try
            {
                UiaExpand(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                //Note: Native
                throw new ProdOperationException(err);
            }
        }

        private static void UiaCollapse(BaseProdControl control)
        {
            ExpandCollapseHelper.Collapse(control.UIAElement);
        }


        /// <summary>
        /// Gets the state, expanded or collapsed, of the control.
        /// </summary>
        /// <value>
        /// The state of the control.
        /// </value>
        public static ExpandCollapseState ExpandCollapseStateHook(BaseProdControl control)
        {
            try
            {
                return UiaExpandCollapseState(control);
            }
            catch (ArgumentNullException err)
            {
                throw new ProdOperationException(err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err);
            }
            catch (InvalidOperationException err)
            {
                //Note: Native
                throw new ProdOperationException(err);
            }
        }

        private static ExpandCollapseState UiaExpandCollapseState(BaseProdControl control)
        {
            return ExpandCollapseHelper.ExpandCollapseState(control.UIAElement);
        }
    }
}
