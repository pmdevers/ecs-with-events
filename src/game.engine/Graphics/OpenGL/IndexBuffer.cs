using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using game.glfw;
using static game.OpenGL.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class IndexBuffer
    {
        private uint _rendererId;

        public IndexBuffer(uint[] indices)
        {
            CreateBuffers(1, ref _rendererId);
            BindBuffer(ARRAY_BUFFER, _rendererId);

            GCHandle handle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();

            BufferData(ARRAY_BUFFER, indices.Length * sizeof(uint), ptr, STATIC_DRAW);

            handle.Free();
        }

        public IndexBuffer(float[] indices)
        {
            CreateBuffers(1, ref _rendererId);
            BindBuffer(ARRAY_BUFFER, _rendererId);

            GCHandle handle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();

            BufferData(ARRAY_BUFFER, indices.Length * sizeof(float), ptr, STATIC_DRAW);

            handle.Free();
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
