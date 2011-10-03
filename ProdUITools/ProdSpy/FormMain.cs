/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Automation;
using System.Windows.Forms;
using MapLib;
using ProdCodeGenerator;
using ProdSpy.Core;
using ProdSpy.Graph;
using ProdSpy.Properties;
using Point = System.Windows.Point;

namespace ProdSpy
{
    /// <summary>
    /// Form to spy on windows to get Prod Information
    /// </summary>
    public partial class FormMain : Form
    {
        //Todo: extract to settings
        private const int TimerDelay = 1000;
        private const int CollapsedSplitterWidth = 344;
        private const int ExpandedSplitterWidth = 544;
        private const int ExpandedSplitterDist = 218;

        /// <summary>
        /// Initializes the main form for the ProdUI Spy
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        #region Variables

        private FunctionBuilder _builder;
        private Timer _cursorTimer;

        private IntPtr _focusedApplicationHandle;
        private AutomationElement _focusedElement;
        private bool _isDown;
        private IntPtr _previousFocusedApplicationHandle = IntPtr.Zero;
        private GraphNode _selectedNode;

        MappedWindow _thisWindow;
        MappedControl _selectedControl;


        #endregion

        #region Events

        /// <summary>
        ///   Handles the Load event of the FormMain control.
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            InitBrowseIcon();
            SetGraphState();

            /* Set up the eye timer */
            _cursorTimer = new Timer();
            _cursorTimer.Tick += CursorTimer_Tick;
            _cursorTimer.Interval = TimerDelay;
        }

        private void InitBrowseIcon()
        {
            /* Browse Icon */
            Icon browseIcon = Icon.FromHandle(Cursors.SizeAll.Handle);
            LblCap.Image = browseIcon.ToBitmap();
            NativeMethods.DestroyIcon(browseIcon.Handle);
        }

        private void SetGraphState()
        {
            /* settings */
            GraphSplitter.Panel1Collapsed = Settings.Default.CollapseGraph;
            if (GraphSplitter.Panel1Collapsed)
            {
                Width = CollapsedSplitterWidth;
            }
            else
            {
                Width = ExpandedSplitterWidth;
                GraphSplitter.SplitterDistance = ExpandedSplitterDist;
            }
        }

        /// <summary>
        /// Loads control graph form
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TsGraph_Click(object sender, EventArgs e)
        {
            if (GraphSplitter.Panel1Collapsed)
            {
                GraphSplitter.Panel1Collapsed = false;
                Width = 544;
                GraphSplitter.SplitterDistance = 218;
                return;
            }
            GraphSplitter.Panel1Collapsed = true;
            Width = 344;
        }

        /// <summary>
        /// sets the forms "Topmost" property
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TsPin_Click(object sender, EventArgs e)
        {
            if (TopMost)
            {
                TopMost = false;
                return;
            }
            TopMost = true;
        }

        /// <summary>
        /// Highlights the control that is loaded into the Eye
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TsHighlight_Click(object sender, EventArgs e)
        {
            Painter.HighlightFocus(_focusedElement, _focusedApplicationHandle);
            return;
        }

