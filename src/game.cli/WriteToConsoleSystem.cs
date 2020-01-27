using System;

using Game.Engine.EntityComponentSystem;
using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Systems;

namespace Game.Cli
{
    public class WriteToConsoleSystem : EntitySystem
    {
        public override void Init(IEntityRegistery registery, EventManager eventManager)
        {
            eventManager.RegisterListener<KeyPressedEvent>(HandleEvent);
            base.Init(registery, eventManager);
        }

        private void HandleEvent(Event e)
        {
            if (e.EventData is KeyPressedEvent kp)
            {
                Console.WriteLine(kp.KeyCode);
            }
        }

        public override void Update(TimeSpan gameTime)
        {
            foreach(var e in GetAllEntities())
            {
                //Console.WriteLine(e.Name);

                foreach(var c in Registery.GetComponents(e))
                {
                  //  Console.WriteLine(c.ToString());
                }
            }
        }
    }
}
