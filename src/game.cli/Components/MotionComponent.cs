using Game.Engine.EntityComponentSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Cli.Components
{
    public class MotionComponent : IComponent
    {
        public IEntityRecord Record { get; set; }

        public float Velocity { get; set; }

    }
}
