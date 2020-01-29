using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Graphics.OpenGL
{
    public class VertexBuffer
    {
        private uint _rendererId;
        public VertexBuffer(float[] vertices, IntPtr size)
        {
            GL.CreateBuffers(1, ref _rendererId);
            GL.BindBuffer(GL.ARRAY_BUFFER, _rendererId);
            GL.BufferData(GL.ARRAY_BUFFER, size, vertices, GL.STATIC_DRAW);
        }

        ~VertexBuffer()
        {
            GL.DeleteBuffers(1, ref  _rendererId);
        }

        public void Bind()
        {
            GL.BindBuffer(GL.ARRAY_BUFFER, _rendererId);
        }

        public void Unbind()
        {
            GL.BindBuffer(GL.ARRAY_BUFFER, 0);
        }
    }
}
