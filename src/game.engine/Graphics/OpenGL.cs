using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Game.Engine.Graphics
{
    public static class OpenGL
    {
        private const string OPENGL_DLL = "opengl32";

        private static Func<string, IntPtr> _func;

        public static void SetGraphicsDevice(Func<string, IntPtr> func)
        {
            _func = func;
            LoadFunctionPointers();
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

        public static glGenBuffers GenBuffers;
        public static glBindBuffer BindBuffer;
        public static glBufferData BufferData;
        public static glEnableVertexAttribArray EnableVertexAttribArray;
        public static glVertexAttribPointer VertexAttribPointer;
        public static glGenVertexArrays GenVertexArrays;
        public static glBindVertexArray BindVertexArray;
        public static glClearColor ClearColor;
        public static glClear Clear;

        private static T GetMethod<T>()
        {
            var funcPtr = _func(typeof(T).Name);
            if (funcPtr == IntPtr.Zero)
            {
                Console.WriteLine($"Unable to load Function Pointer: {typeof(T).Name}");
                return default(T);
            }
            return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
        }

        private static void LoadFunctionPointers()
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
