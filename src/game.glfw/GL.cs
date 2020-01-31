using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Game.Glfw
{
    public static partial class GL
    {
        public static glAttachShader AttachShader;
        public static glDrawElements DrawElements;
        public static glCreateBuffers CreateBuffers;
        public static glDeleteBuffers DeleteBuffers;
        public static glGenBuffers GenBuffers;
        public static glBindBuffer BindBuffer;
        public static glBufferData BufferData;
        public static glCreateProgram CreateProgram;
        public static glDeleteProgram DeleteProgram;
        public static glEnableVertexAttribArray EnableVertexAttribArray;
        public static glVertexAttribPointer VertexAttribPointer;
        public static glGenVertexArrays GenVertexArrays;
        public static glBindVertexArray BindVertexArray;
        public static glDeleteVertexArrays DeleteVertexArrays;
        public static glClearColor ClearColor;
        public static glClear Clear;
        public static glGetString GetString;
        public static glGetIntegerv GetInteger;

        public static glCreateShader CreateShader;
        public static glShaderSource ShaderSource;
        public static glCompileShader CompileShader;
        public static glGetShaderiv GetShaderiv;
        public static glGetShaderInfoLog GetShaderInfoLog;
        public static glDeleteShader DeleteShader;
        public static glLinkProgram LinkProgram;
        public static glGetProgramiv GetProgramiv;
        public static glGetProgramInfoLog GetProgramInfoLog;
        public static glUseProgram UseProgram;
        public static glDetachShader DetachShader;

        private static T GetMethod<T>()
        {
            var funcPtr = GLFW.GetProcAddress(typeof(T).Name);
            if (funcPtr == IntPtr.Zero)
            {
                Console.WriteLine($"Unable to load Function Pointer: {typeof(T).Name}");
                return default(T);
            }
            return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
        }

        public static void LoadFunctionPointers()
        {
            DrawElements = GetMethod<glDrawElements>();
            CreateBuffers = GetMethod<glCreateBuffers>();
            DeleteBuffers = GetMethod<glDeleteBuffers>();
            GenBuffers = GetMethod<glGenBuffers>();
            BindBuffer = GetMethod<glBindBuffer>();
            BufferData = GetMethod<glBufferData>();
            EnableVertexAttribArray = GetMethod<glEnableVertexAttribArray>();
            VertexAttribPointer = GetMethod<glVertexAttribPointer>();
            GenVertexArrays = GetMethod<glGenVertexArrays>();
            DeleteVertexArrays = GetMethod<glDeleteVertexArrays>();
            BindVertexArray = GetMethod<glBindVertexArray>();
            ClearColor = GetMethod<glClearColor>();
            Clear = GetMethod<glClear>();
            GetString = GetMethod<glGetString>();


            CreateShader = GetMethod<glCreateShader>();
            ShaderSource = GetMethod<glShaderSource>();
            CompileShader = GetMethod<glCompileShader>();
            GetShaderiv = GetMethod<glGetShaderiv>();
            AttachShader = GetMethod<glAttachShader>();
            CreateProgram = GetMethod<glCreateProgram>();
            DeleteProgram = GetMethod<glDeleteProgram>();
            GetShaderInfoLog = GetMethod<glGetShaderInfoLog>();
            DeleteShader = GetMethod<glDeleteShader>();
            LinkProgram = GetMethod<glLinkProgram>();
            GetProgramiv = GetMethod<glGetProgramiv>();
            GetProgramInfoLog = GetMethod<glGetProgramInfoLog>();
            DetachShader = GetMethod<glDetachShader>();
            UseProgram = GetMethod<glUseProgram>();
        }
        
    }
}
