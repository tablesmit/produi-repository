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

        private GraphNode _Nde;

        /// <summary>
        /// Handles the AfterSelect event of the TvGraph control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        private void TvGraph_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _Nde = (GraphNode)TvGraph.SelectedNode;

            RtbTip.Text = _Nde.ToString();


            /* If control doesn't have a handle, it cant be highlighted */
            CtxHighlight.Enabled = !_Nde.NodeCtrlHandle.Equals("0");

            if (Settings.Default.UpdateNode)
            {
                ProcessTargetControl(_Nde.NodeElement);
            }

            if (Settings.Default.HighlightNode)
            {
                CtxHighlight_Click(null, null);
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

            GraphNode tn = new GraphNode(rootElement) { Text = showString, Tag = rootElement.Current.NativeWindowHandle, ImageIndex = 2 };

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
        /// Handles the Click event of the CtxHighlight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtxHighlight_Click(object sender, EventArgs e)
        {
            GraphNode gn = (GraphNode)TvGraph.SelectedNode;
            //int tmpParse = int.Parse(gn.NodeElement);
            //.WipeWindow((IntPtr) tmpParse);
            Painter.HighlightFocus(gn.NodeElement, _focusedApplicationHandle);
        }

        /// <summary>
        /// Handles the Click event of the CtxTextReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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
        /// Handles the Click event of the CtxExcelReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtxExcelReport_Click(object sender, EventArgs e)
        {
            GraphNode gn = (GraphNode)TvGraph.Nodes[0];
            ExcelReport report = new ExcelReport(gn);
            report.Create();
        }

        /// <summary>
        /// Handles the Click event of the CtxHTMLReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _Nde.NodeCtrlId + " \nName: " + _Nde.NodeCtrlCaption + "\nType: " + _Nde.NodeCtrlType + "\nClass: " + _Nde.NodeCtrlClass + " \nHandle: " + _Nde.NodeCtrlHandle;
        }

        #endregion
    }
}

