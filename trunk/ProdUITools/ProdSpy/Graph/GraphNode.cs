/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System.Windows.Automation;
using System.Windows.Forms;
using System;
using System.Runtime.Serialization;
using System.Globalization;

namespace ProdSpy.Graph
{
    /// <summary>
    ///   Functions or working with a GraphNode (a specialized TreeNode)
    /// </summary>
    [Serializable]
    public class GraphNode : TreeNode
    {
        #region Private

        private readonly string _appType;
        //private readonly AutomationElement _AutomationElement;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the node element.	
        /// </summary>
        /// <value>The node element.</value>
        /// <remarks></remarks>
        public AutomationElement NodeElement { get; private set; }

        /// <summary>
        ///   Controls associated caption
        /// </summary>
        public string NodeCtrlCaption { get; private set; }

        /// <summary>
        ///   Normalized control type
        /// </summary>
        public string NodeCtrlType { get; private set; }

        /// <summary>
        ///   Class of control
        /// </summary>
        public string NodeCtrlClass { get; private set; }

        /// <summary>
        ///   String representation of the controls handle
        /// </summary>
        public string NodeCtrlHandle { get; private set; }

        /// <summary>
        ///   Any ID associated with the control
        /// </summary>
        public string NodeCtrlId { get; private set; }

        #endregion

        /// <summary>
        ///   Constructor
        /// </summary>
        /// <param name = "automationElement">element to convert to GraphNode</param>
        public GraphNode(AutomationElement automationElement)
        {
            _appType = automationElement.Current.FrameworkId;
            NodeElement = automationElement;
            SetNodeInformation();
        }

        /// <summary>
        ///   move strings into properties
        /// </summary>
        private void SetNodeInformation()
        {
            string id = _appType == "Win32" ? "ID: " : "Control Name: ";

            NodeCtrlId = id + NodeElement.Current.AutomationId;
            NodeCtrlCaption = NodeElement.Current.Name;
            NodeCtrlType = NodeElement.Current.LocalizedControlType;
            NodeCtrlClass = NodeElement.Current.ClassName;
            NodeCtrlHandle = NodeElement.Current.NativeWindowHandle.ToString(CultureInfo.CurrentCulture);
        }


        #region Constructor

        public GraphNode()
        {
        }

        #endregion


        #region Deserialization Constructor

        protected GraphNode(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _appType = (string)info.GetValue("_AppType", typeof(string));
        }

        #endregion
    }
}