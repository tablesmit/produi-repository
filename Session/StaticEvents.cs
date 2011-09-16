/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System.Windows.Automation;

namespace ProdUI.Session
{
    internal static class StaticEvents
    {

        private static AutomationEventHandler _eventHandler;
        private static AutomationPropertyChangedEventHandler _propertyChangeHandler;
        private static AutomationEvent _patternEventType;
        private static AutomationElement _control;

        /// <summary>
        /// Registers a method that handles UI Automation events
        /// </summary>
        /// <param name="eventType">The specific event type to monitor</param>
        /// <param name="control">The control to monitor for events.</param>
        public static void RegisterEvent(AutomationEvent eventType, AutomationElement control)
        {
            _control = control;

            if (eventType.Id == InvokePattern.InvokedEvent.Id)
            {
                _eventHandler = new AutomationEventHandler(OnAutomationEvent);
                Automation.AddAutomationEventHandler(eventType, control, TreeScope.Element, _eventHandler);
                _patternEventType = eventType;
                return;
            }

            SubscribeToChildNotification(eventType, control);
        }

        /// <summary>
        /// Registers a method that will handle property-changed events
        /// </summary>
        /// <param name="property">The automation property to monitor for a state change</param>
        /// <param name="control">The control to monitor for events.</param>
        public static void RegisterEvent(AutomationProperty property, AutomationElement control)
        {
            _control = control;
            _propertyChangeHandler = new AutomationPropertyChangedEventHandler(OnPropertyChange);
            Automation.AddAutomationPropertyChangedEventHandler(control, TreeScope.Element, _propertyChangeHandler, property);
        }

        /// <summary>
        /// Registers a method that handles UI Automation events inside containers
        /// </summary>
        /// <param name="eventType">The specific event type to monitor</param>
        /// <param name="control">The control to monitor for events.</param>
        public static void SubscribeToChildNotification(AutomationEvent eventType, AutomationElement control)
        {
            _control = control;
            _patternEventType = eventType;
            _eventHandler = new AutomationEventHandler(OnAutomationEvent);
            Automation.AddAutomationEventHandler(_patternEventType, control, TreeScope.Descendants, _eventHandler);
        }

        /// <summary>
        /// Called when a subscribed automation event fires.
        /// </summary>
        /// <param name="src">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Automation.AutomationEventArgs"/> instance containing the event data.</param>
        private static void OnAutomationEvent(object src, AutomationEventArgs e)
        {
            if (src == null)
            {
                return;
            }

            if (e.EventId != _patternEventType)
            {
                return;
            }

            if (_eventHandler == null)
            {
                return;
            }


            RemoveHandler();
        }

        /// <summary>
        /// Handler for property change events
        /// </summary>
        /// <param name="src">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Automation.AutomationPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnPropertyChange(object src, AutomationPropertyChangedEventArgs e)
        {
            if (src == null)
            {
                return;
            }

            if (_propertyChangeHandler == null)
            {
                return;
            }


            RemovePropertyChangeHandler();
        }

        /// <summary>
        /// Removes the calling AutomationEventHandle.
        /// </summary>
        private static void RemoveHandler()
        {
            Automation.RemoveAutomationEventHandler(_patternEventType, _control, _eventHandler);
            _eventHandler = null;
        }

        /// <summary>
        /// Removes the calling property change handler.
        /// </summary>
        private static void RemovePropertyChangeHandler()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(_control, _propertyChangeHandler);
            _propertyChangeHandler = null;
        }

    }
}