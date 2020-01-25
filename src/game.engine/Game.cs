using System;

using Game.Engine.EntityComponentSystem;
using Game.Engine.EventSystem;
using Game.Engine.Graphics;
using Game.Engine.Systems;

namespace Game.Engine
{
    public class Game
    {
        private bool _isRunning;
        private DateTime _previousGameTime;

        public Game()
        {
            Registery = new SystemRegistery();
            EventManager = new EventManager();
            EntityRegistery = new EntityRegistery();
            EntityLoader = new EntityLoader(EntityRegistery);

            Registery.Register(new GraphicsSystem());
        }

        public ISystemRegistery Registery { get; }
        public IEntityRegistery EntityRegistery { get; }
        public EntityLoader EntityLoader { get; }
        public EventManager EventManager { get; }

        public void Run()
        {
            var initiable = Registery.GetEnumerator();
            while (initiable.MoveNext())
            {
                var system = initiable.Current;
                if (system is EntitySystem s)
                    s.Init(EntityRegistery, EventManager);
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
            }
        }
    }
}
