using System;

using Game.Engine.EntityComponentSystem;
using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Graphics;
using Game.Engine.Renderer;
using Game.Engine.Systems;


namespace Game.Engine
{
    public class Game
    {
        public static readonly EventManager EventManager = new EventManager();
        private bool _isRunning;
        private DateTime _previousGameTime;
                
        public Game()
        {
            Registery = new SystemRegistery();
            EntityRegistery = new EntityRegistery();
            EntityLoader = new EntityLoader(EntityRegistery);
            Window = new Window(1280, 720, "Game.Engine");
            Window.Init();
            
            Registery.Register(new RenderSystem());

            EventManager.RegisterListener<CloseWindowEvent>(WindowClosed);
        }

        public ISystemRegistery Registery { get; }
        public IEntityRegistery EntityRegistery { get; }
        public EntityLoader EntityLoader { get; }
        public OrthogaphicCamera Camera { get; }
        public Window Window { get; }
        public IRenderAPI Renderer { get; }

        public void Run()
        {
            var initiable = Registery.GetEnumerator();
            
            while (initiable.MoveNext())
            {
                var system = initiable.Current;
                if (system is EntitySystem s)
                    s.Init(EntityRegistery);
            }

            _isRunning = true;
            _previousGameTime = DateTime.Now;

            while (_isRunning)
            { 
                var gameTime = DateTime.Now - _previousGameTime;
                _previousGameTime += gameTime;

                EventManager.ProcessEvents(gameTime);

                var systemsEnumerator = Registery.GetEnumerator();

                while (systemsEnumerator.MoveNext())
                {
                    var system = systemsEnumerator.Current;
                    system.Update(gameTime);
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
