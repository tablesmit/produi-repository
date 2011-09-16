/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
namespace ProdUI.Interaction.Native
{
    /// <summary>
    /// Denotes which mouse button was clicked for sending events
    /// </summary>
    public enum MouseClick
    {
        /// <summary>
        ///   The left mouse button
        /// </summary>
        Left,
        /// <summary>
        ///   The right mouse button
        /// </summary>
        Right,
        /// <summary>
        ///   The middle mouse button
        /// </summary>
        Middle,
    }

    /// <summary>
    /// Indicates the status of a ProdWindow
    /// </summary>
    public enum WindowState
    {
        /// <summary>
        ///   The window is running. This does not guarantee that the window is ready for user interaction or is responding
        /// </summary>
        Running,
        /// <summary>
        ///   The window is ready for user interaction
        /// </summary>
        Ready,
        /// <summary>
        ///   The window is blocked by a modal window
        /// </summary>
        Blocked,
        /// <summary>
        ///   The window is not responding
        /// </summary>
        NotResponding
    }

}