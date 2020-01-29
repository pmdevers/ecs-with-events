using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using Game.Engine.Graphics.OpenGL;

namespace Game.Engine.Graphics
{
    public class OpenGLContext : IGraphicContext
    {
        private readonly IntPtr windowHandle;

        public OpenGLContext(ref IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
            GLFW.MakeContextCurrent(windowHandle);
            GL.LoadFunctionPointers();   
        }

        public void Init()
        {
            Console.WriteLine("OpenGL Info:");
            Console.WriteLine("  Vendor: {0}", GL.GetString(GL.VENDOR));
            Console.WriteLine("  Renderer: {0}", GL.GetString(GL.RENDERER)); 
            Console.WriteLine("  Version: {0}", GL.GetString(GL.VERSION));
        }

        public void SwapBuffers()
        {
            GLFW.SwapBuffers(windowHandle);
        }
    }
}
