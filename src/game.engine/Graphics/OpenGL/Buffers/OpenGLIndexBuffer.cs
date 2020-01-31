using Game.Engine.Renderer;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using static Game.Glfw.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class OpenGLIndexBuffer : IndexBuffer
    {
        private readonly uint _bufferObject;
        private readonly int[] _data;

        public OpenGLIndexBuffer(int[] data)
        {
            _data = data;

            var ids = new uint[1];
            GenBuffers(1, ids);
            _bufferObject = ids[0];

            Bind();
            SetData();
        }

        public uint IndexBufferObject => _bufferObject;
        public override bool IsCreated() { return _bufferObject != 0; }

        public override int GetCount()
        {
            return _data.Length;
        }

       

        public override void Bind()
        {
            BindBuffer(ELEMENT_ARRAY_BUFFER, _bufferObject);
        }

        public override void Unbind()
        {
            BindBuffer(ELEMENT_ARRAY_BUFFER, 0);
        }

        private void SetData()
        {
            IntPtr p = Marshal.AllocHGlobal(_data.Length * sizeof(int));
            Marshal.Copy(_data, 0, p, _data.Length);
            BufferData(ELEMENT_ARRAY_BUFFER, _data.Length * sizeof(int), p, STATIC_DRAW);
            Marshal.FreeHGlobal(p);
        }
    }
}
