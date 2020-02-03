using Game.Engine.EventSystem;

namespace Game.Engine.Events
{
    public static class EventManagerExtensions
    {
        public static void QueueEvent<T>(this EventManager manager, T eventData)
        {
            manager.QueueEvent(new Event(typeof(T), eventData));
        }

        public static void RegisterListener<TEvent>(this EventManager manager, EventDelegate callBack)
        {
            var eventType = typeof(TEvent);
            manager.RegisterListener(eventType, callBack);
        }

        public static void RemoveListener<TEvent>(this EventManager manager, EventDelegate callBack)
        {
            var eventType = typeof(TEvent);
            manager.RemoveListener(eventType, callBack);
        }
    }
}