// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
namespace ProdUI.Verification
{
    public static class AutomationEventVerifier
    {
        internal static void Register(EventRegistrationMessage targetEvent)
        {
            new EventListener(targetEvent);
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