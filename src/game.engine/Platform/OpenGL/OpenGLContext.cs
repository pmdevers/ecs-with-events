using Game.Glfw;
using System;
using static Game.Glfw.GL;

namespace Game.Engine.Graphics
{
    public class OpenGLContext : IGraphicContext
    {
        private readonly IntPtr windowHandle;

        public OpenGLContext(ref IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
            GLFW.MakeContextCurrent(windowHandle);
            LoadFunctionPointers();
        }

        public void Init()
        {
            Console.WriteLine("OpenGL Info:");
            Console.WriteLine("  Vendor: {0}", GetString(VENDOR));
            Console.WriteLine("  Renderer: {0}", GetString(RENDERER));
            Console.WriteLine("  Version: {0}", GetString(VERSION));
        }

        public void SwapBuffers()
        {
            GLFW.SwapBuffers(windowHandle);
        }
    }
}