// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
namespace MapLib
{
    /// <summary>
    ///   Represents the data associated with comparing 2 window maps
    /// </summary>
    public class CompareResult
    {
        /// <summary>
        /// Gets the category being tested.
        /// </summary>
        public string Category { get; internal set; }

        /// <summary>
        /// Gets the value that was loaded from the comparison file.
        /// </summary>
        public string LoadedValue { get; internal set; }

        /// <summary>
        /// Gets the value of the currently scanned window.
        /// </summary>
        public string LiveValue { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CompareResult"/> has passed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if passed; otherwise, <c>false</c>.
        /// </value>
        public bool Passed { get; internal set; }

        /// <summary>
        /// Gets the score value of the control result.
        /// </summary>
        /// <remarks>
        /// Each category contains a weighted value that affects the score
        /// </remarks>
        public int Score { get; internal set; }
    }
}