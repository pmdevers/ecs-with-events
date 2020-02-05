using Game.Engine.Input;

namespace Game.Engine.Events
{
    public class MouseButtonPressedEvent
    {
        public MouseButtonPressedEvent(MouseCode mouseCode)
        {
            MouseCode = mouseCode;
        }

        public MouseCode MouseCode { get; }

        public override string ToString()
        {
            return $"The mouse button: '{MouseCode.ToString()}' was pressed";
        }
    }

    public class MouseButtonReleasedEvent
    {
        public MouseButtonReleasedEvent(MouseCode mouseCode)
        {
            MouseCode = mouseCode;
        }

        public MouseCode MouseCode { get; }

        public override string ToString()
        {
            return $"The mouse button: '{MouseCode.ToString()}' was released";
        }
    }
}