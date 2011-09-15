using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace ProdUI.Verification
{
    public static class AutomationEventVerifier
    {
        delegate void ProdEventHandler();


        private static readonly List<AutomationPropertyChangedEventHandler> PropertyEventList = new List<AutomationPropertyChangedEventHandler>();
        private static readonly List<AutomationEventHandler> EventList = new List<AutomationEventHandler>();
        //private AutomationEvent _patternEventType;
        private static EventRegistration _targetEvent;

        internal static void Register(EventRegistration targetEvent)
        {
            _targetEvent = targetEvent;
            HookHandler();
        }


        private static void HookHandler()
        {
            if (_targetEvent.Property != null)
            {
                AutomationPropertyChangedEventHandler propertyChangeHandler = OnPropertyChange;
                Automation.AddAutomationPropertyChangedEventHandler(_targetEvent.Source, TreeScope.Element, propertyChangeHandler, _targetEvent.Property);
                PropertyEventList.Add(propertyChangeHandler);
                return;
            }

            AutomationEventHandler eventHandler = OnAutomationEvent;
            Automation.AddAutomationEventHandler(_targetEvent.EventType, _targetEvent.Source, TreeScope.Element, eventHandler);
            EventList.Add(eventHandler);
            //_patternEventType = _targetEvent.EventType;
        }

        /// <summary>
        /// Automation Event handler
        /// </summary>
        /// <param name="src">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Automation.AutomationEventArgs"/> instance containing the event data.</param>
        private static void OnAutomationEvent(object src, AutomationEventArgs e)
        {
           
            if (src == null)
            {
                return;
            }

            if (e.EventId != _targetEvent.EventType)
            {
                AutomationElement source = (AutomationElement)src;
                return;
            }

            RemoveHandler();
        }

        /// <summary>
        /// Handler for property change events
        /// </summary>
        /// <param name="src">The source whose properties changed.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPropertyChange(object src, AutomationPropertyChangedEventArgs e)
        {
            if (src == null)
            {
                return;
            }

            RemovePropertyChangeHandler();
        }

        /// <summary>
        /// Removes the handler.
        /// </summary>
        private void RemoveHandler()
        {
            Automation.RemoveAutomationEventHandler(_patternEventType, _targetEvent.Source, _eventHandler);
            _eventHandler = null;
        }

        private void RemovePropertyChangeHandler()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(_targetEvent.Source, _propertyChangeHandler);
            _propertyChangeHandler = null;
        }

        ///// <summary>
        ///// Registers a method that handles UI Automation events inside containers
        ///// </summary>
        ///// <param name="eventType">The specific event type to monitor</param>
        //public void SubscribeToChildNotification(AutomationEvent eventType)
        //{
        //    _eventHandler = new AutomationEventHandler(OnAutomationEvent);
        //    _patternEventType = eventType;
        //    Automation.AddAutomationEventHandler(_patternEventType, ThisElement, TreeScope.Subtree, _eventHandler);

        //}

        ///// <summary>
        ///// Registers a method that handles UI Automation events
        ///// </summary>
        ///// <param name="eventType">The specific event type to monitor</param>
        //public void SubscribeToEvent(AutomationEvent eventType)
        //{
        //    eventTriggered = false;
        //    CreateMessage();

        //    if (eventType.Id == InvokePattern.InvokedEvent.Id)
        //    {
        //        _eventHandler = new AutomationEventHandler(OnAutomationEvent);
        //        Automation.AddAutomationEventHandler(eventType, ThisElement, TreeScope.Element, _eventHandler);
        //        _patternEventType = eventType;
        //        return;
        //    }

        //    SubscribeToChildNotification(eventType);
        //}


    }
}
