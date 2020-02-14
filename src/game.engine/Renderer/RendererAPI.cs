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

        public static RendererAPI GetAPI()
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

        public abstract void SetClearColor(float red, float green, float blue, float alpha);

        public abstract void Clear();

        public abstract void RenderText(string text, float x, float y, float sx, float sy);
        public abstract void DrawIndexed(VertexArray vertexArray);
    }
}