// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using MapLib;
using WinMap.Properties;

namespace WinMap
{
    /// <summary>
    ///   Main form for the WinMap application
    /// </summary>
    public partial class MainForm : Form
    {
        private static Hashtable _windowList;
        private SortOrder _currentSortOrder = SortOrder.Ascending;
        private MappedWindow _scannedTree;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "MainForm" /> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   An application-defined callback function used with the EnumWindows or EnumDesktopWindows function.
        ///   It receives top-level window handles
        /// </summary>
        /// <param name = "windowHandle">A handle to a top-level window.</param>
        /// <param name = "lParam">nothing in this case</param>
        /// <returns>
        ///   To continue enumeration, the callback function must return TRUE;
        ///   to stop enumeration, it must return FALSE
        /// </returns>
        internal static bool EnumWindowsProc(IntPtr windowHandle, int lParam)
        {
            StringBuilder winText = new StringBuilder(256);
            if (!NativeMethods.IsWindowVisible(windowHandle))
            {
                return true;
            }
            if (NativeMethods.GetWindowText(windowHandle, winText, winText.Capacity) == 0)
            {
                return true;
            }

            if (winText.Length > 0)
            {
                _windowList.Add(windowHandle, winText.ToString());
            }
            return true;
        }

        /* File */

        private void TsOpenMap_Click(object sender, EventArgs e)
        {
            string filename = OpenMap();
            if (filename.Length == 0)
            {
                return;
            }

            FillTree(filename);
            TsSaveWindow.Enabled = true;
        }

        private static string OpenMap()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = Resources.OpenMapforcomparison,
                Filter = @"XML Files (*.xml)|*.xml",
            };

            DialogResult res = ofd.ShowDialog();

            if (res != DialogResult.OK)
            {
                return string.Empty;
            }

