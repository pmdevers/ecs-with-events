using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public abstract class IndexBuffer
    {
        public abstract uint IndexBufferObject { get; }
        public abstract bool IsCreated();
        public abstract void Bind();
        public abstract void Unbind();
    }
}
