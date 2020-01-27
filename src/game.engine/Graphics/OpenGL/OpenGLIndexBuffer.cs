using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Graphics.OpenGL
{
    public class OpenGLIndexBuffer
    {
        private uint _rendererId;
        public OpenGLIndexBuffer(float[] indices, UInt32 count)
        {
            GL.CreateBuffers(1, ref _rendererId);
            GL.BindBuffer(GL.ARRAY_BUFFER, _rendererId);
            GL.BufferData(GL.ARRAY_BUFFER, new IntPtr(indices.Length * sizeof(float)), indices, GL.STATIC_DRAW);
        }

        ~OpenGLIndexBuffer()
        {
            GL.DeleteBuffers(1, ref _rendererId);
        }

        public void Bind()
        {
            GL.BindBuffer(GL.ELEMENT_ARRAY_BUFFER, _rendererId);
        }

        public void Unbind()
        {
            GL.BindBuffer(GL.ELEMENT_ARRAY_BUFFER, 0);
        }
    }
}
