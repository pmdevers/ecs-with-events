using Game.Engine.Graphics.OpenGL;
using System;

namespace Game.Engine.Renderer
{
    public abstract class IndexBuffer
    {
        public static IndexBuffer Create(int[] data)
        {
            switch (RendererAPI.Api)
            {
                case API.None:
                    throw new NotSupportedException();
                case API.OpenGL:
                    return new OpenGLIndexBuffer(data);
            }

            throw new NotSupportedException();
        }

        public abstract int GetCount();

        public abstract bool IsCreated();

        public abstract void Bind();

        public abstract void Unbind();
    }
}