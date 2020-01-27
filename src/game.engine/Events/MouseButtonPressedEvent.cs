namespace Game.Engine.Events
{
    public class MouseCode
    {
        public MouseCode(int button)
        {
        }
    }

    public class MouseButtonPressedEvent
    {
        public MouseButtonPressedEvent(MouseCode mouseCode)
        {
            MouseCode = mouseCode;
        }

        public MouseCode MouseCode { get; }
    }

    public class MouseButtonReleasedEvent
    {
        public MouseButtonReleasedEvent(MouseCode mouseCode)
        {
            MouseCode = mouseCode;
        }

        public MouseCode MouseCode { get; }
    }
}
