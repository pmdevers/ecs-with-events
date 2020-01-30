using System;
using System.Collections.Generic;
using System.Text;

using game.glfw;
using static game.OpenGL.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class VertexBuffer
    {
        private uint _rendererId;
        public VertexBuffer(float[] vertices, IntPtr size)
        {
            CreateBuffers(1, ref _rendererId);
            BindBuffer(ARRAY_BUFFER, _rendererId);
            BufferData(ARRAY_BUFFER, size, vertices, STATIC_DRAW);
        }

        ~VertexBuffer()
        {
            DeleteBuffers(1, ref  _rendererId);
        }

        public void Bind()
        {
            BindBuffer(ARRAY_BUFFER, _rendererId);
        }

        public void Unbind()
        {
            BindBuffer(ARRAY_BUFFER, 0);
        }
    }
}
