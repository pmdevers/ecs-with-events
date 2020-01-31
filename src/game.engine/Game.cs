using System;
using System.Runtime.InteropServices;

using Game.Engine.EntityComponentSystem;
using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Graphics;
using Game.Engine.Graphics.OpenGL;
using Game.Engine.Graphics.OpenGL.Shaders;
using Game.Engine.Systems;
using Game.Engine.Tools;

using static Game.Glfw.GL;

namespace Game.Engine
{
    public class Game
    {
        public static readonly EventManager EventManager = new EventManager();
        private bool _isRunning;
        private DateTime _previousGameTime;

        private VertexBufferArray _vao;
        private VertexBuffer _vbo;
        private IndexBuffer _ibo;

        private ShaderProgram shader;

        float[] vertices =
            {
            
                -0.5f, -0.5f, 0.0f,
                0.5f, -0.5f, 0.0f,
                0.0f, 0.5f, 0.0f,
            };

        public Game()
        {
            Registery = new SystemRegistery();
            EntityRegistery = new EntityRegistery();
            EntityLoader = new EntityLoader(EntityRegistery);
            Window = new Window(1024, 786, "Game.Engine");
            Window.Init();

            var vertexShader =  @"
                #version 430 
 
                layout(location = 0) in vec3 a_position; 

                out vec3 v_position;

                void main() { 
                    v_position = a_position;
	                gl_Position = vec4(a_position, 1.0); 
                }
            ";

            var fragmentShader = @"
                #version 430
 
                layout(location = 0) out vec4 color;

                in vec3 v_position;
 
                void main() 
                { 
                    color = vec4(v_position * 0.5 + 0.5, 1.0); 
                }
            ";

            shader = new ShaderProgram(vertexShader, fragmentShader, null);
            shader.Bind();


            _vao = new VertexBufferArray();
            _vao.Bind();

                            
            // VERTEXBUFFER
            
            //_vertexBuffer = new uint[] { 0 };
            //GenBuffers(1, _vertexBuffer);
            //BindBuffer(ARRAY_BUFFER, _vertexBuffer[0]);

            //IntPtr p = Marshal.AllocHGlobal(vertices.Length * sizeof(float));
            //Marshal.Copy(vertices, 0, p, vertices.Length);
            //BufferData(ARRAY_BUFFER, vertices.Length * sizeof(float), p, STATIC_DRAW);
            //Marshal.FreeHGlobal(p);
            //EnableVertexAttribArray(0);

            _vbo = new VertexBuffer();
            _vbo.Bind();
            _vbo.SetData(0, vertices, false, 3);

            // INDEXBUFFER

            //_indexBuffer = new uint[] { 0 };

            //GenBuffers(1, _indexBuffer);
            //BindBuffer(ELEMENT_ARRAY_BUFFER, _indexBuffer[0]);
            //var indeces = new uint[] { 0, 1, 2, 3 };
            //GCHandle indecHandle = GCHandle.Alloc(indeces, GCHandleType.Pinned);
            //IntPtr indecPtr = indecHandle.AddrOfPinnedObject();
            //BufferData(ELEMENT_ARRAY_BUFFER, sizeof(uint) * indeces.Length, indecPtr, STATIC_DRAW);

            //indecHandle.Free();

            _ibo = new IndexBuffer();
            _ibo.Bind();
            _ibo.SetData(new int[] { 0, 1, 2, 3 });

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

                _vao.Bind();
                VertexAttribPointer(0, 3, FLOAT, false, 0, IntPtr.Zero);

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
