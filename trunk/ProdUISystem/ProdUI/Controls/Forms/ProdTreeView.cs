/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Automation;
using ProdUI.AutomationPatterns;
using ProdUI.Exceptions;
using ProdUI.Logging;

/* Notes
 * -Tree-
 * Supported Patterns: 
 * ISelectionProvider
 * IScrollProvider 
 * 
 * Proposed functionality:
 * 
 * -Tree Item (node)-
 * IInvokeProvider 
 * IExpandCollapseProvider
 * ISelectionItemProvider 
 * IToggleProvider 
 */



namespace ProdUI.Controls
{
    /// <summary>
    ///   Methods to work with TreeView controls using the UI Automation framework
    /// </summary>
    public class ProdTreeView : BaseProdControl
    {
        private int _chk;
        private int _treeIndex;

        /// <summary>
        ///   holds all tree nodes.
        /// </summary>
        internal Collection<AutomationElement> AllNodes { get; private set; }

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the ProdTreeView class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "automationId">The UI Automation identifier (ID) for the element.</param>
        /// <remarks>
        ///   Will attempt to match AutomationId, then Name
        /// </remarks>
        public ProdTreeView(ProdWindow prodWindow, string automationId)
            : base(prodWindow, automationId)
        {
            AllNodes = new Collection<AutomationElement>();
            AutomationElement aeNode = TreeWalker.ControlViewWalker.GetFirstChild(ThisElement);
            EnumControlElements(aeNode);
        }

        /// <summary>
        ///   Initializes a new instance of the ProdTreeView class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "treePosition">The index of this control in the parent windows UI control tree.</param>
        public ProdTreeView(ProdWindow prodWindow, int treePosition)
            : base(prodWindow, treePosition)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the ProdTreeView class.
        /// </summary>
        /// <param name = "prodWindow">The ProdWindow that contains this control.</param>
        /// <param name = "controlHandle">Window handle of the control</param>
        public ProdTreeView(ProdWindow prodWindow, IntPtr controlHandle)
            : base(prodWindow, controlHandle)
        {
        }

        #endregion

        /// <summary>
        /// Enumerates all nodes ion the TreeView and adds to a collection
        /// </summary>
        /// <param name="aeRoot">The root tree node.</param>
        private void EnumControlElements(AutomationElement aeRoot)
        {
            while (aeRoot != null)
            {
                AllNodes.Add(aeRoot);
                _chk++;
                int ret = ExpandCollapseHelper.Expand(aeRoot);
                if (ret == -1)
                {
                    ExpandCollapseHelper.Collapse(AllNodes[_treeIndex]);
                    aeRoot = TreeWalker.ControlViewWalker.GetNextSibling(AllNodes[_treeIndex]);
                    _treeIndex = _chk;
                }
                else
                {
                    aeRoot = TreeWalker.ControlViewWalker.GetFirstChild(aeRoot);
                }
                EnumControlElements(aeRoot);
                aeRoot = null;
            }

            return;
        }


        #region Selection Pattern