        /// <summary>
        /// Using this to make sure all focus graphics are obliterated
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
        }

        /// <summary>
        /// Handles the Click event of the TsOptions control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TsOptions_Click(object sender, EventArgs e)
        {
            FormOptions frmOptions = new FormOptions();
            frmOptions.ShowDialog();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the RtbCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RtbCode_SelectionChanged(object sender, EventArgs e)
        {
            CtxCopy.Enabled = RtbCode.SelectedText.Length > 0;
        }

        /// <summary>
        /// Handles the Click event of the CtxCopy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtxCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RtbCode.SelectedText);
        }

        /// <summary>
        /// Begins the evaluation of windows
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void LblCap_MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;
            _cursorTimer.Start();
            Painter.SetState(true);

            LblCap.Visible = false;
            LblBegin.Enabled = false;

            TsHighlight.Enabled = false;
            TsInteractions.Enabled = false;
            TsGraph.Enabled = true;
            TvGraph.Nodes.Clear();
        }

        /// <summary>
        /// Ends the evaluation of windows
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void LblCap_MouseUp(object sender, MouseEventArgs e)
        {
            _isDown = false;
            _cursorTimer.Stop();

            Painter.SetState(false);

            LblCap.Visible = true;
            LblBegin.Enabled = true;

            TsHighlight.Enabled = true;

            SetInteractionMenu();

            //LoadGraph(_focusedElement);
            if (Settings.Default.AutoHighlight)
            {
                TsHighlight_Click(null, null);
            }
        }

        /// <summary>
        /// Handles checking window under cursor location
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CursorTimer_Tick(object sender, EventArgs e)
        {
            /* Cursor location */
            NativeMethods.POINT p;

            if (!_isDown)
            {
                return;
            }

            if (!NativeMethods.GetCursorPos(out p))
            {
                return;
            }

            TsCoords.Text = p.X + @", " + p.Y;
            Point cursorPoint = new Point(p.X, p.Y);

            /* control under cursor */
            _focusedElement = AutomationElement.FromPoint(cursorPoint);

            /* Get the handle to the main application of the control under focus */
            GetApplicationHandle();

            /* Make sure we're not examining ourselves */
            if (!VerifyContinue(_focusedApplicationHandle))
            {
                return;
            }

            /* See if this is a completely new or different window */
            CheckNewWindow();

            /* Get all of the (possibly different) focused controls specifics */
            ProcessTargetControl(_focusedElement);

            /* reassign */
            _previousFocusedApplicationHandle = _focusedApplicationHandle;

        }

        #endregion

        #region Control Info

        /// <summary>
        /// Gets the application handle of the focused window.
        /// </summary>
        private void GetApplicationHandle()
        {
            /* Get the main windows handle via the PID */
            int pid = _focusedElement.Current.ProcessId;
            Process pro = Process.GetProcessById(pid);
            _focusedApplicationHandle = pro.MainWindowHandle;
        }

        /// <summary>
        /// Checks if this is a completely new top level form.
        /// </summary>
        private void CheckNewWindow()
        {
            /* If this is a completely new top level form, reload the control tree */
            if (_previousFocusedApplicationHandle == _focusedApplicationHandle)
            {
                return;
            }
            _thisWindow = new MappedWindow(_focusedApplicationHandle);
            PropApplication.SelectedObject = _thisWindow;
        }

        /// <summary>
        /// Checks to see if cursor is inside this form
        /// </summary>
        /// <param name="thePHwnd">The handle to current ProdSpy instance.</param>
        /// <returns><c>true</c> if we should continue <c>false</c> if we're inside this window</returns>
        private bool VerifyContinue(IntPtr thePHwnd)
        {
            if (Handle != thePHwnd && thePHwnd != IntPtr.Zero)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Gets control information for .Net controls
        /// </summary>
        /// <param name="focusedElement">The focused element.</param>
        private void ProcessTargetControl(AutomationElement focusedElement)
        {
            TsInteractions.DropDownItems.Clear();

            foreach (MappedControl item in _thisWindow.AllFormsControls)
            {
                if (!Automation.Compare(item.AutoElement, focusedElement)) continue;
                PropControls.SelectedObject = item;
                _selectedControl = item;
                break;
            }

            Painter.PaintTarget(focusedElement, _focusedApplicationHandle);

            UpdateAutomationDisplay(focusedElement);
        }

        /// <summary>
        /// Updates the automation display.
        /// </summary>
        /// <param name="focusedElement">The focused element.</param>
        private void UpdateAutomationDisplay(AutomationElement focusedElement)
        {
            LstSupportedProperties.Items.Clear();
            LstSupportedPatterns.Items.Clear();

            foreach (AutomationPattern item in focusedElement.GetSupportedPatterns())
            {
                LstSupportedPatterns.Items.Add(item.ProgrammaticName);
            }

            foreach (AutomationProperty prop in focusedElement.GetSupportedProperties())
            {
                if (prop == null || ((prop.ProgrammaticName != null && String.IsNullOrEmpty(prop.ProgrammaticName))))
                {
                    continue;
                }

                LstSupportedProperties.Items.Add(prop.ProgrammaticName);
            }
        }

        #endregion

        #region Prod interactions menu

        /// <summary>
        /// Sets the interaction menu.
        /// </summary>
        private void SetInteractionMenu()
        {
            RtbCode.Clear();
            TsInteractions.DropDownItems.Clear();

            _builder = new FunctionBuilder(_focusedApplicationHandle, _selectedControl);

            FillToolStripItems();

            if (TsInteractions.DropDownItems.Count > 0)
            {
                TsInteractions.Enabled = true;
            }
        }

        /// <summary>
        /// Enumerates the MethodInfo array to put together interactions.
        /// </summary>
        private void FillToolStripItems()
        {
            if (_selectedControl.AvailableProdMethods == null) return;

            int i = 0;
            foreach (MethodInfo item in _selectedControl.AvailableProdMethods)
            {
                /* assigns the index of the methodinfo to the tag */
                ToolStripMenuItem it = new ToolStripMenuItem(item.Name) { Tag = i };

                if (item.GetParameters().Length > 1)
                {
                    it.ToolTipText = item.GetParameters()[1].ParameterType.ToString();
                }

                /* Attach handler */
                it.Click += ActionClick;

                /* Add menu item */
                TsInteractions.DropDownItems.Add(it);
                i++;
            }
        }

        /// <summary>
        /// Determines the action to be invoked when interactions menu is clicked
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ActionClick(object sender, EventArgs e)
        {
            /* Get the method to invoke */
            ToolStripMenuItem it = (ToolStripMenuItem)sender;
            /* get params and invoke */
            object[] args = _builder.BuildAction((int)it.Tag);

            /* Set up for template code gen */
            MethodInfo mi = _selectedControl.AvailableProdMethods[(int)it.Tag];
            ProdTextTemplate template = new ProdTextTemplate(mi, _thisWindow.ParentWindowTitle, _selectedControl.Name, string.Empty);
            TextGenerator gen = new TextGenerator();

            /* display code to invoke the methods */
            RtbCode.Enabled = true;
            RtbCode.Text = gen.GenerateProd(template, OutputLanguage.CSharp);
        }

        #endregion
    }
}