﻿namespace Game.Engine.Events
{
    public class MouseScrolledEvent
    {
        public float XOffset { get; }
        public float YOffset { get; }

        public MouseScrolledEvent(float xOffset, float yOffset)
        {
            XOffset = xOffset;
            YOffset = yOffset;
        }
    }
}