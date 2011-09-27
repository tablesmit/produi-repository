// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Windows.Automation;
using ProdUI.Controls.Windows;

namespace ProdUI.Verification
{
    internal sealed class EventRegistrationMessage
    {
        internal AutomationEvent EventType;
        internal AutomationProperty Property;
        internal BaseProdControl Source;

        /// <summary>
        ///     Initializes a new instance of the <see cref = "EventRegistrationMessage" /> class.
        /// </summary>
        /// <param name = "source">The source.</param>
        /// <param name = "property">The property.</param>
        internal EventRegistrationMessage(BaseProdControl source, AutomationProperty property)
        {
            Source = source;
            Property = property;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref = "EventRegistrationMessage" /> class.
        /// </summary>
        /// <param name = "source">The source.</param>
        /// <param name = "eventType">Type of the event.</param>
        internal EventRegistrationMessage(BaseProdControl source, AutomationEvent eventType)
        {
            Source = source;
            EventType = eventType;
        }
    }
}