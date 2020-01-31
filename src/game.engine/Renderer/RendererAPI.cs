using Game.Engine.Graphics.OpenGL;
using System;

namespace Game.Engine.Renderer
{
    public enum API
    {
        None = 0,
        OpenGL = 1,
    }
    public abstract class RendererAPI
    {
        public static API Api = API.OpenGL;
        public static IRenderAPI GetAPI()
        {
            switch (Api)
            {
                case API.None:
                    throw new NotImplementedException();
                case API.OpenGL:
                    return new OpenGLRendererAPI();
            }

            throw new NotSupportedException();
        }
    }
}
