using Game.Engine.EntityComponentSystem;
using Game.Engine.Systems.Transform;
using System;
using System.Linq;

namespace Game.Engine.Systems.Camera
{
    public class CameraSystem : EntitySystem
    {
        public override void Update(GameTime gameTime)
        {
            var camera = Registery.GetComponentsOf<CameraComponent>().FirstOrDefault();
            var transfrom = camera.Record.GetComponent<TransformComponent>();

            switch (camera.CameraType)
            {
                case CameraType.Orthographic:

                    camera.ProjectionMatrix = Math1.Ortho(camera.Left, camera.Right, camera.Bottom, camera.Top, -1.0f, 1.0f);
                    var transform = Math1.Translate(Matrix4.Identity(), transfrom.Position + transfrom.Velocity * (float)gameTime)
                        * Math1.Rotate(Matrix4.Identity(), Math1.Radians(transfrom.Rotation), new Vector3(0, 0, 1));

                    camera.ViewMatrix = transform.Inverse();
                    camera.ViewProjectionMatrix = camera.ProjectionMatrix * camera.ViewMatrix;
                    break;
            }

            base.Update(gameTime);
        }
    }
}