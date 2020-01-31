using Game.Engine.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public abstract class VertexBuffer
    {
        public static VertexBuffer Create(float[] data)
        {
            switch (RendererAPI.Api)
            {
                case API.None:
                    throw new NotSupportedException();
                case API.OpenGL:
                    return new OpenGLVertexBuffer(data);
            }

            throw new NotImplementedException();
        }
        public abstract BufferLayout BufferLayout { get; set; }
        public abstract bool IsCreated();
        public abstract void Bind();
        public abstract void Unbind();
    }
}
