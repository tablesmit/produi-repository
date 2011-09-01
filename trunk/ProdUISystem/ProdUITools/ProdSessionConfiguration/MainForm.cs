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
using ProdUI.Session;


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
        private ProdSessionConfig _configuration;
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
        private bool inLogEdit;

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
            DialogResult res = MessageBox.Show(@"Config file still has unsaved changes. Save Now?", @"Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

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
            ResetUI();
            ResetFileDefaults();
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

            if (!VerifyBeforeSave())
            {
                return;
            }

            if (inLogEdit)
                CmdRemoveLogger_Click(null, null);

            SaveConfig(_currentFilename, true);
            SetFormSaved();
            DisableLoggerPanel();
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
                Title = @"Save session as...",
                ValidateNames = true,
                FileName = TxtName.Text,
                DefaultExt = "xml",
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

            if (!VerifyBeforeSave())
            {
                return;
            }


            _currentFilename = sfd.FileName;
            SaveConfig(_currentFilename, true);
            TsSave.Enabled = true;
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

            /* clear the ui and load the new file */
            ResetUI();
            ConfigFileOpen(mruFilename);
            //LoadLoggersIntoList();

            CmdAddLogger.Enabled = true;
            TsSaveAs.Enabled = true;
            TsSave.Enabled = true;

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

        /// <summary>Handles the ValueChanged event of the NumTimeout control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void NumTimeout_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            TsStatusLabel.Text = SESSION_DIRTY;
        }

        /// <summary>Handles the TextChanged event of the TxtName control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            TsStatusLabel.Text = SESSION_DIRTY;
        }

        /// <summary>Handles the Click event of the CtxNewGuid control to provide a new Guid for the ID</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtxNewGuid_Click(object sender, EventArgs e)
        {
            TxtId.Text = Guid.NewGuid().ToString("N", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Handles the TextChanged event of the TxtLoggerName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtLoggerName_TextChanged(object sender, EventArgs e)
        {
            SetFormDirty();
        }

        /* logger add/edit/delete buttons */

        /// <summary>Handles the Click event of the CmdAddLog control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdAddLogger_Click(object sender, EventArgs e)
        {

            if (CmdAddLogger.Text == "Add")
            {
                EditLogger();
            }
            else
            {
                AddLogger();
            }

        }

        /// <summary>Handles the Click event of the CmdEdit control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdEditLogger_Click(object sender, EventArgs e)
        {
            if (CmdEditLogger.Text == Resources.CmdEdit_Caption)
            {
                inLogEdit = true;
                PnlLogOptions.Enabled = true;
                CmdAddLogger.Enabled = false;
                CmdEditLogger.Text = Resources.CmdEdit_Caption_Cancel;
                return;
            }
        }

        /// <summary>Handles the Click event of the CmdRemoveLog control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdRemoveLogger_Click(object sender, EventArgs e)
        {
            RemoveLogger();
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

            SetCurrentLoggersUI();

            if (LstLoggers.SelectedIndex == -1) return;
            CmdEditLogger.Enabled = true;
            CmdRemoveLogger.Enabled = true;
        }


        /* Logging verbosity box */

        /// <summary>Keeps track of the Verbosities radio buttons.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks>Handles the Verbosity buttons CheckedChange Event</remarks>
        private void Verbosity_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            _currentVerbose = int.Parse(rdo.Tag.ToString(), CultureInfo.CurrentCulture);
            SetFormDirty();
        }


        /* Log Entry Format Box */

        /// <summary>Handles the ItemCheck event of the LstLogEntry control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        /// <remarks>unchecking an item will remove that from the output string, checking adds it</remarks>
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

        /// <summary>Handles the Click event of the CmdMoveUp control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks>Handles order and placement of output log string item</remarks>
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

        /// <summary>Handles the Click event of the CmdMoveDown control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// /// <remarks>Handles order and placement of output log string item</remarks>
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

        /// <summary>Handles the TextChanged event of the TxtDateFormat control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <see cref="http://msdn.microsoft.com/en-us/library/az4se3k1.aspx"/>
        /// <remarks>
        /// Provides real-time feedback for any changes to the DataTime format string
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
        ///   Handles the Click event of the CmdDefault control, setting logging to its default level
        /// </summary>
        /// <param name = "sender">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
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
        ///   Keeps track of the LogLevel CheckBoxes
        /// </summary>
        /// <param name = "sender">The sender.</param>
        /// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
        /// <remarks>
        ///   FHandles the LogLevel checkboxes CheckedChange Event
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

        /// <summary>Saves the configuration to the current filename.</summary>
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
                /* serialixe to config file */
                fs = new FileStream(configFile, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(ProdSessionConfig));
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
        ///   Verifies that the options will generate a valid session before save.
        /// </summary>
        /// <returns></returns>
        private bool VerifyBeforeSave()
        {
            if (TxtId.Text.Length == 0)
            {
                MessageBox.Show(@"No Id provided", @"Cannot save config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (TxtName.Text.Length == 0)
            {
                MessageBox.Show(@"No session name provided", @"Cannot save config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        ///   Loads the UI into a ProdSessionConfig object for serialization.
        /// </summary>
        /// <returns>a ProdSessionConfig object</returns>
        private ProdSessionConfig SendUIToFile()
        {
            if (_configuration == null)
            {
                _configuration = new ProdSessionConfig { Loggers = new List<SessionLoggerConfig>() };
            }

            _configuration.SessionId = TxtId.Text;
            _configuration.SessionName = TxtName.Text;
            _configuration.EventTimeout = (int)NumTimeout.Value;
            GetCurrentLoggersUI();
            return _configuration;
        }

        /// <summary>Gets the current logger stats from the UI.</summary>
        private void GetCurrentLoggersUI()
        {

            if (!VerifyValidLogger())
            {
                return;
            }


            SessionLoggerConfig cfg = new SessionLoggerConfig();
            _configuration.Loggers.Add(cfg);
            int index = _configuration.Loggers.Count - 1;

            _configuration.Loggers[index].LogFormat = GetCurrentLoggersOutputFormat();
            _configuration.Loggers[index].LogDateFormat = TxtDateFormat.Text;
            _configuration.Loggers[index].AssemblyPath = TxtDllPath.Text;
            _configuration.Loggers[index].LoggerName = TxtLoggerName.Text;
            _configuration.Loggers[index].LoggerType = Path.GetFileNameWithoutExtension(TxtDllPath.Text);
            _configuration.Loggers[index].LogLevel = _currentLoglevel;
            _configuration.Loggers[index].Verbosity = _currentVerbose;

            LstLoggers.Items.Add(TxtLoggerName.Text);
        }

        /// <summary>Verifies that the logger math and name TextBoxes contain values.</summary>
        /// <returns><c>true</c> if valid. <c>false</c> otherwise</returns>
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

        /// <summary>Gets the log output format from the UI and prepares it into a comma delimited string.</summary>
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
            SetLoadedLoggersUI();
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
            _configuration = new ProdSessionConfig { Loggers = new List<SessionLoggerConfig>() };

            try
            {
                fs = new FileStream(configFile, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(ProdSessionConfig));
                _configuration = (ProdSessionConfig)serializer.Deserialize(fs);
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
        private void LoadFileIntoUI(ProdSessionConfig configuration)
        {
            PnlLayout.Enabled = true;
            TxtId.Text = configuration.SessionId;
            TxtName.Text = configuration.SessionName;
            NumTimeout.Value = configuration.EventTimeout;
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
            string fmt = _configuration.Loggers[LstLoggers.SelectedIndex].LogFormat;
            List<string> logFormats = new List<string>(fmt.Split(new[] { ',' }));

            LstLogEntry.ClearSelected();
            TblOutput.Controls.Clear();

            LoadLogEntryItems(logFormats);
            SetLogEntryItemsOrder();
        }

        /// <summary>
        /// Loads the checked log entry items intoi the listbox from the xml file.
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
            List<string> Messages = new List<string>(new[] { "LogTime", "Message Level", "Calling Function", "Message Text" });
            foreach (string item in Messages)
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

        #region Logger Configuration Panel

        private void AddLogger()
        {
            //TryAddLogger();
            if (_configuration == null)
            {
                MessageBox.Show(@"The session needs to be saved before adding a logger");
                TsSaveAs_Click(null, null);
            }

            ResetLoggerArea();
            ResetLogEntryFormatArea();
            PnlLogOptions.Enabled = true;
            CmdAddLogger.Text = "Add";
        }

        private void EditLogger()
        {
            TsSave_Click(null, null);

            /* lock logger UI and reset */
            ResetLoggerArea();
            ResetLogEntryFormatArea();
            PnlLogOptions.Enabled = false;
            _isDirty = false;
            /* Reset the text to indicate ability to add new logger */
            CmdAddLogger.Text = "New";
        }

        private void RemoveLogger()
        {
            if (LstLoggers.SelectedIndex == -1) return;

            _configuration.Loggers.RemoveAt(LstLoggers.SelectedIndex);
            LstLoggers.Items.RemoveAt(LstLoggers.SelectedIndex);
            SaveConfig(_currentFilename, false);
            TsStatusLabel.Text = @"Logger Removed. File Saved";

            if (LstLoggers.Items.Count > 0)
            {
                LstLoggers.SelectedIndex = 0;
            }
        }

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

        /// <summary>
        /// Sets the UI to reflect the currently selected logger
        /// </summary>
        private void SetCurrentLoggersUI()
        {
            LstLogEntry.Items.Clear();
            LoadFileIntoUI(_configuration);
            _currentVerbose = _configuration.Loggers[LstLoggers.SelectedIndex].Verbosity;
            SetLoggerVerbosityUI();
            SetLoggerLevelsUI(_configuration.Loggers[LstLoggers.SelectedIndex].LogLevel);
            TxtDateFormat.Text = _configuration.Loggers[LstLoggers.SelectedIndex].LogDateFormat;
            TxtLoggerName.Text = _configuration.Loggers[LstLoggers.SelectedIndex].LoggerName;
            TxtDllPath.Text = Path.GetFileName(_configuration.Loggers[LstLoggers.SelectedIndex].AssemblyPath);
            TxtDllPath.Tag = _configuration.Loggers[LstLoggers.SelectedIndex].AssemblyPath;
            _currentLoglevel = _configuration.Loggers[LstLoggers.SelectedIndex].LogLevel;

            LoadLogEntryFormat();
            SetCustomLoggerParameters();
        }

        /// <summary>
        /// Sets the output string labels to thier default order and state.
        /// </summary>
        private void ResetLogEntryFormatArea()
        {
            if (LstLogEntry.Items.Count == 0)
            {
                LstLogEntry.Items.Add("LogTime", true);
                LstLogEntry.Items.Add("Message Level", true);
                LstLogEntry.Items.Add("Calling Function", true);
                LstLogEntry.Items.Add("Message Text", true);
            }

            InitializeLogEntryLabels();

            TblOutput.Left = (PnlLogOptions.ClientSize.Width - TblOutput.Width) / 2;
        }

        /// <summary>
        /// Resets the just the logger config area.
        /// </summary>
        private void ResetLoggerArea()
        {
            TxtDateFormat.Text = @"T";
            TxtLoggerName.Text = string.Empty;
            TxtDllPath.Text = string.Empty;
            ChkErrors.Checked = true;
            ChkInfo.Checked = true;
            ChkProd.Checked = true;
            ChkWarn.Checked = false;

            ResetLogEntryFormatArea();
            DisableLoggerPanel();

        }

        /// <summary>
        /// Disables the logger panel and resets the "Edit" button
        /// </summary>
        private void DisableLoggerPanel()
        {
            inLogEdit = false;
            CmdEditLogger.Text = Resources.CmdEdit_Caption;
            CmdAddLogger.Enabled = true;
            PnlLogOptions.Enabled = false;
            SetFormClean();
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


                for (int i = 0; i < iface.Length; i++)
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
            if (_configuration.Loggers[LstLoggers.SelectedIndex].Parameters == null) return;
            foreach (LoggerParameters item in _configuration.Loggers[LstLoggers.SelectedIndex].Parameters)
            {
                ListViewItem it = new ListViewItem(item.ParamName);
                it.SubItems.Add(item.ParamValue.ToString());
                LvParams.Items.Add(it);
            }

        }

        /// <summary>
        /// Sets the loaded loggers names into the ListBox.
        /// </summary>
        private void SetLoadedLoggersUI()
        {
            foreach (SessionLoggerConfig item in _configuration.Loggers)
            {
                LstLoggers.Items.Add(item.LoggerName);
            }
        }

        /// <summary>
        /// Sets the log level checkboxes based on the loaded config file values.
        /// </summary>
        /// <param name="loglevel">The loglevel.</param>
        private void SetLoggerLevelsUI(int loglevel)
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
        private void SetLoggerVerbosityUI()
        {
            if (int.Parse(RdoMinimum.Tag.ToString(), CultureInfo.CurrentCulture) == _currentVerbose)
            {
                RdoMinimum.Checked = true;
                return;
            }
            RdoMaximum.Checked = true;
        }


        #endregion


        /* runtime UI tracking */

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
            TsStatusLabel.Text = @"Session config changed";
        }

        /// <summary>
        /// Central location to mark the form clean and reset any flags;
        /// </summary>
        private void SetFormClean()
        {
            _isDirty = false;
            inLogEdit = false;
            TsStatusLabel.Text = string.Empty;
        }


        /* Resetting the UI */

        /// <summary>
        /// Resets the UI for a fresh start.
        /// </summary>
        private void ResetUI()
        {
            GrpLogger.Enabled = true;
            PnlSessionValues.Enabled = true;
            TsSave.Enabled = false;

            InitializeFormatExample();
            InitializeLogEntryLabels();
            ResetLoggerArea();
            ResetFileDefaults();

            TxtId.Text = string.Empty;
            TxtName.Text = string.Empty;
            LstLoggers.Items.Clear();
            _currentFilename = string.Empty;

            SetFormClean();
        }

        /// <summary>
        /// Sets the defaults for the creation of a new file.
        /// </summary>
        private void ResetFileDefaults()
        {
            string id = Guid.NewGuid().ToString("N", CultureInfo.CurrentCulture);
            TxtId.Text = id;
            TxtName.Text = id;

            _currentFilename = string.Empty;

            TsStatusLabel.Text = @"New File";
            PnlLogOptions.Enabled = false;
            TsSaveAs.Enabled = true;
            CmdAddLogger.Enabled = true;

            CmdDefault_Click(null, null);
            RdoMinimum.Checked = true;
            _currentVerbose = 1;
        }

    }
}