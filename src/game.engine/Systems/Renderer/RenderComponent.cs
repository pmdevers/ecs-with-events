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
                _va = _va ?? Init();
                return _va;
            }
        }

        public ShaderProgram Shader
        {
            get
            {
                _sp = _sp ?? ShaderProgram.Create(VertexShader, FragmentShader, null);
                return _sp;
            }
        }

        public string VertexShader { get; set; }
        public string FragmentShader { get; set; }
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