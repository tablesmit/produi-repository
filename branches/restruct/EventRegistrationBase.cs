using System.Windows.Automation;

namespace ProdUI.Verification
{
    internal class EventRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventRegistration"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="property">The property.</param>
        public EventRegistration(AutomationElement source, AutomationProperty property)
        {
            Source = source;
            Property = property;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventRegistration"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="eventType">Type of the event.</param>
        public EventRegistration(AutomationElement source, AutomationEvent eventType)
        {
            Source = source;
            EventType = eventType;
        }

        internal AutomationElement Source;

        internal AutomationProperty Property;

        internal AutomationEvent EventType;

        internal bool EventTriggered;

    }
}
