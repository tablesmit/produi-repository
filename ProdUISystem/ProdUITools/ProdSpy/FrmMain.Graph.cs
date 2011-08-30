﻿/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;
using System.Windows.Automation;
using System.Windows.Forms;
using ProdSpy.Graph;
using ProdSpy.Properties;

namespace ProdSpy
{
    partial class FormMain
    {
        #region Control Graph Panel

        private GraphNode _node;

        /// <summary>
        ///   Handles the AfterSelect event of the TvGraph control.
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.Windows.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
        private void TvGraph_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _node = (GraphNode)TvGraph.SelectedNode;

            RtbTip.Text = _node.ToString();


            /* If control doesn't have a handle, it cant be highlighted */
            CtxHighlight.Enabled = !_node.NodeCtrlHandle.Equals("0", StringComparison.CurrentCulture);

            if (Settings.Default.UpdateNode)
            {
                ProcessTargetControl(_node.NodeElement);
            }

            if (Settings.Default.HighlightNode)
            {
                CtxHighlight_Click(null, null);
            }
        }

        /// <summary>
        ///   init for filling TreeView with focused control as root
        /// </summary>
        /// <param name = "control">The UI Automation control.</param>
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
        ///   Adds the graph node.
        /// </summary>
        /// <param name = "rootElement">The root element.</param>
        private void AddGraphNode(AutomationElement rootElement)
        {
            if (rootElement == null)
            {
                return;
            }

            string showString = rootElement.Current.LocalizedControlType + " [ " + rootElement.Current.AutomationId + " ]";

            GraphNode tn = new GraphNode(rootElement) { Text = showString, Tag = rootElement.Current.NativeWindowHandle, ImageIndex = 2 };

            WalkControlElements(rootElement, tn);
            TvGraph.Nodes.Add(tn);
            TvGraph.ExpandAll();
        }

        /// <summary>
        ///   Build the tree nodes
        /// </summary>
        /// <param name = "aeRoot">root control node to parse from</param>
        /// <param name = "treeNode">GraphNode info</param>
        private void WalkControlElements(AutomationElement aeRoot, TreeNode treeNode)
        {
            AutomationElement aeNode = TreeWalker.RawViewWalker.GetFirstChild(aeRoot);

            while (aeNode != null)
            {
                string showString = aeNode.Current.LocalizedControlType + " [ " + aeNode.Current.AutomationId + " ]";
                GraphNode childTreeNode = new GraphNode(aeNode) { Text = showString, Tag = aeNode.Current.NativeWindowHandle };

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
        ///   Handles the Click event of the CtxHighlight control.
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
        private void CtxHighlight_Click(object sender, EventArgs e)
        {
            GraphNode gn = (GraphNode)TvGraph.SelectedNode;
            Painter.HighlightFocus(gn.NodeElement, _focusedApplicationHandle);
        }

        /// <summary>
        ///   Handles the Click event of the CtxTextReport control.
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
        private void CtxTextReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Title = Resources.SaveReportTitle, Filter = @"Text files (*.txt)|*.txt|All files (*.*)|*.* " };
            sfd.ShowDialog();
            if (sfd.FileName.Length == 0)
            {
                return;
            }
            GraphNode gn = (GraphNode)TvGraph.Nodes[0];
            TextReport report = new TextReport(gn, sfd.FileName);
            report.Create();
        }

        /// <summary>
        ///   Handles the Click event of the CtxExcelReport control.
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
        private void CtxExcelReport_Click(object sender, EventArgs e)
        {
            GraphNode gn = (GraphNode)TvGraph.Nodes[0];
            ExcelReport report = new ExcelReport(gn);
            report.Create();
        }

        /// <summary>
        ///   Handles the Click event of the CtxHTMLReport control.
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
        private void CtxHTMLReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Title = Resources.SaveReportTitle, Filter = @"HTML files (*.htm)|*.htm|All files (*.*)|*.* " };
            sfd.ShowDialog();
            if (sfd.FileName.Length == 0)
            {
                return;
            }
            GraphNode gn = (GraphNode)TvGraph.Nodes[0];
            HtmlReport report = new HtmlReport(gn, sfd.FileName);
            report.Create();
        }

        /// <summary>
        /// Toes the string.	
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public override string ToString()
        {
            return _node.NodeCtrlId + " \nName: " + _node.NodeCtrlCaption + "\nType: " + _node.NodeCtrlType + "\nClass: " + _node.NodeCtrlClass + " \nHandle: " + _node.NodeCtrlHandle;
        }

        #endregion
    }
}