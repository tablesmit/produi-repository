/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;
using System.IO;

namespace ProdSpy.Graph
{
    internal class HtmlReport : ReportBase
    {
        private string _bodyTags;
        private StreamWriter _sw;

        #region String Constants

        private const string TableCell = "</TD>\n\t<TD>";

        private const string TableHeader = "\n<TH>Level</TH><TH>Control Name</TH><TH>Caption</TH><TH>Class</TH><TH>Handle</TH><TH>ID</TH><TH>Type</TH>\n";

        private const string PageStyle = "<style type='text/css'>TD{font-family: Consolas, monospace; font-size: 10pt; background-color:#ADD8E6;}TH{font-family: Consolas, monospace; font-size: 10pt; background-color:#E0E0E0;}</style>";

        #endregion

        /// <summary>
        ///   Constructor
        /// </summary>
        /// <param name = "gn">graph node to map</param>
        /// <param name = "filename">output filename</param>
        public HtmlReport(GraphNode gn, string filename)
        {
            GraphNode = gn;
            OutFile = filename;
        }

        private void EnumTree(GraphNode tn)
        {
            foreach (GraphNode item in tn.Nodes)
            {
                _bodyTags += "\n<TR>\n";

                string outstr = FillNode(item);

                _bodyTags += outstr + "</TR>";
                EnumTree(item);
            }
        }

        #region HTML Stuff

        private void InitTable()
        {
            _bodyTags = "<TABLE border = 1>";
            _bodyTags += TableHeader;

            /* Heres the root node */
            _bodyTags += "<TR>\n\t<TD>0" + TableCell + GraphNode.Text + TableCell + GraphNode.NodeCtrlCaption + TableCell + GraphNode.NodeCtrlClass + TableCell + GraphNode.NodeCtrlHandle + TableCell + "" + TableCell + GraphNode.NodeCtrlType + "</TD>\n</TR>";
        }

        private static string FillNode(GraphNode item)
        {
            string name = item.NodeCtrlId.Replace("Control Name:", "");
            return "\t<TD>" + item.Level + TableCell + item.Text + TableCell + item.NodeCtrlCaption + TableCell + item.NodeCtrlClass + TableCell + item.NodeCtrlHandle + TableCell + name + TableCell + item.NodeCtrlType + "</TD>\n";
        }

        private void WriteHtml(string body)
        {
            _sw.WriteLine("<HTML>");
            _sw.WriteLine("<HEAD>" + PageStyle + "</HEAD>");
            _sw.WriteLine("<TITLE>Control Graph: " + GraphNode.NodeCtrlCaption + "</TITLE>");
            _sw.WriteLine("<BODY>");
            _sw.Write(body);
            _sw.WriteLine("\n</BODY>");
            _sw.WriteLine("</HTML>");

            _sw.Close();
        }

        #endregion

        #region Overrides

        public override GraphNode graphNode
        {
            get { return GraphNode; }
            protected set { GraphNode = value; }
        }

        public override sealed string OutFile
        {
            get { return FileName; }
            protected set { FileName = value; }
        }

        public override void Create()
        {
            _sw = new StreamWriter(OutFile);
            InitTable();
            EnumTree(graphNode);
            WriteHtml(_bodyTags);
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            _sw.Dispose();
        }

        #endregion
    }
}