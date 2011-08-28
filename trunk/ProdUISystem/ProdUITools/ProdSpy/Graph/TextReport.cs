/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;
using System.IO;

namespace ProdSpy.Graph
{
    /// <summary>
    ///   Provides methods for creating an text report of window controls
    /// </summary>
    public class TextReport : ReportBase
    {
        private StreamWriter _sw;

        /// <summary>
        ///   Constructor
        /// </summary>
        /// <param name = "graphNode">graph node to map</param>
        /// <param name = "fileName">output filename</param>
        public TextReport(GraphNode graphNode, string fileName)
        {
            GraphNode = graphNode;
            OutFile = fileName;
        }

        private void EnumTree(GraphNode tn)
        {
            foreach (GraphNode item in tn.Nodes)
            {
                string outstr = "\t" + item.NodeCtrlId + " Text:" + item.NodeCtrlCaption + " Class: " + item.NodeCtrlClass;

                if (item.NodeCtrlHandle == "0")
                {
                    _sw.WriteLine("\t" + outstr + "\n");
                }
                else
                {
                    _sw.WriteLine(outstr + "\n");
                }
                EnumTree(item);
            }
        }

        #region Overrides

        /// <summary>
        ///   Gets or sets the graph node.
        /// </summary>
        /// <value>
        ///   The graph node.
        /// </value>
        public override GraphNode graphNode
        {
            get { return GraphNode; }
            protected set { GraphNode = value; }
        }

        /// <summary>
        ///   Gets or sets the output file.
        /// </summary>
        /// <value>
        ///   The output file.
        /// </value>
        public override sealed string OutFile
        {
            get { return FileName; }
            protected set { FileName = value; }
        }

        /// <summary>
        ///   Creates this instance of the report.
        /// </summary>
        public override void Create()
        {
            _sw = new StreamWriter(OutFile);

            string rootString = "Root Node-> " + GraphNode.NodeCtrlId + " Text: '" + GraphNode.NodeCtrlCaption + "' Class: " + GraphNode.NodeCtrlClass + "\n";
            _sw.WriteLine(rootString);
            EnumTree(graphNode);
            _sw.Close();
        }

        /// <summary>
        ///   Releases unmanaged and - optionally - managed resources
        /// </summary>
        public override sealed void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}