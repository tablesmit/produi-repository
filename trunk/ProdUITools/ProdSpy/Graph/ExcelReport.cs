/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ProdSpy.Graph
{
    /// <summary>
    /// Provides methods for creating an Excel-formatted report of window controls
    /// </summary>
    public class ExcelReport : ReportBase
    {
        private static int _row = 2;
        private Range _range;
        private _Workbook _workbook;
        private _Worksheet _worksheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelReport"/> class.
        /// </summary>
        /// <param name="gn">graph node to map</param>
        public ExcelReport(GraphNode gn)
        {
            GraphNode = gn;
        }

        private void EnumTree(TreeNode tn)
        {
            foreach (GraphNode item in tn.Nodes)
            {
                _row++;
                _worksheet.Cells[_row, 1] = item.NodeCtrlId.Substring(4);
                _worksheet.Cells[_row, 2] = item.NodeCtrlCaption;
                _worksheet.Cells[_row, 3] = item.NodeCtrlClass;
                _worksheet.Cells[_row, 4] = item.NodeCtrlHandle;
                EnumTree(item);
            }
        }

        private void BuildExcelHeader()
        {
            _worksheet.Cells[1, 1] = "Id";
            _worksheet.Cells[1, 2] = "Caption";
            _worksheet.Cells[1, 3] = "Class";
            _worksheet.Cells[1, 4] = "Handle";

            _worksheet.Range["A1", "D1"].Font.Bold = true;
            _worksheet.Range["A1", "D1"].VerticalAlignment = XlVAlign.xlVAlignCenter;
        }

        #region Overrides

        /// <summary>
        /// Gets or sets the graph node.
        /// </summary>
        /// <value>
        /// The graph node.
        /// </value>
        public override GraphNode graphNode
        {
            get { return GraphNode; }
            protected set { GraphNode = value; }
        }

        /// <summary>
        /// Gets or sets the output file.
        /// </summary>
        /// <value>
        /// The output file.
        /// </value>
        public override string OutFile
        {
            get { return FileName; }
            protected set { FileName = value; }
        }

        /// <summary>
        /// Creates this report.
        /// </summary>
        public override void Create()
        {
            Application excel = new Application { Visible = true };

            _workbook = excel.Workbooks.Add(Missing.Value);
            _worksheet = (_Worksheet)_workbook.ActiveSheet;

            BuildExcelHeader();

            /* Fill First Row */
            _worksheet.Cells[2, 1] = GraphNode.NodeCtrlId;
            _worksheet.Cells[2, 2] = GraphNode.NodeCtrlCaption;
            _worksheet.Cells[2, 3] = GraphNode.NodeCtrlClass;
            _worksheet.Cells[2, 4] = GraphNode.NodeCtrlHandle;

            /* run through tree */
            EnumTree(GraphNode);

            _range = _worksheet.Range["A1", "D1"];
            _range.EntireColumn.AutoFit();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public sealed override void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}