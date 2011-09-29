using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using ProdSessionConfiguration.Properties;
using ProdUI.Logging;


namespace ProdSessionConfiguration
{
    /// <summary>
    ///   Main form for the ProdSession configuration system
    /// </summary>
    public partial class MainForm : Form
    {
        #region Variables

        /* Constants */
        private const string SESSION_DIRTY = @"Session config changed";
        private const string FILE_SAVED = @"File Saved";

        /* ProdSession Values */
        private LoggingConfiguration _configuration;
        private string _currentFilename = string.Empty;
        private int _currentLoglevel;
        private int _currentVerbose;

        /* UI Stuff */
        private List<Label> _labels;
        StringCollection _mru;

        /* Flags */
        /// <summary>
        /// Indicates whether the form is in a file-load state.
        /// </summary>
        /// <remarks>Helps control event firing during this time</remarks>
        private bool _loading;

        /// <summary>
        /// Indicates whether there are unsaved changes to the UI
        /// </summary>
        private bool _isDirty;

        /// <summary>
        /// Indicates if form is in a state for editing an existing Logger
        /// </summary>
        private bool _inLogEdit;

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region Form loading

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _labels = new List<Label>(new[] { LblTimeExample, LblTypeExample, LblMethodExample, LblMessageExample });
            InitializeFormatExample();

            /* User may have no mru yet (hey...it happens) */
            if (Settings.Default.MRU == null)
            {
                return;
            }

            /* otherwise, load it in and set event handler */
            foreach (string item in Settings.Default.MRU)
            {
                TsRecentFiles.DropDownItems.Add(item, null, MruItem_Click);
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* check for unsaved changes */
            if (!_isDirty) return;
            DialogResult res = MessageBox.Show(@"Configuration file still has unsaved changes. Save Now?", @"Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            if (res == DialogResult.Yes)
            {
                TsSave_Click(null, null);
            }
        }

        /// <summary>
        /// Sets the DateTime string example label format.
        /// </summary>
        private void InitializeFormatExample()
        {
            DateTime now = DateTime.Now;
            string disp = now.ToString(TxtDateFormat.Text, CultureInfo.CurrentCulture);
            LblTimeExample.Text = disp;
            TblOutput.Left = (PnlLogOptions.ClientSize.Width - TblOutput.Width) / 2;
        }

        /// <summary>
        /// Adds the output string labels to the table.
        /// </summary>
        private void InitializeLogEntryLabels()
        {
            int i = 0;
            foreach (Label item in _labels)
            {
                TblOutput.Controls.Add(_labels[i], i, 0);
                TblOutput.Controls[i].Visible = true;
                TblOutput.Controls[i].BringToFront();
                i++;
            }
        }

        #endregion

        #region Main Menu

        /// <summary>
        /// Handles the Click event of the TsNewSession control, resetting the UI
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TsNewSession_Click(object sender, EventArgs e)
        {
            TsSaveAs_Click(null, null);
            ResetUI();
            SetLoggerPanelState(true);
            CmdAddLogger.Text = @"Add";
        }

        /// <summary>
        /// Handles the Click event of the TsOpen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TsOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Title = @"Open File", ValidateNames = true, Filter = @"Session configuration files (*.ses)|*.ses" };

            if (ofd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }


            if (ofd.FileName.Length == 0)
            {
                return;
            }


            /* so, we have a filename, rest the UI and load it in */
            ResetUI();
            ConfigFileOpen(ofd.FileName);
            //LoadLoggersIntoList();

            /* Enable some stuff */
            CmdAddLogger.Enabled = true;
            TsSaveAs.Enabled = true;
            TsSave.Enabled = true;
            PnlLoadedLoggers.Enabled = true;
            /* we're not dirty..we just loaded a new file in...really!  */
            SetFormClean();
            AddMru(ofd.FileName);
        }

        /// <summary>
        ///   Handles the Click event of the TsSave control.
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
        private void TsSave_Click(object sender, EventArgs e)
        {
            if ((_currentFilename != null && String.IsNullOrEmpty(_currentFilename)))
            {
                return;
            }

            if (!VerifyValidLogger()) return;

            if (_inLogEdit)
            {
                RemoveLogger(true);
                _configuration = SendUIToFile();
            }

            SaveConfig(_currentFilename, false);
            SetFormSaved();
            SetLoggerPanelState(false);
        }

