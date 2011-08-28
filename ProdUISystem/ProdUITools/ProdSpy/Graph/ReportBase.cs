/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;

namespace ProdSpy.Graph
{
    /// <summary>
    ///   Base class for all control reports
    /// </summary>
    public abstract class ReportBase : IDisposable
    {
        protected GraphNode GraphNode { get; set; }

        /// <summary>
        ///   Gets or sets the graph node.
        /// </summary>
        /// <value>
        ///   The graph node.
        /// </value>
        public abstract GraphNode graphNode { get; protected set; }

        /// <summary>
        ///   Gets or sets the output file.
        /// </summary>
        /// <value>
        ///   The output file.
        /// </value>
        public abstract string OutFile { get; protected set; }

        /// <summary>
        ///   Gets or sets the name of the file.
        /// </summary>
        /// <value>
        ///   The name of the file.
        /// </value>
        protected string FileName { get; set; }

        #region IDisposable Members

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();

        #endregion

        /// <summary>
        ///   Creates this instance of the report.
        /// </summary>
        public abstract void Create();
    }
}