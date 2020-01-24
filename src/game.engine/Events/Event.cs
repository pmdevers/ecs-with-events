namespace Game.Engine.EventSystem
{
    public class Event
    {
        public Event(object eventType, object eventData)
        {
            EventType = eventType;
            EventData = eventData;
        }

        public object EventType { get; }
        public object EventData { get; }
    }
}
