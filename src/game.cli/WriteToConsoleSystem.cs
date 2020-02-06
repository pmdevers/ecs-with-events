using System;

using Game.Engine;
using Game.Engine.EntityComponentSystem;
using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Input;
using Game.Engine.Systems;
using Game.Engine.Systems.Transform;

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
            Console.WriteLine("Delta time: {0}s {1}ms", gameTime.GetSeconds(), gameTime.GetMilliseconds());

            var position = Registery.FindByName("Camera").GetComponent<TransformComponent>();
            position.Velocity = new Vector3(0.0f);

            if (InputManager.IsKeyPressed(KeyCode.A))
            {
                position.Velocity += new Vector3(0.5f, 0.0f, 0.0f);
            }
            else if (InputManager.IsKeyPressed(KeyCode.D))
            {
                position.Velocity -= new Vector3(0.5f, 0.0f, 0.0f);
            }

            if (InputManager.IsKeyPressed(KeyCode.W))
            {
                position.Velocity += new Vector3(0.0f, 0.5f, 0.0f);
            }
            else if (InputManager.IsKeyPressed(KeyCode.S))
            {
                position.Velocity -= new Vector3(0.0f, 0.5f, 0.0f);
            }

            if (InputManager.IsKeyPressed(KeyCode.Minus))
            {
                position.Velocity += new Vector3(0.0f, 0.0f, 0.5f);
            }
            else if (InputManager.IsKeyPressed(KeyCode.Equal))
            {
                position.Velocity -= new Vector3(0.0f, 0.0f, 0.5f);
            }

        }
    }
}