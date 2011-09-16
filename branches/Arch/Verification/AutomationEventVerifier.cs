using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace ProdUI.Verification
{
    public static class AutomationEventVerifier
    {

        internal static void Register(EventRegistrationMessage targetEvent)
        {
            EventListener list = new EventListener(targetEvent);
        }

        internal static void EventFired(EventRegistrationMessage targetEvent)
        {
            targetEvent.Source.ReceiveEventNotification(true);
        }

        internal static void EventFail(EventRegistrationMessage targetEvent)
        {
            targetEvent.Source.ReceiveEventNotification(false);
        }
    
    }
}
