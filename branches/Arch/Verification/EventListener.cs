// /* License Rider:
//  * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
//  */
using System.Windows.Automation;
using ProdUI.Exceptions;

namespace ProdUI.Verification
{
    internal sealed class EventListener
    {
        private readonly EventRegistrationMessage _targetEvent;
        private AutomationEventHandler _eventHandler;
        private AutomationPropertyChangedEventHandler _propertyChangeHandler;

        /// <summary>
        ///     Initializes a new instance of the <see cref = "EventListener" /> class.
        /// </summary>
        /// <param name = "targetEvent">The target event message.</param>
        internal EventListener(EventRegistrationMessage targetEvent)
        {
            if (targetEvent == null) throw new ProdOperationException("targetEvent cannot be null");
            _targetEvent = targetEvent;
            SetEventHook();
        }

        /// <summary>
        ///     Sets the event listener hook depending on event type.
        /// </summary>
        private void SetEventHook()
        {
            /* se a property change hook */
            if (_targetEvent.Property != null)
            {
                _propertyChangeHandler = OnPropertyChange;
                Automation.AddAutomationPropertyChangedEventHandler(_targetEvent.Source.UIAElement, TreeScope.Element, _propertyChangeHandler, _targetEvent.Property);
                return;
            }

            /* or a straight event handler */
            _eventHandler = OnAutomationEvent;
            Automation.AddAutomationEventHandler(_targetEvent.EventType, _targetEvent.Source.UIAElement, TreeScope.Element, _eventHandler);
        }

        /// <summary>
        ///     Automation Event handler
        /// </summary>
        /// <param name = "src">The source of the event.</param>
        /// <param name = "e">The <see cref = "System.Windows.Automation.AutomationEventArgs" /> instance containing the event data.</param>
        private void OnAutomationEvent(object src, AutomationEventArgs e)
        {
            if (src == null)
            {
                return;
            }

            if (e.EventId != _targetEvent.EventType)
            {
                AutomationEventVerifier.EventFired(_targetEvent);
                return;
            }

            RemoveHandler();
        }

        /// <summary>
        ///     Handler for property change events
        /// </summary>
        /// <param name = "src">The source whose properties changed.</param>
        /// <param name = "e">Event arguments.</param>
        private void OnPropertyChange(object src, AutomationPropertyChangedEventArgs e)
        {
            if (src == null)
            {
                return;
            }

            AutomationEventVerifier.EventFired(_targetEvent);

            RemovePropertyChangeHandler();
        }

        /// <summary>
        ///     Removes the handler.
        /// </summary>
        private void RemoveHandler()
        {
            Automation.RemoveAutomationEventHandler(_targetEvent.EventType, _targetEvent.Source.UIAElement, _eventHandler);
            _eventHandler = null;
        }

        /// <summary>
        ///     Removes the property change handler.
        /// </summary>
        private void RemovePropertyChangeHandler()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(_targetEvent.Source.UIAElement, _propertyChangeHandler);
            _propertyChangeHandler = null;
        }
    }
}