        /// <summary>Gets the selected TreeNodes index.</summary>
        /// <returns>The index of the selected node</returns>
        /// <exception cref="ProdOperationException"></exception>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetSelectedNodeIndex()
        {
            try
            {
                AutomationElement[] element = SelectionPatternHelper.GetSelection(ThisElement);
                int retVal = SelectionPatternHelper.FindIndexByItem(element[0]);

                Logmessage = retVal.ToString(CultureInfo.CurrentCulture);
                LogEntry();

                return retVal;
            }
            catch (InvalidOperationException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
            catch (ElementNotAvailableException err)
            {
                throw new ProdOperationException(err.Message, err);
            }
        }

        /// <summary>Gets the selected TreeNode.</summary>
        /// <returns>The selected node as an object</returns>
        /// <exception cref="ProdOperationException"></exception>
        /// <remarks>
        /// Return type kept as an object to provide flexibility in what type of control may be contained
        /// </remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public AutomationElement GetSelectedNode()
        {
            try
            {
                AutomationElement[] retVal = SelectionPatternHelper.GetSelection(ThisElement);

                Logmessage = retVal[0].Current.AutomationId;
                LogEntry();

                return retVal[0];
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>
        /// Selects the TreeNode with the desired index inside the parent tree.
        /// </summary>
        /// <param name="index">The desired nodes index.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectNode(int index)
        {
            Logmessage = "Index: " + index;

            try
            {
                SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement indexedItem = SelectionPatternHelper.FindItemByIndex(ThisElement, index);
                SelectionPatternHelper.Select(indexedItem);

            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>Selects the first TreeNode matching the desired text.</summary>
        /// <param name="itemText">The nodes text.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void SelectNode(string itemText)
        {
            Logmessage = "Item: " + itemText;

            try
            {
                SubscribeToEvent(SelectionItemPattern.ElementSelectedEvent);
                AutomationElement control = SelectionPatternHelper.FindItemByText(ThisElement, itemText);
                SelectionPatternHelper.Select(control);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>Selects the node based on a path.</summary>
        /// <param name="nodePath">The node path.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Maximum)]
        public void SelectNode(string[] nodePath)
        {
            Logmessage = "Node path";
            VerboseInformation = new List<object>(nodePath);
            LogEntry();

            foreach (string item in nodePath)
            {
                ExpandNode(item);
                SelectNode(item);
            }
        }

        #endregion

        #region ExpandCollapse Pattern

        /// <summary>Collapses all nodes.</summary>
        /// <param name="index">The index.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void CollapseNode(int index)
        {
            Logmessage = "Index: " + index;
            try
            {
                SubscribeToEvent(ExpandCollapsePattern.ExpandCollapseStateProperty);
                SelectNode(index);
                AutomationElement retVal = GetSelectedNode();
                ExpandCollapseHelper.Collapse(retVal);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>Collapses the node.</summary>
        /// <param name="itemText">The item text.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void CollapseNode(string itemText)
        {
            Logmessage = "Item: " + itemText;

            try
            {
                SubscribeToEvent(ExpandCollapsePattern.ExpandCollapseStateProperty);
                SelectNode(itemText);
                AutomationElement retVal = GetSelectedNode();
                ExpandCollapseHelper.Collapse(retVal);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>Expands all nodes.</summary>
        /// <param name="index">The index.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void ExpandNode(int index)
        {
            Logmessage = "Index: " + index;

            try
            {
                SubscribeToEvent(ExpandCollapsePattern.ExpandCollapseStateProperty);
                SelectNode(index);
                AutomationElement retVal = GetSelectedNode();
                ExpandCollapseHelper.Expand(retVal);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>Expands all nodes.</summary>
        /// <param name="itemText">The item text.</param>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public void ExpandNode(string itemText)
        {
            Logmessage = "Item: " + itemText;

            try
            {
                SubscribeToEvent(ExpandCollapsePattern.ExpandCollapseStateProperty);
                SelectNode(itemText);
                AutomationElement retVal = GetSelectedNode();
                ExpandCollapseHelper.Expand(retVal);
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        #endregion

        /// <summary>Gets the number of items in the tree</summary>
        /// <returns>The number of items in the tree</returns>
        /// <exception cref="ProdOperationException"></exception>
        /// <remarks>because nodes don't exist until</remarks>
        [ProdLogging(LoggingLevels.Prod, VerbositySupport = LoggingVerbosity.Minimum)]
        public int GetNodeCount()
        {
            try
            {
                int retVal = AllNodes.Count;

                Logmessage = "Count: " + retVal;
                LogEntry();

                return retVal;
            }
            catch (ProdOperationException err)
            {
                ProdLogger.LogException(err, ParentWindow.AttachedLoggers);
                throw;
            }
        }

        /// <summary>The Default invoke action.</summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public AutomationElement DefaultAction(int index)
        {
            return AllNodes[index];
        }


        //TODO: In Progress
//        private void SetNodeCheckState()
//        {
//            throw new NotImplementedException();
//        }


//        private void EditNodeText()
//        {
//            throw new NotImplementedException();
//        }


//        private void GetChildNodeCount()
//        {
//            throw new NotImplementedException();
//        }

    }
}