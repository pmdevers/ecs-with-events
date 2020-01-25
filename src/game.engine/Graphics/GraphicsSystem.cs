using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Game.Engine.Graphics
{
    public class GraphicsSystem : ISystem
    {
        private const int GL_ARRAY_BUFFER = 0x8892;
        private const int GL_STATIC_DRAW = 0x88E4;
        private const int GL_FLOAT = 0x1406;
        private const int GL_TRIANGLES = 0x0004;
        private const int GL_COLOR_BUFFER_BIT = 0x4000;


        private const string GLFW_DLL = "glfw3";
        private readonly IntPtr _window;

        

        // GLFW Bindings
        [DllImport(GLFW_DLL, EntryPoint = "glfwInit")] private static extern bool Initialise();
        [DllImport(GLFW_DLL, EntryPoint = "glfwCreateWindow")] private static extern IntPtr CreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share);
        [DllImport(GLFW_DLL, EntryPoint = "glfwMakeContextCurrent")] private static extern void MakeContextCurrent(IntPtr window);
        [DllImport(GLFW_DLL, EntryPoint = "glfwSwapBuffers")] private static extern void SwapBuffers(IntPtr window);
        [DllImport(GLFW_DLL, EntryPoint = "glfwGetProcAddress")] private static extern IntPtr GetProcAddress(string procname);
        [DllImport(GLFW_DLL, EntryPoint = "glfwPollEvents")] private static extern void PollEvents();
        [DllImport(GLFW_DLL, EntryPoint = "glfwWindowShouldClose")] private static extern int WindowShouldClose(IntPtr window);

        private static float[] vertices = {
            -0.5f, -0.5f,
            0.5f, -0.5f,
            0.0f,  0.5f,
        };

        public GraphicsSystem()
        {
            Initialise();
            _window = CreateWindow(1024, 768, ".NET Core Graphics Example", IntPtr.Zero, IntPtr.Zero);
            MakeContextCurrent(_window);
            OpenGL.SetGraphicsDevice(GetProcAddress);
            uint vao = 0;
            OpenGL.GenVertexArrays(1, ref vao);
            OpenGL.BindVertexArray(vao);
            // Create the VBO
            uint vbo = 0;
            OpenGL.GenBuffers(1, ref vbo);
            OpenGL.BindBuffer(GL_ARRAY_BUFFER, vbo);
            OpenGL.BufferData(GL_ARRAY_BUFFER, new IntPtr(sizeof(float) * vertices.Length), vertices, GL_STATIC_DRAW);
            // Draw the Triangle
            OpenGL.EnableVertexAttribArray(0);
            OpenGL.VertexAttribPointer(0, 2, GL_FLOAT, false, 0, IntPtr.Zero);
            do
            {
                OpenGL.ClearColor(0.258824F, 0.258824f, 0.435294f, 1f);
                OpenGL.Clear(GL_COLOR_BUFFER_BIT);
                OpenGL.DrawArrays(GL_TRIANGLES, 0, 3);
                SwapBuffers(_window);
                PollEvents();
            } while (WindowShouldClose(_window) == 0);
        }

        public void Update(TimeSpan gameTime)
        {
        }
    }
}
