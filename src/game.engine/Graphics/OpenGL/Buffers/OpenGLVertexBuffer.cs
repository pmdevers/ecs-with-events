using Game.Engine.Renderer;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using static Game.Glfw.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class OpenGLVertexBuffer : VertexBuffer
    {
        private readonly uint _vertexBufferObject;
        public OpenGLVertexBuffer(float[] data)
        {
            var ids = new uint[] { 0 };
            CreateBuffers(1, ids);
            _vertexBufferObject = ids[0];

            Bind();
            SetData(data);
        }

        public uint VertexBufferObject => _vertexBufferObject;

        public override BufferLayout BufferLayout { get; set; }

        public override bool IsCreated() { return _vertexBufferObject != 0; }

        public override void Bind()
        {
            BindBuffer(ARRAY_BUFFER, _vertexBufferObject);
        }

        public override void Unbind()
        {
            BindBuffer(ARRAY_BUFFER, 0);
        }
        
        private void SetData(float[] data)
        {
            IntPtr p = Marshal.AllocHGlobal(data.Length * sizeof(float));
            Marshal.Copy(data, 0, p, data.Length);
            BufferData(ARRAY_BUFFER, data.Length * sizeof(float), p, STATIC_DRAW);
            Marshal.FreeHGlobal(p);
        }

    }
}
