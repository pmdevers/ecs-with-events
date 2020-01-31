using System;
using System.Runtime.InteropServices;

using Game.Engine.EntityComponentSystem;
using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Graphics;
using Game.Engine.Graphics.OpenGL;
using Game.Engine.Graphics.OpenGL.Shaders;
using Game.Engine.Renderer;
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
        

        private VertexArray _Square_va;
        private VertexArray _vao;
        
        private ShaderProgram shader;
        private ShaderProgram _blue_shader;

        public Game()
        {
            Registery = new SystemRegistery();
            EntityRegistery = new EntityRegistery();
            EntityLoader = new EntityLoader(EntityRegistery);
            Window = new Window(1024, 786, "Game.Engine");
            Window.Init();
            Renderer = RendererAPI.GetAPI();

            var vertexShader =  @"
                #version 430 
 
                layout(location = 0) in vec3 a_position; 
                layout(location = 1) in vec4 a_color;

                out vec3 v_position;
                out vec4 v_color;

                void main() { 
                    v_position = a_position;
                    v_color = a_color;
	                gl_Position = vec4(a_position, 1.0); 
                }
            ";

            var fragmentShader = @"
                #version 430
 
                layout(location = 0) out vec4 color;

                in vec3 v_position;
                in vec4 v_color;

 
                void main() 
                { 
                    color = v_color; 
                }
            ";


            shader = ShaderProgram.Create(vertexShader, fragmentShader, null);

            _vao = VertexArray.Create();

            var vbo = VertexBuffer.Create(new float[]
            {
                -0.5f, -0.5f, 0.0f, 0.8f, 0.2f, 0.8f, 1.0f,
                 0.5f, -0.5f, 0.0f, 0.2f, 0.8f, 0.8f, 1.0f,
                 0.0f,  0.5f, 0.0f, 0.8f, 0.8f, 0.2f, 1.0f
            });

            BufferLayout layout = new BufferLayout(new[] { 
                new BufferElement(ShaderDataType.Float3, "a_Position"),
                new BufferElement(ShaderDataType.Float4, "a_Color"),
            });

            vbo.BufferLayout = layout;

            _vao.AddVertexBuffer(vbo);

            var ibo = IndexBuffer.Create(new int[] { 0, 1, 2 });

            _vao.SetIndexBuffer(ibo);

            _Square_va = VertexArray.Create();
            var Square_vb = VertexBuffer.Create(new float[]
            {
                -0.75f, -0.75f, 0.0f,
                 0.75f, -0.75f, 0.0f,
                 0.75f,  0.75f, 0.0f,
                -0.75f,  0.75f, 0.0f,
            });

            var layout1 = new BufferLayout(new[] {
                new BufferElement(ShaderDataType.Float3, "a_Position"),
            });

            Square_vb.BufferLayout = layout1;
            _Square_va.AddVertexBuffer(Square_vb);

            var Square_ib = IndexBuffer.Create(new[] { 0, 1, 2, 2, 3, 0 });
            _Square_va.SetIndexBuffer(Square_ib);

            var bleuVertexShader1 = @"
                #version 430 
 
                layout(location = 0) in vec3 a_position; 

                out vec3 v_position;

                void main() { 
                    v_position = a_position;
	                gl_Position = vec4(a_position, 1.0); 
                }
            ";

            var blueFragmentShader1 = @"
                #version 430
 
                layout(location = 0) out vec4 color;

                in vec3 v_position;
                in vec4 v_color;

                void main() 
                { 
                    color = vec4(0.2, 0.3, 0.8, 1.0); 
                }
            ";


            _blue_shader = ShaderProgram.Create(bleuVertexShader1, blueFragmentShader1, null);

            EventManager.RegisterListener<CloseWindowEvent>(WindowClosed);
        }

        public ISystemRegistery Registery { get; }
        public IEntityRegistery EntityRegistery { get; }
        public EntityLoader EntityLoader { get; }
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
                RenderCommand.SetClearColor(0.1f, 0.1f, 0.1f, 1.0f);
                RenderCommand.Clear();
                
                Render.BeginScene();

                _blue_shader.Bind();
                Render.Submit(_Square_va);
                
                shader.Bind();
                Render.Submit(_vao);

                Render.EndScene();

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
