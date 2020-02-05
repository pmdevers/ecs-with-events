using Game.Engine.EntityComponentSystem;
using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Graphics;
using Game.Engine.Input;
using Game.Engine.Systems;
using Game.Engine.Systems.Camera;
using System;

namespace Game.Engine
{
    public class Game
    {
        public static readonly EventManager EventManager = new EventManager();
        private bool _isRunning;
        private DateTime _previousGameTime;

        public Game()
        {
            Instance = this;
            Registery = new SystemRegistery();
            EntityRegistery = new EntityRegistery();
            EntityLoader = new EntityLoader(EntityRegistery);
            Window = Window.Create(1280, 720, "Game.Engine");
            Window.Init();
            Window.EnableVsync(true);
            Input = InputManager.Create();

            Registery.Register(new CameraSystem());
            Registery.Register(new RenderSystem());

            EventManager.RegisterListener<CloseWindowEvent>(WindowClosed);
        }

        public ISystemRegistery Registery { get; }
        public IEntityRegistery EntityRegistery { get; }
        public EntityLoader EntityLoader { get; }
        public Window Window { get; }
        public InputManager Input { get; }

        public static Game Instance { get; private set; }

        public void Run()
        {
            var initiable = Registery.GetEnumerator();

            while (initiable.MoveNext())
            {
                var system = initiable.Current;
                if (system is EntitySystem s)
                {
                    s.Registery = EntityRegistery;
                    s.Input = Input;
                }
            }

            _isRunning = true;
            _previousGameTime = DateTime.Now;

            while (_isRunning)
            {
                var time = DateTime.Now;
                var gameTime = time - _previousGameTime;
                _previousGameTime = time;

                EventManager.ProcessEvents();

                var systemsEnumerator = Registery.GetEnumerator();

                while (systemsEnumerator.MoveNext())
                {
                    var system = systemsEnumerator.Current;
                    system.Update(gameTime.TotalSeconds);
                }

                var cleanupEnumerator = Registery.GetEnumerator();

                while (cleanupEnumerator.MoveNext())
                {
                    var system = cleanupEnumerator.Current;
                    if (system is IDisposable s)
                        s.Dispose();
                }

                Window.Update();
            }
        }

        private void WindowClosed(Event e)
        {
            _isRunning = false;
        }
    }
}