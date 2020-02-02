using System;

using Game.Engine;
using Game.Engine.EntityComponentSystem;
using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Input;
using Game.Engine.Systems;
using Game.Engine.Systems.Position;

namespace Game.Cli
{
    public class WriteToConsoleSystem : EntitySystem
    {
        public WriteToConsoleSystem()
        {
            Game.Engine.Game.EventManager.RegisterListener<KeyPressedEvent>(HandleKeyPress);
            //Game.Engine.Game.EventManager.RegisterListener<MouseMovedEvent>(HandleMouseMove);
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
            if (Input.IsKeyPressed(65))
            {
                Registery.FindByName("Camera").GetComponent<PositionComponent>().X -= 0.01f;
            }
            else if (Input.IsKeyPressed(68))
            {
                Registery.FindByName("Camera").GetComponent<PositionComponent>().X += 0.01f;
            }

            if (Input.IsKeyPressed(87))
            {
                Registery.FindByName("Camera").GetComponent<PositionComponent>().Y += 0.01f;
            }
            else if (Input.IsKeyPressed(83))
            {
                Registery.FindByName("Camera").GetComponent<PositionComponent>().Y -= 0.01f;
            }

            if (Input.IsKeyPressed(61))
            {
                Registery.FindByName("Camera").GetComponent<PositionComponent>().Z += 0.01f;
            }
            else if (Input.IsKeyPressed(45))
            {
                Registery.FindByName("Camera").GetComponent<PositionComponent>().Z -= 0.01f;
            }
        }
    }
}