using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITest.Common;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITest.Common.UIMap;

namespace WindowCracker
{
    public partial class MainForm : Form
    {
        const string UITEST_FILENAME = @"/UIMap.uitest";
 
        private static Hashtable _windowList;
        private int _windowPid;       
        private StreamWriter sw;


        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnumerateWindows();
        }

        private void TvWindowList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NativeMethods.GetWindowThreadProcessId((IntPtr)e.Node.Tag, out _windowPid);
        }

        private void CmdBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Save Output Location",
                Filter = "Text File | *.txt",
                DefaultExt = ".txt"
            };

            DialogResult res = sfd.ShowDialog();
            if (res == DialogResult.Cancel && sfd.FileName == string.Empty) return;

            TxtOutput.Text = sfd.FileName;
        }

        private void TxtOutput_TextChanged(object sender, EventArgs e)
        {
            CmdCrawl.Enabled = TxtOutput.Text.Length > 0;
        }

        private void CmdCrawl_Click(object sender, EventArgs e)
        {
            sw = new StreamWriter(TxtOutput.Text);
            BeginCrack();
            sw.Close();
        }

        private void BeginCrack()
        {           
            UITest uiTest = InitializeTestLibs();
            GrabControls(uiTest);
        }

        private static UITest InitializeTestLibs()
        {
            UIMap newMap = new UIMap();
            
            Playback.Initialize();
            UITest uiTest = UITest.Create(Application.StartupPath + UITEST_FILENAME);
            
            newMap.Id = "UIMap";
            uiTest.Maps.Add(newMap);
            return uiTest;
        }

        private void GrabControls(UITest uiTest)
        {
            Process p = Process.GetProcessById(_windowPid);
            ApplicationUnderTest app = ApplicationUnderTest.FromProcess(p);
            GetAllChildren(app, uiTest.Maps[0]);
        }

        private void GetAllChildren(UITestControl uiTestControl, Microsoft.VisualStudio.TestTools.UITest.Common.UIMap.UIMap map)
        {
            foreach (UITestControl child in uiTestControl.GetChildren())
            {
                map.AddUIObject((IUITechnologyElement)child.GetProperty(UITestControl.PropertyNames.UITechnologyElement));
                PropertyExpressionCollection exp = child.SearchProperties;
                sw.WriteLine(">>> Type:" + child.ControlType + " Name: " + child.FriendlyName + " Class: " + child.ClassName + " Enabled: " + child.Enabled + " Technology Name:" + child.TechnologyName + " Name: " + child.BoundingRectangle);
                sw.Flush();
                child.DrawHighlight();
                GetAllChildren(child, map);
            }
        }

        private void EnumerateWindows()
        {
            _windowList = new Hashtable();
            NativeMethods.EnumWindows(EnumWindowsProc, IntPtr.Zero);
            foreach (DictionaryEntry de in _windowList)
            {
                TreeNode tn = new TreeNode { Text = de.Value.ToString(), Tag = de.Key };
                TvWindowList.Nodes.Add(tn);
            }
        }

        /// <summary>
        /// An application-defined callback function used with the EnumWindows or EnumDesktopWindows function.
        /// It receives top-level window handles
        /// </summary>
        /// <param name="windowHandle">A handle to a top-level window.</param>
        /// <param name="lParam">nothing in this case</param>
        /// <returns>
        /// To continue enumeration, the callback function must return TRUE;
        /// to stop enumeration, it must return FALSE
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

    }
}
