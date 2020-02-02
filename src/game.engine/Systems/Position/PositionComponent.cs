using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Systems.Position
{
    public class PositionComponent : Component
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Rotation { get; set; }
    }
}