using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public abstract class VertexBufferArray
    {
        public abstract uint VertexBufferArrayObject { get; }
        public abstract void Delete();
        public abstract void Bind();
        public abstract void Unbind();
    }
}
