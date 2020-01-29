﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace Game.Engine.Graphics.OpenGL
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

        public const uint VERTEX_SHADER = 0;
        public const uint COMPILE_STATUS = 0;
        public const uint INFO_LOG_LENGTH = 0;

        private const string OPENGL_DLL = "opengl32";

        [DllImport(OPENGL_DLL, EntryPoint = "glDrawArrays")] 
        public static extern void DrawArrays(int mode, int first, int count);


        public delegate void glCreateBuffers(int n, ref uint buffers);
        public delegate void glDeleteBuffers(int n, ref uint buffers);
        public delegate void glGenBuffers(int n, ref uint buffers);
        public delegate void glBindBuffer(uint target, uint buffer);
        public delegate void glBufferData(uint target, IntPtr size, float[] data, uint usage);
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




        public static glDrawElements DrawElements;
        public static glCreateBuffers CreateBuffers;
        public static glDeleteBuffers DeleteBuffers;
        public static glGenBuffers GenBuffers;
        public static glBindBuffer BindBuffer;
        public static glBufferData BufferData;
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
        }
        
    }
}