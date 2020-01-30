using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using game.glfw;
using static game.OpenGL.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class VertexBuffer
    {
        private uint _rendererId;
        public VertexBuffer(float[] vertices)
        {
            CreateBuffers(1, ref _rendererId);
            BindBuffer(ARRAY_BUFFER, _rendererId);
            
            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();
            
            BufferData(ARRAY_BUFFER, sizeof(float) * vertices.Length, ptr, STATIC_DRAW);

            handle.Free();
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
