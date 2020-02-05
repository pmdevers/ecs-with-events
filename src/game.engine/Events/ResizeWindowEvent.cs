using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Events
{
    public class ResizeWindowEvent
    {
        public float Width { get; }
        public float Height { get; }

        public ResizeWindowEvent(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}