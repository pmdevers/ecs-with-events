using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using Game.Engine.Graphics.OpenGL;

namespace Game.Engine.Graphics
{
    public class OpenGLContext : IGraphicContext
    {
        private float[] vertices = {
            -0.5f, -0.5f,
            0.5f, -0.5f,
            0.0f,  0.5f,
        };

        public OpenGLContext()
        {
            GL.LoadFunctionPointers();
            Init();
        }

        public void Init()
        {
            Console.WriteLine("OpenGL Info:");
            Console.WriteLine("  Vendor: {0}", GL.GetString(GL.VENDOR));
            Console.WriteLine("  Renderer: {0}", GL.GetString(GL.RENDERER)); 
            Console.WriteLine("  Version: {0}", GL.GetString(GL.VERSION));

            uint vao = 0;
            GL.GenVertexArrays(1, ref vao);
            GL.BindVertexArray(vao);
            // Create the VBO
            uint vbo = 0;
            GL.GenBuffers(1, ref vbo);
            GL.BindBuffer(GL.ARRAY_BUFFER, vbo);
            GL.BufferData(GL.ARRAY_BUFFER, new IntPtr(sizeof(float) * vertices.Length), vertices, GL.STATIC_DRAW);
            // Draw the Triangle
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 2, GL.FLOAT, false, 0, IntPtr.Zero);
        }

        public void SwapBuffers()
        {
            GL.ClearColor(0.258824F, 0.258824f, 0.435294f, 1f);
            GL.Clear(GL.COLOR_BUFFER_BIT);
            GL.DrawArrays(GL.TRIANGLES, 0, 3);
        }

    }
}
