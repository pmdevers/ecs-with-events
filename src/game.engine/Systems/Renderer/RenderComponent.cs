using Game.Engine.Renderer;
using System.Collections.Generic;

namespace Game.Engine.Systems.Renderer
{
    public class RenderComponent : Component
    {
        private VertexArray _va;
        private ShaderProgram _sp;

        public VertexArray VertexArray
        {
            get
            {
                _va ??= Init();
                return _va;
            }
        }

        public ShaderProgram ShaderProgram
        {
            get
            {
                _sp ??= ShaderProgram.Create(Shader);
                return _sp;
            }
        }

        public string Shader { get; set; }
        public float[] Verteces { get; set; }
        public int[] Indecies { get; set; }
        public Dictionary<string, ShaderDataType> BufferLayout { get; set; } = new Dictionary<string, ShaderDataType>();

        private VertexArray Init()
        {
            var va = VertexArray.Create();
            var vb = VertexBuffer.Create(Verteces);

            vb.BufferLayout = new BufferLayout(BufferLayout);
            va.AddVertexBuffer(vb);
            va.SetIndexBuffer(IndexBuffer.Create(Indecies));
            return va;
        }
    }
}