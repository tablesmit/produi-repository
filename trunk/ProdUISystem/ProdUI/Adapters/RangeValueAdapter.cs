// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
namespace ProdUI.Adapters
{
    public interface RangeValueAdapter
    {
        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        bool IsReadOnly { get; }

        /// <summary>
        /// Gets the control-specific large-change value which is added to or subtracted from the Value property.
        /// </summary>
        double LargeChange { get; }

        /// <summary>
        /// Gets the control-specific small-change value which is added to or subtracted from the Value property.
        /// </summary>
        double SmallChange { get; }

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        double Minimum { get; }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        double Maximum { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        double Value { get; set; }
    }
}