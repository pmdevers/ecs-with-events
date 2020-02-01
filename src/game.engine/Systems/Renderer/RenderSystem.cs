using Game.Engine.Renderer;
using Game.Engine.Systems.Renderer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Systems
{
    public class RenderSystem : EntitySystem
    {
        public RenderSystem()
        {
            Renderer = RendererAPI.GetAPI();
            Camera = new OrthogaphicCamera(-1.6f, 1.6f, -0.9f, 0.9f);

        }

        public IRenderAPI Renderer { get; private set; }
        public OrthogaphicCamera Camera { get; private set; }

        public override void Update(TimeSpan gameTime)
        {
            var components = Registery.GetComponentsOf<RenderComponent>();
            
            RenderCommand.SetClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            RenderCommand.Clear();

            Render.BeginScene(Camera);

            foreach (var c in components)
            {
                Render.Submit(c.Shader, c.VertexArray);
            }

            Render.EndScene();

        }
    }
}
