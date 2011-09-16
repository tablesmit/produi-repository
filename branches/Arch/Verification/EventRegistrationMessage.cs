using System.Windows.Automation;
using ProdUI.Controls;
using ProdUI.Controls.Windows;

namespace ProdUI.Verification
{
    internal class EventRegistrationMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventRegistrationMessage"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="property">The property.</param>
        public EventRegistrationMessage(BaseProdControl source, AutomationProperty property)
        {
            Source = source;
            Property = property;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventRegistrationMessage"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="eventType">Type of the event.</param>
        public EventRegistrationMessage(BaseProdControl source, AutomationEvent eventType)
        {
            Source = source;
            EventType = eventType;
        }

        internal AutomationProperty Property;

        internal AutomationEvent EventType;

        internal BaseProdControl Source;

    }
}
