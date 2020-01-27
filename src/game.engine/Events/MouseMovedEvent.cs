using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Events
{
    public class MouseMovedEvent
    {
        public float XPos { get; }
        public float YPos { get; }

        public MouseMovedEvent(float xPos, float yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }
    }
}