        /// <summary>
        ///   Handles the Click event of the TsSaveAs control.
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
        private void TsSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = @"Save file as...",
                ValidateNames = true,
                DefaultExt = "ses",
                AddExtension = true,
                Filter = @"Session configuration files (*.ses)|*.ses"
            };

            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if (sfd.FileName.Length == 0)
            {
                return;
            }

            _currentFilename = sfd.FileName;
            SaveConfig(_currentFilename, true);
            //TsSave.Enabled = true;
            Text += @" - " + Path.GetFileNameWithoutExtension(_currentFilename);
            SetFormSaved();
        }

        /// <summary>Event handler for an MRU item click</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MruItem_Click(object sender, EventArgs e)
        {
            string mruFilename = ((ToolStripItem)sender).Text;
            LoadConfig(mruFilename);

            /* clear the UI and load the new file */
            ResetUI();
            ConfigFileOpen(mruFilename);
            //LoadLoggersIntoList();

            CmdAddLogger.Enabled = true;
            TsSaveAs.Enabled = true;
            TsSave.Enabled = true;
            PnlLoadedLoggers.Enabled = true;
            SetFormClean();
        }

        /// <summary>
        ///   Handles the Click event of the TsExit control.
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
        private void TsExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Control Events

        /* Session Values panel */

        /// <summary>
        /// Handles the TextChanged event of the TxtLoggerName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtLoggerName_TextChanged(object sender, EventArgs e)
        {
            CmdAddLogger.Enabled = TxtLoggerName.Text.Length > 0 && TxtDllPath.Text.Length > 0;
            SetFormDirty();
        }

        /* logger add/edit/delete buttons */

        /// <summary>Handles the Click event of the CmdAddLog control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdAddLogger_Click(object sender, EventArgs e)
        {

            if (CmdAddLogger.Text == @"Add")
            {
                if (_inLogEdit) 
                    EditLogger();
                else
                    AddLogger();
            }
            else
            {
                NewLogger();
            }

        }

        /// <summary>Handles the Click event of the CmdEdit control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdEditLogger_Click(object sender, EventArgs e)
        {
            if (CmdEditLogger.Text != Resources.CmdEdit_Caption) return;
            _inLogEdit = true;
            PnlLogOptions.Enabled = true;

            CmdEditLogger.Text = Resources.CmdEdit_Caption_Cancel;
            return;
        }

        /// <summary>Handles the Click event of the CmdRemoveLog control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdRemoveLogger_Click(object sender, EventArgs e)
        {
            RemoveLogger(true);
        }


        /*Logger name and dll path */

        /// <summary>Handles the Click event of the CmdBrowse control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks>This is used to browse for a valid ILogTarget dll</remarks>
        private void CmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Title = @"Open File", ValidateNames = true, Filter = @"Logger  (*.dll)|*.dll" };
            if (TxtDllPath.Text.Length > 0)
            {
                ofd.InitialDirectory = TxtDllPath.Tag.ToString();
                ofd.FileName = TxtDllPath.Text;
                ofd.RestoreDirectory = true;
            }
            if (ofd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if (ofd.FileName.Length == 0)
            {
                return;
            }


            /* Make sure this is a valid ILogTarget */
            bool valid = VerifyValidLoggerAssembly(ofd.FileName);
            if (!valid)
            {
                MessageBox.Show(@"This assembly is not a valid logger", @"Incompatible Logger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /* Fill in values. the tag will hold the complete path to the file, theile the box will be made to look pretty */
            TxtDllPath.Text = Path.GetFileName(ofd.FileName);
            TxtDllPath.Tag = ofd.FileName;

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the LstLoggers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LstLoggers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstLoggers.SelectedIndex == -1)
            {
                return;
            }

            SetSelectedLoggerUI();

            if (LstLoggers.SelectedIndex == -1) return;
            CmdEditLogger.Enabled = true;
            CmdRemoveLogger.Enabled = true;
        }


        /* Logging verbosity box */

        /// <summary>
        /// Keeps track of the Verbosities radio buttons.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Handles the Verbosity buttons CheckedChange Event
        /// </remarks>
        private void Verbosity_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            _currentVerbose = int.Parse(rdo.Tag.ToString(), CultureInfo.CurrentCulture);
            SetFormDirty();
        }


        /* Log Entry Format Box */

        /// <summary>
        /// Handles the ItemCheck event of the LstLogEntry control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// un-checking an item will remove that from the output string, checking adds it
        /// </remarks>
        private void LstLogEntry_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            object tst = LstLogEntry.SelectedItem;

            /* Note: This seems lame, but I can't think of a more stable way to do it */
            if (tst != null)
            {
                if ((string)tst == "LogTime")
                {
                    LblTimeExample.Visible = e.NewValue == CheckState.Checked;
                }
                if ((string)tst == "Calling Function")
                {
                    LblMethodExample.Visible = e.NewValue == CheckState.Checked;
                }
                if ((string)tst == "Message Level")
                {
                    LblTypeExample.Visible = e.NewValue == CheckState.Checked;
                }
                if ((string)tst == "Message Text")
                {
                    LblMessageExample.Visible = e.NewValue == CheckState.Checked;
                }
            }

            TblOutput.Left = (PnlLogOptions.ClientSize.Width - TblOutput.Width) / 2;
            SetFormDirty();
        }

        /// <summary>
        /// Handles the Click event of the CmdMoveUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Handles order and placement of output log string item
        /// </remarks>
        private void CmdMoveUp_Click(object sender, EventArgs e)
        {
            int newInd = LstLogEntry.SelectedIndex;
            object obj = LstLogEntry.SelectedItem;
            CheckState chk = LstLogEntry.GetItemCheckState(newInd);
            if (newInd <= 0)
            {
                return;
            }

            LstLogEntry.Items.RemoveAt(newInd);
            LstLogEntry.Items.Insert(newInd - 1, obj);
            LstLogEntry.SelectedIndex = newInd - 1;
            LstLogEntry.SetItemCheckState(LstLogEntry.SelectedIndex, chk);
            SetLogEntryItemsOrder();
            SetFormDirty();
        }

        /// <summary>
        /// Handles the Click event of the CmdMoveDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// ///
        /// <remarks>
        /// Handles order and placement of output log string item
        /// </remarks>
        private void CmdMoveDown_Click(object sender, EventArgs e)
        {
            int newInd = LstLogEntry.SelectedIndex;
            object obj = LstLogEntry.SelectedItem;
            CheckState chk = LstLogEntry.GetItemCheckState(newInd);

            if (newInd >= LstLogEntry.Items.Count - 1) return;
            LstLogEntry.Items.RemoveAt(newInd);
            LstLogEntry.Items.Insert(newInd + 1, obj);
            LstLogEntry.SelectedIndex = newInd + 1;
            LstLogEntry.SetItemCheckState(newInd + 1, chk);
            SetLogEntryItemsOrder();
            SetFormDirty();
        }

        /// <summary>
        /// Handles the TextChanged event of the TxtDateFormat control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Provides real-time feedback for any changes to the DataTime format string.
        /// <see cref="http://msdn.microsoft.com/en-us/library/az4se3k1.aspx"/>
        /// </remarks>
        private void TxtDateFormat_TextChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            try
            {
                string disp = now.ToString(TxtDateFormat.Text, CultureInfo.CurrentCulture);
                LblTimeExample.Text = disp;
                SetFormDirty();
            }
            catch (FormatException err)
            {
                MessageBox.Show(err.Message, @"Invalid Date Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtDateFormat.Text = @"T";
            }

        }


        /* Logging Level Box */

        /// <summary>
        /// Handles the Click event of the CmdDefault control, setting logging to its default level
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdDefault_Click(object sender, EventArgs e)
        {
            ChkErrors.Checked = true;
            ChkInfo.Checked = true;
            ChkProd.Checked = true;
            ChkWarn.Checked = false;
            _currentLoglevel = 13;
        }

        /// <summary>
        /// Handles the Click event of the CmdOff control, turning off all logging output
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdOff_Click(object sender, EventArgs e)
        {
            ChkErrors.Checked = false;
            ChkInfo.Checked = false;
            ChkProd.Checked = false;
            ChkWarn.Checked = false;
        }

        /// <summary>
        /// Keeps track of the LogLevel CheckBoxes
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// FHandles the LogLevel checkboxes CheckedChange Event
        /// </remarks>
        private void LevelCheckedChanged(object sender, EventArgs e)
        {
            /* Ignore event if session is loading into the form for the first time */
            if (_loading)
            {
                return;
            }


            CheckBox chk = (CheckBox)sender;

            /* Changed made, mark dirty */
            SetFormDirty();

            /* Build up the loglevel flag value */
            if (chk.Checked)
            {
                _currentLoglevel += int.Parse(chk.Tag.ToString(), CultureInfo.CurrentCulture);
                return;
            }
            _currentLoglevel -= int.Parse(chk.Tag.ToString(), CultureInfo.CurrentCulture);
        }

        #endregion

        #region Config file save functions

        /// <summary>
        /// Saves the configuration to the current filename.
        /// </summary>
        /// <param name="configFile">The config file.</param>
        /// <param name="loadUI">if set to <c>true</c> load ui elements into configuration, otherwise, dont add anything to config.</param>
        private void SaveConfig(string configFile, bool loadUI)
        {
            FileStream fs = null;

            /* If we're removing a logger, we won't read in the ui values */
            if (loadUI)
            {
                _configuration = SendUIToFile();
            }

            try
            {
                /* serialize to config file */
                fs = new FileStream(configFile, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(LoggingConfiguration));
                serializer.Serialize(fs, _configuration);

                SetFormClean();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// Loads the UI into a ProdSessionConfig object for serialization.
        /// </summary>
        /// <returns>
        /// a ProdSessionConfig object
        /// </returns>
        private LoggingConfiguration SendUIToFile()
        {
            if (_configuration == null)
            {
                _configuration = new LoggingConfiguration { LoggerParameters = new List<ProdLoggerParameters>() };
            }

            GetCurrentLoggersUI();
            return _configuration;
        }

        /// <summary>
        /// Gets the current logger stats from the UI.
        /// </summary>
        private void GetCurrentLoggersUI()
        {

            if (!VerifyValidLogger())
            {
                return;
            }

            if (_configuration == null)
                _configuration = new LoggingConfiguration();

            ProdLoggerParameters cfg = new ProdLoggerParameters();
            _configuration.LoggerParameters.Add(cfg);

            int index = _configuration.LoggerParameters.Count - 1;

            _configuration.LoggerParameters[index].LogFormat = GetCurrentLoggersOutputFormat();
            _configuration.LoggerParameters[index].LogDateFormat = TxtDateFormat.Text;
            _configuration.LoggerParameters[index].AssemblyPath = TxtDllPath.Text;
            _configuration.LoggerParameters[index].LoggerName = TxtLoggerName.Text;
            _configuration.LoggerParameters[index].LoggerType = Path.GetFileNameWithoutExtension(TxtDllPath.Text);
            _configuration.LoggerParameters[index].LogLevel = _currentLoglevel;
            _configuration.LoggerParameters[index].Verbosity = _currentVerbose;

            LstLoggers.Items.Add(TxtLoggerName.Text);

        }

        /// <summary>
        /// Verifies that the logger math and name TextBoxes contain values.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if valid. <c>false</c> otherwise
        /// </returns>
        private bool VerifyValidLogger()
        {
            if (TxtDllPath.Text.Length == 0)
            {
                return false;
            }

            if (TxtDateFormat.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the log output format from the UI and prepares it into a comma delimited string.
        /// </summary>
        /// <returns></returns>
        private string GetCurrentLoggersOutputFormat()
        {
            string retVal = string.Empty;

            foreach (object itemChecked in LstLogEntry.CheckedItems)
            {
                retVal += itemChecked + ",";
            }

            return retVal.TrimEnd(new[] { ',' });
        }

        #endregion

        #region Config file load functions

        /// <summary>
        /// Updates the program values upon a file open.
        /// </summary>
        /// <param name="filename">The filename.</param>
        private void ConfigFileOpen(string filename)
        {
            LoadConfig(filename);
            _currentFilename = filename;
            LoadFileIntoUI(_configuration);

            foreach (ProdLoggerParameters item in _configuration.LoggerParameters)
            {
                LstLoggers.Items.Add(item.LoggerName);
            }

            Text += @" - " + Path.GetFileNameWithoutExtension(_currentFilename);
            TsStatusLabel.Text = @"Loaded Config: " + Path.GetFileName(_currentFilename);
        }

        /// <summary>
        /// Deserializes a loaded config file.
        /// </summary>
        /// <param name="configFile">The config file.</param>
        private void LoadConfig(string configFile)
        {
            FileStream fs = null;
            _configuration = new LoggingConfiguration { LoggerParameters = new List<ProdLoggerParameters>() };

            try
            {
                fs = new FileStream(configFile, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(LoggingConfiguration));
                _configuration = (LoggingConfiguration)serializer.Deserialize(fs);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return;
        }

        /// <summary>
        /// Handles loading the ProdSessionConfig into the UI.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        private void LoadFileIntoUI(LoggingConfiguration configuration)
        {
            PnlLayout.Enabled = true;
        }

        /// <summary>
        /// Adds an item to the MRU if possible.
        /// </summary>
        /// <param name="filepath">The path of the file just opened.</param>
        private void AddMru(string filepath)
        {
            /* make sure the MRU is not empty, if so, create it */
            if (Settings.Default.MRU == null)
            {
                _mru = new StringCollection { filepath };
                Settings.Default.MRU = _mru;
                Settings.Default.Save();
                Settings.Default.Reload();
                TsRecentFiles.DropDownItems.Add(filepath, null, MruItem_Click);
                return;
            }

            /* check for dups, then add */
            if (Settings.Default.MRU.Contains(filepath)) return;
            Settings.Default.MRU.Add(filepath);
            Settings.Default.Save();
            Settings.Default.Reload();
            TsRecentFiles.DropDownItems.Add(filepath, null, MruItem_Click);
        }

        /* Loading a logger */

        /// <summary>
        /// Loads in the saved logger output.
        /// </summary>
        private void LoadLogEntryFormat()
        {
            string fmt = _configuration.LoggerParameters[LstLoggers.SelectedIndex].LogFormat;
            List<string> logFormats = new List<string>(fmt.Split(new[] { ',' }));

            LstLogEntry.ClearSelected();
            TblOutput.Controls.Clear();

            LoadLogEntryItems(logFormats);
            SetLogEntryItemsOrder();
        }

        /// <summary>
        /// Loads the checked log entry items into the listbox from the xml file.
        /// </summary>
        /// <param name="outputFormat">The output format.</param>
        private void LoadLogEntryItems(ICollection<string> outputFormat)
        {
            foreach (string item in outputFormat)
            {
                LstLogEntry.Items.Add(item, true);
                LoadLogEntryExampleLabels(item);
            }

            LoadUncheckedLogEntryItems(outputFormat);
        }

        /// <summary>
        /// Adds the LogEntry format items that have been exluded from the loggers xml file.
        /// </summary>
        /// <param name="outputFormat">The output format.</param>
        private void LoadUncheckedLogEntryItems(ICollection<string> outputFormat)
        {
            List<string> messages = new List<string>(new[] { "LogTime", "Message Level", "Calling Function", "Message Text" });
            foreach (string item in messages)
            {
                if (!outputFormat.Contains(item))
                {
                    LstLogEntry.Items.Add(item, false);
                }
            }
        }

        /// <summary>
        /// Organizes the output format labels into the saved order.
        /// </summary>
        /// <param name="outputFormat">The output format.</param>
        private void LoadLogEntryExampleLabels(string outputFormat)
        {

            if (outputFormat != null)
            {
                if (outputFormat.Trim() == "LogTime")
                {
                    LblTimeExample.Visible = true;
                }
                if (outputFormat.Trim() == "Calling Function")
                {
                    LblMethodExample.Visible = true;
                }
                if (outputFormat.Trim() == "Message Level")
                {
                    LblTypeExample.Visible = true;
                }
                if (outputFormat.Trim() == "Message Text")
                {
                    LblMessageExample.Visible = true;
                }
            }

            TblOutput.Left = ((groupBox2.ClientSize.Width - TblOutput.Width) / 2) + groupBox2.ClientSize.Width;
        }

        ///// <summary>
        ///// Loads the loggers into ListView.
        ///// </summary>
        //private void LoadLoggersIntoList()
        //{
        //    _isDirty = false;
        //    if (LstLoggers.Items.Count > 0)
        //    {
        //        LstLoggers.SelectedIndex = 0;
        //    }
        //}


        #endregion

        #region Logger Manipulation

        /// <summary>
        /// Sets UI Up for adding a new Logger
        /// </summary>
        private void NewLogger()
        {
            if (_configuration != null)
            {
                //ResetLoggerOptions();
                ResetUI();
                PnlLogOptions.Enabled = true;
            }
            SetLoggerPanelState(true);
            CmdAddLogger.Text = @"Add";
        }

        /// <summary>
        /// Adds a new logger to the configuration list.
        /// </summary>
        private void AddLogger()
        {
            if (!VerifyValidLogger())
            {
                TsStatusLabel.Text = @"Error: Invalid Logger";
                return;
            }
           // _configuration = SendUIToFile();
            _isDirty = true;
            SaveConfig(_currentFilename, true);
            /* Reset the text to indicate ability to add new logger */
            //SetLoggerPanelState(false);
            
            ResetUI();
            PnlLoadedLoggers.Enabled = true;
            PnlLogOptions.Enabled = true;
            TsSave.Enabled = true;
            CmdAddLogger.Enabled = true;

        }

        /// <summary>
        /// Verifies and stores changes to an existing logger in the configuration list
        /// </summary>
        /// <remarks>
        /// Operates in synch with item selected in ListBox
        /// </remarks>
        private void EditLogger()
        {
            /* lock logger UI and reset */
            _configuration = SendUIToFile();
            PnlLogOptions.Enabled = true;

            //_isDirty = true;

            /* Reset the text to indicate ability to add new logger */
            //CmdAddLogger.Text = @"Add";
           // TsStatusLabel.Text = @"Logger Added. Save file to commit";
        }

        /// <summary>
        /// Removes the selected logger from the configuration list.
        /// </summary>
        private void RemoveLogger(bool deleteFromList)
        {
            if (LstLoggers.SelectedIndex == -1) return;

            _configuration.LoggerParameters.RemoveAt(LstLoggers.SelectedIndex);

            if (!deleteFromList) return;
            LstLoggers.Items.RemoveAt(LstLoggers.SelectedIndex);
            TsStatusLabel.Text = @"Logger Removed. Save file to commit";

            if (LstLoggers.Items.Count > 0)
            {
                LstLoggers.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Fills any parameters needed by the selected logger into the ListView.
        /// </summary>
        /// <remarks>
        /// Since each implementation of ILogger has the possibility of needing custom parameters to function
        /// this will load them in
        /// </remarks>
        private void SetCustomLoggerParameters()
        {
            LvParams.Items.Clear();
            if (_configuration.LoggerParameters[LstLoggers.SelectedIndex].Parameters == null) return;
            foreach (ProdLoggerInputParameters item in _configuration.LoggerParameters[LstLoggers.SelectedIndex].Parameters)
            {
                ListViewItem it = new ListViewItem(item.ParamName);
                it.SubItems.Add(item.ParamValue.ToString());
                LvParams.Items.Add(it);
            }

        }

        /// <summary>
        /// Verifies that the logger assembly implements ILogTarget.
        /// </summary>
        /// <param name="filename">The file path to the logger dll to be added.</param>
        /// <returns>
        ///   <c>true</c> if this is a valid target. <c>false</c> otherwise
        /// </returns>
        private static bool VerifyValidLoggerAssembly(string filename)
        {
            Assembly logAsm = Assembly.LoadFile(filename);

            foreach (Type item in logAsm.GetTypes())
            {
                /* Run through any interfaces this logger may implement..we want the ILogTarget */
                Type[] iface = item.GetInterfaces();
                if (iface.Length == 0)
                {
                    return false;
                }


                foreach (Type t in iface)
                {
                    if (iface[0] != typeof(ILogTarget)) continue;

                    /* Create a temporary version of the logger to get any parameters */
                    ILogTarget tempLogger = (ILogTarget)Activator.CreateInstance(item);
                    /* Call the interface method to get info */
                    tempLogger.CallParameterForm();

                    return true;
                }
            }
            return false;
        }

        #endregion

        #region UI Manipulations

        /// <summary>
        /// Sets the UI to reflect the currently selected logger
        /// </summary>
        private void SetSelectedLoggerUI()
        {
            LstLogEntry.Items.Clear();
            LoadFileIntoUI(_configuration);
            _currentVerbose = _configuration.LoggerParameters[LstLoggers.SelectedIndex].Verbosity;
            SetLoggerVerbosityRadios();
            SetLoggerLevelCheckBoxes(_configuration.LoggerParameters[LstLoggers.SelectedIndex].LogLevel);
            TxtDateFormat.Text = _configuration.LoggerParameters[LstLoggers.SelectedIndex].LogDateFormat;
            TxtLoggerName.Text = _configuration.LoggerParameters[LstLoggers.SelectedIndex].LoggerName;
            TxtDllPath.Text = Path.GetFileName(_configuration.LoggerParameters[LstLoggers.SelectedIndex].AssemblyPath);
            TxtDllPath.Tag = _configuration.LoggerParameters[LstLoggers.SelectedIndex].AssemblyPath;
            _currentLoglevel = _configuration.LoggerParameters[LstLoggers.SelectedIndex].LogLevel;

            LoadLogEntryFormat();
            SetCustomLoggerParameters();
        }

        /// <summary>
        /// Sets the log level checkboxes.
        /// </summary>
        /// <param name="loglevel">The LogLevel for a logger.</param>
        private void SetLoggerLevelCheckBoxes(int loglevel)
        {
            /* set flag to inhibit CheckChanged events */
            _loading = true;

            /* Log Levels */
            ChkErrors.Checked = (int.Parse(ChkErrors.Tag.ToString(), CultureInfo.CurrentCulture) | loglevel) == loglevel;
            ChkInfo.Checked = (int.Parse(ChkInfo.Tag.ToString(), CultureInfo.CurrentCulture) | loglevel) == loglevel;
            ChkProd.Checked = (int.Parse(ChkProd.Tag.ToString(), CultureInfo.CurrentCulture) | loglevel) == loglevel;
            ChkWarn.Checked = (int.Parse(ChkWarn.Tag.ToString(), CultureInfo.CurrentCulture) | loglevel) == loglevel;
            _loading = false;
        }

        /// <summary>
        /// Sets the verbosity radios based on the loaded config file values.
        /// </summary>
        private void SetLoggerVerbosityRadios()
        {
            if (int.Parse(RdoMinimum.Tag.ToString(), CultureInfo.CurrentCulture) == _currentVerbose)
            {
                RdoMinimum.Checked = true;
                return;
            }
            RdoMaximum.Checked = true;
        }


        /// <summary>
        /// Resets the UI to its default state.
        /// </summary>
        private void ResetUI()
        {
            /* reset check boxes */
            SetDefaultLoggerOptions();
            InitializeLogEntryLabels();

            TblOutput.Left = (PnlLogOptions.ClientSize.Width - TblOutput.Width) / 2;
            SetFormClean();

            CmdAddLogger.Text = @"New";            
        }

        /// <summary>
        /// Sets the default logger options.
        /// </summary>
        private void SetDefaultLoggerOptions()
        {
            TxtDateFormat.Text = @"T";
            TxtLoggerName.Text = string.Empty;
            TxtDllPath.Text = string.Empty;
            ChkErrors.Checked = true;
            ChkInfo.Checked = true;
            ChkProd.Checked = true;
            ChkWarn.Checked = false;
        }

        private void SetLoggerPanelState(bool setEnabled)
        {
            PnlLoadedLoggers.Enabled = setEnabled;
            PnlLogOptions.Enabled = setEnabled;
        }


        /* runtime UI tracking */

        /// <summary>
        /// Sets the order log entry list items as they are moved up and down in the listbox.
        /// </summary>
        private void SetLogEntryItemsOrder()
        {
            int labelIndex = 0;
            foreach (object itemChecked in LstLogEntry.CheckedItems)
            {
                if (LstLogEntry.GetItemCheckState(LstLogEntry.Items.IndexOf(itemChecked)) == CheckState.Checked)
                {
                    labelIndex = SetLogEntryLabelVisibility(labelIndex, itemChecked);
                }
            }

            /* Center it */
            TblOutput.Left = ((groupBox2.ClientSize.Width - TblOutput.Width) / 2) + groupBox2.ClientSize.Width;
        }

        /// <summary>
        /// Sets the visibility of an output string label.
        /// </summary>
        /// <param name="labelIndex">The index to the label in the _labels list</param>
        /// <param name="itemChecked">Whether the item should be checked.</param>
        /// <returns>
        /// if its a valid label, labelIndex is incremented then sent back
        /// </returns>
        private int SetLogEntryLabelVisibility(int labelIndex, object itemChecked)
        {
            foreach (Label item in _labels)
            {
                if (item.Tag.ToString() != itemChecked.ToString()) continue;
                item.Visible = true;
                TblOutput.Controls.Add(item, labelIndex, 0);
                labelIndex++;
            }
            return labelIndex;
        }



        /* UI state */

        /// <summary>
        /// Sets the form after a successful file save
        /// </summary>
        private void SetFormSaved()
        {
            SetFormClean();
            TsStatusLabel.Text = FILE_SAVED;
            CmdEditLogger.Text = Resources.CmdEdit_Caption;

            if (LstLoggers.Items.Count > 0)
                LstLoggers.SelectedIndex = 0;
        }

        /// <summary>
        /// Central location to set the form as dirty and update StatusBar
        /// </summary>
        private void SetFormDirty()
        {
            if (!PnlLogOptions.Enabled) return;
            _isDirty = true;
            TsStatusLabel.Text = @"Logger configuration changed. Save file to commit changes";
        }

        /// <summary>
        /// Central location to mark the form clean and reset any flags;
        /// </summary>
        private void SetFormClean()
        {
            _isDirty = false;
            _inLogEdit = false;
            TsStatusLabel.Text = string.Empty;
        }


        ///// <summary>
        ///// Sets the output string labels to their default order and state.
        ///// </summary>
        //private void SetDefaultLogEntryFormatArea()
        //{
        //    if (LstLogEntry.Items.Count == 0)
        //    {
        //        LstLogEntry.Items.Add("LogTime", true);
        //        LstLogEntry.Items.Add("Message Level", true);
        //        LstLogEntry.Items.Add("Calling Function", true);
        //        LstLogEntry.Items.Add("Message Text", true);
        //    }

        //    InitializeLogEntryLabels();

        //    TblOutput.Left = (PnlLogOptions.ClientSize.Width - TblOutput.Width) / 2;
        //}


        ///// <summary>
        ///// Resets the UI for a fresh start.
        ///// </summary>
        //private void ResetUI()
        //{
        //    //GrpLogger.Enabled = true;
        //    TsSave.Enabled = false;

        //    InitializeFormatExample();
        //    InitializeLogEntryLabels();
        //    ResetLoggerOptions();
        //    ResetFileDefaults();

        //    LstLoggers.Items.Clear();
        //    _currentFilename = string.Empty;

        //    SetFormClean();
        //}

        ///// <summary>
        ///// Sets the defaults for the creation of a new file.
        ///// </summary>
        //private void ResetFileDefaults()
        //{
        //    _currentFilename = string.Empty;

        //    TsStatusLabel.Text = @"New File";
        //    PnlLogOptions.Enabled = false;
        //    TsSaveAs.Enabled = true;
        //    CmdAddLogger.Enabled = true;

        //    CmdDefault_Click(null, null);
        //    RdoMinimum.Checked = true;
        //    _currentVerbose = 1;
        //}


        #endregion



    }
}