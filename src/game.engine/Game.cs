using System;
using System.Runtime.InteropServices;

using Game.Engine.EntityComponentSystem;
using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Graphics;
using Game.Engine.Graphics.OpenGL;
using Game.Engine.Systems;
using Game.Engine.Tools;

using game.glfw;
using static game.OpenGL.GL;

namespace Game.Engine
{
    public class Game
    {
        public static readonly EventManager EventManager = new EventManager();
        private bool _isRunning;
        private DateTime _previousGameTime;

        float[] vertices =
            {
                -0.5f, -0.5f, 0.0f,
                0.5f, -0.5f, 0.0f,
                0.0f, 0.5f, 0.0f,
            };

        uint _vertexArray = 0, _vertexBuffer = 0, _indexBuffer = 0;


        public Game()
        {
            Registery = new SystemRegistery();
            EntityRegistery = new EntityRegistery();
            EntityLoader = new EntityLoader(EntityRegistery);
            Window = new Window(1024, 786, "Game.Engine");
            Window.Init();


            GenVertexArrays(1, ref _vertexArray);
            BindVertexArray(_vertexArray);

            //var vertexBuffer = new VertexBuffer(vertices);

            GenBuffers(1, ref _vertexBuffer);
            BindBuffer(ARRAY_BUFFER, _vertexBuffer);
            GCHandle vertsHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            IntPtr vertsPtr = vertsHandle.AddrOfPinnedObject();
            BufferData(ARRAY_BUFFER, new IntPtr(sizeof(float) * vertices.Length), vertsPtr, STATIC_DRAW);
            vertsHandle.Free();

            EnableVertexAttribArray(0);
            VertexAttribPointer(0, 3, FLOAT, false, 3 * sizeof(uint), IntPtr.Zero);

            GenBuffers(1, ref _indexBuffer);
            BindBuffer(ELEMENT_ARRAY_BUFFER, _indexBuffer);

            uint[] indeces = { 0, 1, 3 };
            //var indexBuffer = new IndexBuffer(indeces);

            GCHandle indecHandle = GCHandle.Alloc(indeces, GCHandleType.Pinned);
            IntPtr indecPtr = indecHandle.AddrOfPinnedObject();
            BufferData(ELEMENT_ARRAY_BUFFER, new IntPtr(sizeof(uint) * indeces.Length), indecPtr, STATIC_DRAW);

            indecHandle.Free();

            EventManager.RegisterListener<CloseWindowEvent>(WindowClosed);
        }

        public ISystemRegistery Registery { get; }
        public IEntityRegistery EntityRegistery { get; }
        public EntityLoader EntityLoader { get; }
        public Window Window { get; }
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
                ClearColor(0.1f, 0.1f, 0.1f, 1);
                Clear(COLOR_BUFFER_BIT);

                BindVertexArray(_vertexArray);
                DrawElements(TRIANGLES, 3, UNSIGNED_INT, IntPtr.Zero);

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

                Window.Update(gameTime);
            }
        }

        private void WindowClosed(Event e)
        {
            _isRunning = false;
        }
    }
}
