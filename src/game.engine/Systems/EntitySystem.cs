using Game.Engine.EntityComponentSystem;
using Game.Engine.Input;
using System;
using System.Collections.Generic;

namespace Game.Engine.Systems
{
    public class EntitySystem : ISystem
    {
        public IEntityRegistery Registery { get; set; }
        public InputManager Input { get; set; }

        public virtual void Update(TimeSpan gameTime)
        {
        }

        public IEntityRecord FindByName(string name)
        {
            return Registery.FindByName(name);
        }

        public IEnumerable<IEntityRecord> GetAllEntities()
        {
            return Registery.All();
        }
    }
}