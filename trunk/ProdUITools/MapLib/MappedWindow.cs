/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Automation;
using System.Xml.Serialization;


namespace MapLib
{
    /// <summary>
    ///   Stores the target windows control tree
    /// </summary>
    [XmlRoot("MappedWindow")]
    public class MappedWindow
    {
        #region Varables and Properties

        private int _controlCounter;
        private Type[] _extraTypes;
        internal Type[] ProdUiTypes;
        private IntPtr _mainHandle;
        private XmlSerializer _serializer;
        private Thread _treeThread;


        /// <summary>
        /// Gets or sets the parent module.
        /// </summary>
        /// <value>
        /// The parent module.
        /// </value>
        [XmlAttribute("Path")]
        [CategoryAttribute("Application"), ReadOnlyAttribute(true), DisplayName(@"Executable File"), Description("Path to main executable")]
        public string ParentModule { get; set; }

        /// <summary>
        /// Gets or sets all MappedControls on the form.
        /// </summary>
        /// <value>
        /// All forms controls.
        /// </value>
        [XmlElement("MappedControl")]
        [Browsable(false)]
        public Collection<MappedControl> AllFormsControls { get; set; }

        #endregion

        #region Grid Properties

        /// <summary>
        /// Gets or sets the parent window title.
        /// </summary>
        /// <value>
        /// The parent window title.
        /// </value>
        [XmlIgnore]
        [Category("Application"), ReadOnlyAttribute(true), DisplayName(@"Parent Title"), Description("Title of parent window")]
        public string ParentWindowTitle { get; private set; }

        /// <summary>
        /// Gets the process id.
        /// </summary>
        [XmlIgnore, CategoryAttribute("Application"), ReadOnlyAttribute(true), DisplayName(@"Process ID"), Description("System Process ID")]
        public int ProcessId { get; private set; }

        /// <summary>
        /// Gets or sets the type of the application.
        /// </summary>
        /// <value>
        /// The type of the application.
        /// </value>
        [XmlIgnore]
        [CategoryAttribute("Application"), ReadOnlyAttribute(true), DisplayName(@"Application Type"), Description("Win32 (native) or .Net")]
        public string ApplicationType { get; set; }

        /// <summary>
        /// Gets or sets the application handle.
        /// </summary>
        /// <value>
        /// The application handle.
        /// </value>
        [XmlIgnore]
        [CategoryAttribute("Application"), ReadOnlyAttribute(true), DisplayName(@"Application Handle"), Description("Win32 (native) or .Net")]
        public IntPtr ApplicationHandle { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MappedWindow"/> class.
        /// </summary>
        /// <param name="mainWindowHandle">The main window handle.</param>
        public MappedWindow(IntPtr mainWindowHandle)
        {
            /* break over to process */
            AllFormsControls = new Collection<MappedControl>();
            _extraTypes = new[] { typeof(MappedControl) };
            _serializer = new XmlSerializer(typeof(MappedWindow), _extraTypes);
            LoadProdTypes();

            /* Automation info stuff */
            AutomationElement mainForm = AutomationElement.FromHandle(mainWindowHandle);
            GetProcessInformation(mainForm);

            LoadControlTree(mainWindowHandle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappedWindow"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to load a serialized map.
        /// </remarks>
        public MappedWindow()
        {
            /* break over to process */
            AllFormsControls = new Collection<MappedControl>();
            _extraTypes = new[] { typeof(MappedControl) };
            _serializer = new XmlSerializer(typeof(MappedWindow), _extraTypes);
            LoadProdTypes();
        }

        /// <summary>
        /// Loads the control tree and enumerates the tree.
        /// </summary>
        /// <param name="data">The handle to the main window.</param>
        public void LoadControlTree(object data)
        {
            _mainHandle = (IntPtr)data;

            if ((int)_mainHandle == 0)
            {
                return;
            }

            _treeThread = new Thread(FillTree) { IsBackground = true };
            _treeThread.Start();
            _treeThread.Join();
        }

        /// <summary>
        /// Serializes a MappedWindow to a file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void SaveMap(string filePath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Create);
                _serializer.Serialize(fs, this);
            }
            finally
            {
                if (fs != null) fs.Dispose();
            }
        }

        /// <summary>
        /// Deserializes a saved map.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        /// The deserialized MappedWindow
        /// </returns>
        public MappedWindow LoadMap(string filePath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Open);
                MappedWindow window = (MappedWindow)_serializer.Deserialize(fs);
                return window;
            }
            finally
            {
                if (fs != null) fs.Dispose();
            }


        }

        private void FillTree()
        {
            AutomationElement root = AutomationElement.FromHandle(_mainHandle);

            EnumControlElements(root);
        }

        /// <summary>
        /// Enums the control elements.
        /// </summary>
        /// <param name="aeRoot">The ae root.</param>
        private void EnumControlElements(AutomationElement aeRoot)
        {
            AutomationElement aeNode = TreeWalker.ControlViewWalker.GetFirstChild(aeRoot);

            while (aeNode != null)
            {
                _controlCounter++;
                MappedControl ctrl = new MappedControl();
                ctrl.LoadControl(aeNode, ProdUiTypes);
                ctrl.ControlTreePosition = _controlCounter;
                AllFormsControls.Add(ctrl);
                EnumControlElements(aeNode);
                aeNode = TreeWalker.ControlViewWalker.GetNextSibling(aeNode);
            }
        }

        /// <summary>
        /// Gets the current process information.
        /// </summary>
        /// <param name="control">The control.</param>
        private void GetProcessInformation(AutomationElement control)
        {
            ProcessId = control.Current.ProcessId;
            Process pro = Process.GetProcessById(ProcessId);
            ParentWindowTitle = pro.MainWindowTitle;
            ApplicationHandle = pro.MainWindowHandle;
            ApplicationType = control.Current.FrameworkId;
            try
            {
                ParentModule = pro.MainModule.FileName;
            }
            catch (InvalidOperationException)
            {
                ParentModule = string.Empty;
            }
        }

        /// <summary>
        /// Loads the prod types from the ProdUI dll for reflection.
        /// </summary>
        private void LoadProdTypes()
        {
            //todo: this path sucks
            string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string newpath = root + @"\Projects\ProdUI\trunk\ProdUISystem\Common\";

            Assembly prodAssembly = Assembly.LoadFrom(newpath + @"ProdUI.dll");
            ProdUiTypes = prodAssembly.GetTypes();
        }
    }
}