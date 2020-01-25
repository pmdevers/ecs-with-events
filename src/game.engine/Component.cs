using Game.Engine.EntityComponentSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    public abstract class Component : IComponent
    {
        public IEntityRecord Record { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} - {Record.Name}";
        }
    }
}
