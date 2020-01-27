using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Game.Engine.Graphics
{
    public class OpenGLContext : IGraphicContext
    {
        private readonly Window _window;

        private float[] vertices = {
            -0.5f, -0.5f,
            0.5f, -0.5f,
            0.0f,  0.5f,
        };

        private const int GL_ARRAY_BUFFER = 0x8892;
        private const int GL_STATIC_DRAW = 0x88E4;
        private const int GL_FLOAT = 0x1406;
        private const int GL_TRIANGLES = 0x0004;
        private const int GL_COLOR_BUFFER_BIT = 0x4000;

        private const string OPENGL_DLL = "opengl32";

        public OpenGLContext(Window window)
        {
            _window = window;
            Init();
        }

        public void Init()
        {
            LoadFunctionPointers();

            uint vao = 0;
            GenVertexArrays(1, ref vao);
            BindVertexArray(vao);
            // Create the VBO
            uint vbo = 0;
            GenBuffers(1, ref vbo);
            BindBuffer(GL_ARRAY_BUFFER, vbo);
            BufferData(GL_ARRAY_BUFFER, new IntPtr(sizeof(float) * vertices.Length), vertices, GL_STATIC_DRAW);
            // Draw the Triangle
            EnableVertexAttribArray(0);
            VertexAttribPointer(0, 2, GL_FLOAT, false, 0, IntPtr.Zero);
        }

        public void SwapBuffers()
        {
            ClearColor(0.258824F, 0.258824f, 0.435294f, 1f);
            Clear(GL_COLOR_BUFFER_BIT);
            DrawArrays(GL_TRIANGLES, 0, 3);
        }

        // OpenGL Bindings
        [DllImport(OPENGL_DLL, EntryPoint = "glDrawArrays")] 
        public static extern void DrawArrays(int mode, int first, int count);

        public delegate void glGenBuffers(int n, ref uint buffers);
        public delegate void glBindBuffer(uint target, uint buffer);
        public delegate void glBufferData(uint target, IntPtr size, float[] data, uint usage);
        public delegate void glEnableVertexAttribArray(uint index);
        public delegate void glVertexAttribPointer(uint indx, int size, uint type, bool normalized, int stride, IntPtr ptr);
        public delegate void glGenVertexArrays(int n, ref uint arrays);
        public delegate void glBindVertexArray(uint array);
        public delegate void glClearColor(float r, float g, float b, float a);
        public delegate void glClear(int mask);

        public glGenBuffers GenBuffers;
        public glBindBuffer BindBuffer;
        public glBufferData BufferData;
        public glEnableVertexAttribArray EnableVertexAttribArray;
        public glVertexAttribPointer VertexAttribPointer;
        public glGenVertexArrays GenVertexArrays;
        public glBindVertexArray BindVertexArray;
        public glClearColor ClearColor;
        public glClear Clear;

        private T GetMethod<T>()
        {
            var funcPtr = _window.GetHandle(typeof(T).Name);
            if (funcPtr == IntPtr.Zero)
            {
                Console.WriteLine($"Unable to load Function Pointer: {typeof(T).Name}");
                return default(T);
            }
            return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
        }

        private void LoadFunctionPointers()
        {
            GenBuffers = GetMethod<glGenBuffers>();
            BindBuffer = GetMethod<glBindBuffer>();
            BufferData = GetMethod<glBufferData>();
            EnableVertexAttribArray = GetMethod<glEnableVertexAttribArray>();
            VertexAttribPointer = GetMethod<glVertexAttribPointer>();
            GenVertexArrays = GetMethod<glGenVertexArrays>();
            BindVertexArray = GetMethod<glBindVertexArray>();
            ClearColor = GetMethod<glClearColor>();
            Clear = GetMethod<glClear>();
        }
    }
}
