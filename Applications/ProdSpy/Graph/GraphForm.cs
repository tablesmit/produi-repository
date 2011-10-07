// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Windows.Automation;
using System.Windows.Forms;
using ProdSpy.Core;
using ProdSpy.Graph;
using ProdSpy.Properties;

namespace ProdSpy
{
    partial class FormMain
    {
        #region Control Graph Panel

        private GraphNode _nde;

        /// <summary>
        /// Handles the AfterSelect event of the TvGraph control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        private void TvGraph_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _nde = (GraphNode)TvGraph.SelectedNode;

            RtbTip.Text = _nde.ToString();

            /* If control doesn't have a handle, it cant be highlighted */
            CtxHighlight.Enabled = !_nde.NodeCtrlHandle.Equals("0");

            if (Settings.Default.UpdateNode)
            {
                ProcessTargetControl(_nde.NodeElement);
            }

            if (Settings.Default.HighlightNode)
            {
                CtxHighlight_Click();
            }
        }

        /// <summary>
        /// Fills TreeView with focused control as root
        /// </summary>
        /// <param name="control">The UI Automation control.</param>
        public void LoadGraph(AutomationElement control)
        {
            if (control == null || _focusedApplicationHandle == IntPtr.Zero)
            {
                return;
            }

            try
            {
                _focusedElement = control;

                AutomationElement rootElement = AutomationElement.FromHandle(_focusedApplicationHandle);

                TvGraph.BeginUpdate();
                AddGraphNode(rootElement);

                /* show the node representing the selected control */
                TvGraph.SelectedNode = _selectedNode;
                TvGraph.TopNode = _selectedNode;
                TvGraph.EndUpdate();
            }
            catch (ElementNotAvailableException)
            {
                MessageBox.Show(Resources.WindowNotAvail, Resources.Invalid_Window, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        /// <summary>
        /// Adds the graph node.
        /// </summary>
        /// <param name="rootElement">The root element.</param>
        private void AddGraphNode(AutomationElement rootElement)
        {
            if (rootElement == null) return;

            string showString = rootElement.Current.LocalizedControlType + " [ " + rootElement.Current.AutomationId + " ]";

            GraphNode tn = new GraphNode(rootElement)
            {
                Text = showString,
                Tag = rootElement.Current.NativeWindowHandle,
                ImageIndex = 2
            };

            WalkControlElements(rootElement, tn);
            TvGraph.Nodes.Add(tn);
            TvGraph.ExpandAll();
        }

        /// <summary>
        /// Build the tree nodes
        /// </summary>
        /// <param name="aeRoot">root control node to parse from</param>
        /// <param name="treeNode">GraphNode info</param>
        private void WalkControlElements(AutomationElement aeRoot, TreeNode treeNode)
        {
            AutomationElement aeNode = TreeWalker.RawViewWalker.GetFirstChild(aeRoot);

            while (aeNode != null)
            {
                string showString = aeNode.Current.LocalizedControlType + " [ " + aeNode.Current.AutomationId + " ]";
                GraphNode childTreeNode = new GraphNode(aeNode)
                {
                    Text = showString,
                    Tag = aeNode.Current.NativeWindowHandle
                };

                treeNode.Nodes.Add(childTreeNode);

                /* See if this is the selected control */
                if (aeNode.Current.NativeWindowHandle == _focusedElement.Current.NativeWindowHandle)
                {
                    _selectedNode = childTreeNode;
                }

                WalkControlElements(aeNode, childTreeNode);
                aeNode = TreeWalker.RawViewWalker.GetNextSibling(aeNode);
            }
        }

        /// <summary>
        /// Handles the Click event of the CtxHighlight control.
        /// </summary>
        private void CtxHighlight_Click()
        {
            GraphNode gn = (GraphNode)TvGraph.SelectedNode;
            //int tmpParse = int.Parse(gn.NodeElement);
            //.WipeWindow((IntPtr) tmpParse);
            Painter.HighlightFocus(gn.NodeElement, _focusedApplicationHandle);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _nde.NodeCtrlId + " \nName: " + _nde.NodeCtrlCaption + "\nType: " + _nde.NodeCtrlType + "\nClass: " + _nde.NodeCtrlClass + " \nHandle: " + _nde.NodeCtrlHandle;
        }

        #endregion Control Graph Panel
    }
}