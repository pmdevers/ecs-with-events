using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using static Game.Glfw.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class IndexBuffer
    {
        private readonly uint _bufferObject;

        public IndexBuffer()
        {
            var ids = new uint[1];
            GenBuffers(1, ids);
            _bufferObject = ids[0];
        }

        public uint IndexBufferObject => _bufferObject;
        public bool IsCreated() { return _bufferObject != 0; }

        public void SetData(short[] data)
        {
            IntPtr p = Marshal.AllocHGlobal(data.Length * sizeof(float));
            Marshal.Copy(data, 0, p, data.Length);
            BufferData(ELEMENT_ARRAY_BUFFER, data.Length * sizeof(short), p, STATIC_DRAW);
            Marshal.FreeHGlobal(p);
        }

        public void Bind()
        {
            BindBuffer(ELEMENT_ARRAY_BUFFER, _bufferObject);
        }

        public void Unbind()
        {
            BindBuffer(ELEMENT_ARRAY_BUFFER, 0);
        }
    }
}
