using System;
using System.Collections.Generic;
using System.Text;

using game.glfw;
using static game.OpenGL.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class IndexBuffer
    {
        private uint _rendererId;
        public IndexBuffer(float[] indices, UInt32 count)
        {
            CreateBuffers(1, ref _rendererId);
            BindBuffer(ARRAY_BUFFER, _rendererId);
            BufferData(ARRAY_BUFFER, new IntPtr(indices.Length * sizeof(float)), indices, STATIC_DRAW);
        }

        ~IndexBuffer()
        {
            DeleteBuffers(1, ref _rendererId);
        }

        public void Bind()
        {
            BindBuffer(ELEMENT_ARRAY_BUFFER, _rendererId);
        }

        public void Unbind()
        {
            BindBuffer(ELEMENT_ARRAY_BUFFER, 0);
        }
    }
}
