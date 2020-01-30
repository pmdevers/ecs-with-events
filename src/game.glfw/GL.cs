﻿using System;
using System.Runtime.InteropServices;
using System.Text;

using game.glfw;

namespace game.OpenGL
{
    public static class GL
    {
        public const int ARRAY_BUFFER                       = 0x8892;
        public const int ELEMENT_ARRAY_BUFFER               = 0x8893;
        public const int STATIC_DRAW                        = 0x88E4;
        public const uint UNSIGNED_INT                      = 0x1405;
        public const int FLOAT                              = 0x1406;

        public const int TRIANGLES                          = 0x0004;
        public const int COLOR_BUFFER_BIT                   = 0x4000;

        public const uint VENDOR                         = 0x1F00;
        public const uint RENDERER                       = 0x1F01;
        public const uint VERSION                        = 0x1F02;
        public const uint EXTENSIONS                     = 0x1F03;
        public const uint SHADING_LANGUAGE_VERSION       = 0x18B8C;

        public const uint FRAGMENT_SHADER = 0x8B30;
        public const uint VERTEX_SHADER = 0x8B31;
        public const uint GEOMETRY_SHADER = 0x8DD9;
        public const uint TEST_CONTROL_SHADER = 0x8E88;
        public const uint TEST_EVALUATION_SHADER = 0x8E87;
        public const uint COMPUTE_SHADER = 0x91B9;

        public const uint ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 0x8A35;
        public const uint ACTIVE_UNIFORM_BLOCKS = 0x8A36;
        public const uint DELETE_STATUS = 0x8B80;
        public const uint LINK_STATUS = 0x8B82;
        public const uint VALIDATE_STATUS = 0x8B83;
        public const uint INFO_LOG_LENGTH = 0x8B84;
        public const uint ATTACHED_SHADERS = 0x8B85;
        public const uint ACTIVE_UNIFORMS = 0x8B86;
        public const uint ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
        public const uint ACTIVE_ATTRIBUTES = 0x8B89;
        public const uint ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
        public const uint TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76;
        public const uint TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
        public const uint TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;
        public const uint GEOMETRY_VERTICES_OUT = 0x8DDA;
        public const uint GEOMETRY_INPUT_TYPE = 0x8DDB;
        public const uint GEOMETRY_OUTPUT_TYPE = 0x8DDC;
        
        
        public const uint COMPILE_STATUS = 0;

        private const string OPENGL_DLL = "opengl32";

        [DllImport(OPENGL_DLL, EntryPoint = "glDrawArrays")] 
        public static extern void DrawArrays(int mode, int first, int count);

        public delegate void glAttachShader(uint program, uint shader);
        public delegate void glCreateBuffers(int n, ref uint buffers);
        public delegate void glDeleteBuffers(int n, ref uint buffers);
        public delegate void glGenBuffers(int n, ref uint buffers);
        public delegate void glBindBuffer(uint target, uint buffer);
        public delegate void glBufferData(uint target, int size, IntPtr data, uint usage);
        public delegate uint glCreateProgram();

        public delegate void glDeleteProgram(uint program);
        public delegate void glCreateProgramPipelines(int n, uint[] pipelines);
        public delegate void glEnableVertexAttribArray(uint index);
        public delegate void glVertexAttribPointer(uint indx, int size, uint type, bool normalized, int stride, IntPtr ptr);
        public delegate void glGenVertexArrays(int n, ref uint arrays);
        public delegate void glBindVertexArray(uint array);
        public delegate void glClearColor(float r, float g, float b, float a);
        public delegate void glClear(int mask);
        public delegate sbyte glGetString(uint name);
        public delegate void glGetIntegerv (uint pname, int[] parameters);
        public delegate void glDrawElements(int mode, int count, uint type, IntPtr indices);
        public delegate uint glCreateShader(uint type);
        public delegate void glShaderSource(uint shader, int count, string _string, ref int length);
        public delegate void glCompileShader(uint shader);
        public delegate void glGetShaderiv(uint shader, uint pname, ref int _params);
        public delegate void glGetShaderInfoLog(uint shader, int maxLength, ref int length, StringBuilder infoLog);
        public delegate void glDeleteShader(uint shader);

        public delegate void glLinkProgram(uint program);
        public delegate void glGetProgramiv(uint program, uint pname, ref int @params);
        public delegate void glGetProgramInfoLog(uint program, int maxLength, ref int length, StringBuilder infoLog);
        public delegate void glDetachShader(uint program, uint shader);


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
        }
        
    }
}
