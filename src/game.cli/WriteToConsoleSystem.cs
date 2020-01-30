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
            Game.Engine.Game.EventManager.RegisterListener<KeyPressedEvent>(HandleKeyPress);
            Game.Engine.Game.EventManager.RegisterListener<MouseMovedEvent>(HandleMouseMove);
        }

        private void HandleMouseMove(Event e)
        {
            if (e.EventData is MouseMovedEvent mv)
            {
                Console.WriteLine($"Mouse X:'{mv.XPos}' - Y: '{mv.YPos}';");
            }
        }

        private void HandleKeyPress(Event e)
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
