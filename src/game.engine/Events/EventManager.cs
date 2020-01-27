using System;
using System.Collections.Generic;

namespace Game.Engine.EventSystem
{
    public delegate void EventDelegate(Event e);

    public class EventManager
    {
        private readonly List<Event> _currentEvents = new List<Event>();
        private readonly Dictionary<object, EventDelegate> _listeners = new Dictionary<object, EventDelegate>();
        private readonly List<Event> _newEvents = new List<Event>();
        private bool _isProcessing;

        public void QueueEvent(object eventType, object eventData)
        {
            QueueEvent(new Event(eventType, eventData));
        }

        public void QueueEvent(Event e)
        {
            _newEvents.Add(e);
        }
        
        public void RegisterListener(object eventType, EventDelegate callback)
        {
            if (eventType == null)
                throw new ArgumentNullException(nameof(eventType));

            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            if (_listeners.ContainsKey(eventType))
                _listeners[eventType] += callback;
            else
                _listeners[eventType] = callback;
        }
        
        public void RemoveListener(object eventType, EventDelegate callback)
        {
            if (eventType == null)
                throw new ArgumentNullException(nameof(eventType));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            if (_listeners.ContainsKey(eventType))
                _listeners[eventType] -= callback;
        }

        public int ProcessEvents(TimeSpan gameTime)
        {
            if (_isProcessing)
                return 0;

            _isProcessing = true;

            int processedEvents = 0;

            while (_newEvents.Count > 0)
            {
                _currentEvents.AddRange(_newEvents);
                _newEvents.Clear();

                foreach (Event e in _currentEvents)
                {
                    ProcessEvent(e);
                    ++processedEvents;
                }

                _currentEvents.Clear();
            }

            _isProcessing = false;
            return processedEvents;
        }

        public void ProcessEvent(Event e)
        {
            if (_listeners.ContainsKey(e.EventType))
                _listeners[e.EventType](e);
        }
    }
}
