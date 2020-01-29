using System;

using Game.Engine;
using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Systems;

namespace Game.Cli
{
    public class WriteToConsoleSystem : EntitySystem
    {
        public WriteToConsoleSystem()
        {
            Game.Engine.Game.EventManager.RegisterListener<KeyPressedEvent>(HandleEvent);
        }

        private void HandleEvent(Event e)
        {
            if (e.EventData is KeyPressedEvent kp)
            {
                Console.WriteLine(kp.ToString());
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
