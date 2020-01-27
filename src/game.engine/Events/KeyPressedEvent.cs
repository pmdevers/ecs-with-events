using Game.Engine.Input;

namespace Game.Engine.Events
{
    public class KeyPressedEvent
    {
        public KeyPressedEvent(KeyCode keyCode, int pressed)
        {
            KeyCode = keyCode;
            Pressed = pressed;
        }

        public KeyCode KeyCode { get; }
        public int Pressed { get; }
    }

    public class KeyReleasedEvent
    {
        public KeyReleasedEvent(KeyCode keyCode)
        {
            KeyCode = keyCode;
        }

        public KeyCode KeyCode { get; }
    }
}
