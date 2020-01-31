using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public enum RendererAPI
    {
        none = 0,
        OpenGL = 1,
    }
    public class Renderer
    {
        private static RendererAPI rendererAPI = RendererAPI.OpenGL;
        public static RendererAPI GetAPI()
        {
            return rendererAPI;
        }
    }
}
