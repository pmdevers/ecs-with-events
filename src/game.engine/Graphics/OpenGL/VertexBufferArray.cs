using System.ComponentModel;

using static Game.Glfw.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class VertexBufferArray
    {
        private readonly uint _vertexArrayObject;
        public VertexBufferArray()
        {
            var ids = new uint[1];
            GenVertexArrays(1, ids);
            _vertexArrayObject = ids[0];
        }

        public uint VertexBufferArrayObject => _vertexArrayObject; 

        public void Delete()
        {
            DeleteVertexArrays(1, new [] { _vertexArrayObject });
        }

        public void Bind()
        {
            BindVertexArray(_vertexArrayObject);
        }

        public void Unbind()
        {
            BindVertexArray(0);
        }
    }
}
