using Game.Engine.EntityComponentSystem;
using Game.Engine.Renderer;
using Game.Engine.Systems.Camera;
using Game.Engine.Systems.Renderer;
using Game.Engine.Systems.Transform;
using System;
using System.Linq;

namespace Game.Engine.Systems
{
    public class RenderSystem : EntitySystem
    {
        public RenderSystem()
        {
            Renderer = RendererAPI.GetAPI();
            Camera = new OrthographicCamera(-1.6f, 1.6f, -0.9f, 0.9f);
        }

        public RendererAPI Renderer { get; private set; }
        public OrthographicCamera Camera { get; private set; }

        public override void Update(GameTime gameTime)
        {
            var components = Registery.GetComponentsOf<RenderComponent>();
            var camera = Registery.GetComponentsOf<CameraComponent>().FirstOrDefault();

            RenderCommand.SetClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            RenderCommand.Clear();

            Render.BeginScene(camera.ViewProjectionMatrix);

            foreach (var c in components)
            {
                var transform = c.Record.GetComponent<TransformComponent>()?.Transform ?? Matrix4.Identity();
                Render.Submit(c.ShaderProgram, c.VertexArray, transform);
            }

            Render.EndScene();
        }
    }
}