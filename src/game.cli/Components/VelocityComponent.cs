using Game.Engine.EntityComponentSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Cli.Components
{
    public class VelocityComponent : IComponent
    {
        public IEntityRecord Record { get; set; }
    }
}
