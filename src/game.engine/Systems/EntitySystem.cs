using System;
using System.Collections.Generic;

using Game.Engine.EntityComponentSystem;
using Game.Engine.EventSystem;

namespace Game.Engine.Systems
{
    public class EntitySystem : ISystem
    {
        public IEntityRegistery Registery { get; set; }
        public EventManager EventManager { get; set; }

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

        public virtual void Init(IEntityRegistery registery, EventManager eventManager)
        {
            Registery = registery;
            EventManager = eventManager;
        }
    }
}