            return ofd.FileName;
        }

        private void TsSaveWindow_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = Resources.SaveMapAs,
                DefaultExt = "xml",
                Filter = @"XML Files (*.xml)|*.xml",
                OverwritePrompt = true,
                AddExtension = true
            };

            DialogResult res = sfd.ShowDialog();

            if (res != DialogResult.OK || sfd.FileName.Length == 0)
            {
                return;
            }

            _scannedTree.SaveMap(sfd.FileName);
            sfd.Dispose();
        }

        /* scan */

        private void TsGetWindows_Click(object sender, EventArgs e)
        {
            TvWindowList.Nodes.Clear();
            TsCompare.Enabled = false;
            CtxCompare.Enabled = false;
            EnumerateWindows();
        }

        private void TsCrawl_Click(object sender, EventArgs e)
        {
            IntPtr newHand = (IntPtr)TvWindowList.SelectedNode.Tag;
            TsLoadedForm.Text = TvWindowList.SelectedNode.Text;
            _scannedTree = new MappedWindow(newHand);

            LoadControlSpecs();
            TsCompare.Enabled = true;
            TsSaveWindow.Enabled = true;
        }

        private void FillTree(string filename)
        {
            _scannedTree = new MappedWindow();
            _scannedTree = _scannedTree.LoadMap(filename);
            LoadControlSpecs();
            TsCompare.Enabled = true;
            CtxCompare.Enabled = true;
        }

        private void TvWindowList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TsCrawl.Enabled = TvWindowList.SelectedNode != null;
            CtxMapWindow.Enabled = TvWindowList.SelectedNode != null;
        }

        private void TsCompare_Click(object sender, EventArgs e)
        {
            string filename = OpenMap();
            if (filename.Length == 0)
            {
                return;
            }

            GetWindowScore(filename);
        }

        private void EnumerateWindows()
        {
            _windowList = new Hashtable();
            NativeMethods.EnumWindows(EnumWindowsProc, IntPtr.Zero);
            foreach (DictionaryEntry de in _windowList)
            {
                TreeNode tn = new TreeNode
                {
                    Text = de.Value.ToString(),
                    Tag = de.Key
                };
                TvWindowList.Nodes.Add(tn);
            }
        }

        private void LoadControlSpecs()
        {
            LvControls.Items.Clear();
            foreach (MappedControl ctrl in _scannedTree.AllFormsControls)
            {
                ListViewItem lvi = new ListViewItem
                {
                    Text = ctrl.CustomId,
                };
                AddItems(ctrl, lvi);
                LvControls.Items.Add(lvi);
            }

            LvControls.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private static void AddItems(MappedControl ctrl, ListViewItem lvi)
        {
            lvi.SubItems.Add(ctrl.AutomationId);
            lvi.SubItems.Add(ctrl.Name);
            lvi.SubItems.Add(ctrl.ControlType);
            lvi.SubItems.Add(ctrl.ClassName);
            lvi.SubItems.Add(ctrl.HelpText);
            lvi.SubItems.Add(ctrl.AcceleratorKey);
            lvi.SubItems.Add(ctrl.AccessKey);
            lvi.SubItems.Add(ctrl.LabeledBy);
            lvi.SubItems.Add(ctrl.ControlTreePosition.ToString(CultureInfo.CurrentCulture));
            lvi.SubItems.Add(ctrl.ItemType);
        }

        private void GetWindowScore(string fileName)
        {
            int x = 0;
            ArrayList scores = new ArrayList();
            MappedWindow windowFromFile = new MappedWindow();
            windowFromFile = windowFromFile.LoadMap(fileName);

            foreach (MappedControl item in _scannedTree.AllFormsControls)
            {
                if (x >= windowFromFile.AllFormsControls.Count)
                {
                    break;
                }

                List<CompareResult> score = item.CompareTo(windowFromFile.AllFormsControls[x]);
                scores.Add(score);
                x++;
            }
            SetResults(scores, windowFromFile);
        }

        private static void SetResults(ArrayList results, MappedWindow loadedWin)
        {
            ResultsForm frm = new ResultsForm
            {
                Results = results,
                LoadedWindow = loadedWin
            };
            frm.ShowDialog();
        }

        private void LvControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctxAssignName.Enabled = LvControls.SelectedItems.Count > 0;
        }

        private void ctxAssignName_Click(object sender, EventArgs e)
        {
            CustomIdForm idFrm = new CustomIdForm();
            DialogResult res = idFrm.ShowDialog();

            if (res == DialogResult.Cancel || idFrm.Id.Length == 0)
            {
                return;
            }

            LvControls.SelectedItems[0].Text = idFrm.Id;
            _scannedTree.AllFormsControls[LvControls.SelectedItems[0].Index].CustomId = idFrm.Id;
        }

        private void LvControls_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (_currentSortOrder == SortOrder.Ascending)
                _currentSortOrder = SortOrder.Descending;
            else
                _currentSortOrder = SortOrder.Ascending;

            ItemSorter it = new ItemSorter(e.Column, _currentSortOrder);
            LvControls.ListViewItemSorter = it;
            LvControls.Sort();
            TsSortOrder.Text = @"Sorted Column: " + LvControls.Columns[e.Column].Text + @"               Order:" + _currentSortOrder;
        }
    }

    #region ItemSorter inner class

    internal class ItemSorter : IComparer
    {
        private readonly int _column;
        private readonly SortOrder _sortOrder;

        public ItemSorter(int column, SortOrder sortOrder)
        {
            _column = column;
            _sortOrder = sortOrder;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            ListViewItem itemX = (ListViewItem)x;
            ListViewItem itemY = (ListViewItem)y;
            CaseInsensitiveComparer objectCompare = new CaseInsensitiveComparer();

            int res = objectCompare.Compare(itemX.SubItems[_column].Text, itemY.SubItems[_column].Text);

            if (_sortOrder == SortOrder.Ascending)
            {
                return res;
            }
            return (-res);
        }

        #endregion IComparer Members
    }

    #endregion ItemSorter inner class
}