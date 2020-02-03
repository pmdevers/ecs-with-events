using Game.Engine.Renderer;
using System;
using System.Collections.Generic;

using static Game.Glfw.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class OpenGLVertexArray : VertexArray
    {
        private readonly List<VertexBuffer> _vertexBuffers = new List<VertexBuffer>();
        private IndexBuffer _indexBuffer;
        private readonly uint _vertexArrayObject;

        public OpenGLVertexArray()
        {
            var ids = new uint[1];
            GenVertexArrays(1, ids);
            _vertexArrayObject = ids[0];

            Bind();
        }

        public uint VertexArrayObject => _vertexArrayObject;

        public override void Delete()
        {
            DeleteVertexArrays(1, new[] { _vertexArrayObject });
        }

        public override void Bind()
        {
            BindVertexArray(_vertexArrayObject);
        }

        public override void Unbind()
        {
            BindVertexArray(0);
        }

        public override void AddVertexBuffer(VertexBuffer vertexBuffer)
        {
            if (vertexBuffer.BufferLayout == null)
            {
                Console.WriteLine("BufferLayout Not set");
            }

            BindVertexArray(_vertexArrayObject);
            vertexBuffer.Bind();

            uint index = 0;
            var layout = vertexBuffer.BufferLayout;
            foreach (var element in layout.Elements)
            {
                EnableVertexAttribArray(index);
                VertexAttribPointer(index,
                    element.GetComponentCount(),
                    element.Type.ToOpenGL(),
                    element.Normalized,
                    layout.GetStride(),
                    new IntPtr(element.Offset));
                index++;
            }

            _vertexBuffers.Add(vertexBuffer);
        }

        public override void SetIndexBuffer(IndexBuffer indexBuffer)
        {
            BindVertexArray(_vertexArrayObject);
            indexBuffer.Bind();

            _indexBuffer = indexBuffer;
        }

        public override VertexBuffer[] GetVertexBuffers()
        {
            return _vertexBuffers.ToArray();
        }

        public override IndexBuffer GetIndexBuffer()
        {
            return _indexBuffer;
        }
    }
}