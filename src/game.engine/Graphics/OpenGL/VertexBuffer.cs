using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using static Game.Glfw.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class VertexBuffer
    {
        private readonly uint _vertexBufferObject;
        public VertexBuffer()
        {
            var ids = new uint[] { 0 };
            CreateBuffers(1, ids);
            _vertexBufferObject = ids[0];
        }

        public uint VertexBufferObject => _vertexBufferObject;

        public void SetData(uint attributeIndex, float[] data, bool isNormalized, int stride)
        {
            IntPtr p = Marshal.AllocHGlobal(data.Length * sizeof(float));
            Marshal.Copy(data, 0, p, data.Length);
            BufferData(ARRAY_BUFFER, data.Length * sizeof(float), p, STATIC_DRAW);
            Marshal.FreeHGlobal(p);

            VertexAttribPointer(attributeIndex, data.Length * sizeof(float), FLOAT, isNormalized, stride, IntPtr.Zero);
            EnableVertexAttribArray(attributeIndex);
        }

        public bool IsCreated() { return _vertexBufferObject != 0; }

        public void Bind()
        {
            BindBuffer(ARRAY_BUFFER, _vertexBufferObject);
        }

        public void Unbind()
        {
            BindBuffer(ARRAY_BUFFER, 0);
        }
    }
}
