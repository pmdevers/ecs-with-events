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
            Engine.Game.EventManager.RegisterListener<MouseButtonPressedEvent>(OutputEvent);
            Engine.Game.EventManager.RegisterListener<KeyPressedEvent>(OutputEvent);
        }

        private void OutputEvent(Event e)
        {
            Console.WriteLine(e.EventData.ToString());
        }

        public override void Update(GameTime gameTime)
        {
            var position = Registery.FindByName("Camera").GetComponent<PositionComponent>();
            if (InputManager.IsKeyPressed(KeyCode.A))
            {
                position.X -= 0.5f * (float)gameTime;
            }
            else if (InputManager.IsKeyPressed(KeyCode.D))
            {
                position.X += 0.5f * (float)gameTime;
            }

            if (InputManager.IsKeyPressed(KeyCode.W))
            {
                position.Y += 0.5f * (float)gameTime;
            }
            else if (InputManager.IsKeyPressed(KeyCode.S))
            {
                position.Y -= 0.5f * (float)gameTime;
            }

            if (InputManager.IsKeyPressed(KeyCode.Minus))
            {
                position.Z += 0.5f * (float)gameTime;
            }
            else if (InputManager.IsKeyPressed(KeyCode.Equal))
            {
                position.Z -= 0.5f * (float)gameTime;
            }
        }
    }
}