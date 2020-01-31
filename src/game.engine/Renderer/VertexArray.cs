using Game.Engine.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public abstract class VertexArray
    {
        public static VertexArray Create()
        {
            switch (RendererAPI.Api)
            {
                case API.None:
                    throw new NotImplementedException();
                case API.OpenGL:
                    return new OpenGLVertexArray();
            }

            throw new NotSupportedException();
        }

        public abstract void AddVertexBuffer(VertexBuffer vertexBuffer);
        public abstract VertexBuffer[] GetVertexBuffers();
        public abstract IndexBuffer GetIndexBuffer();
        public abstract void SetIndexBuffer(IndexBuffer vertexBuffer);
        public abstract void Delete();
        public abstract void Bind();
        public abstract void Unbind();
    }
}
