using Game.Engine.EntityComponentSystem;
using Game.Engine.Systems.Position;
using System;
using System.Linq;

namespace Game.Engine.Systems.Camera
{
    public class CameraSystem : EntitySystem
    {
        public override void Update(GameTime gameTime)
        {
            var camera = Registery.GetComponentsOf<CameraComponent>().FirstOrDefault();
            var position = camera.Record.GetComponent<PositionComponent>();

            switch (camera.CameraType)
            {
                case CameraType.Orthographic:

                    camera.ProjectionMatrix = Math1.Ortho(camera.Left, camera.Right, camera.Bottom, camera.Top, -1.0f, 1.0f);
                    var transform = Math1.Translate(Matrix4.Identity(), new Vector3(position.X, position.Y, position.Z))
                        * Math1.Rotate(Matrix4.Identity(), Math1.Radians(position.Rotation), new Vector3(0, 0, 1));

                    camera.ViewMatrix = transform.Inverse();
                    camera.ViewProjectionMatrix = camera.ProjectionMatrix * camera.ViewMatrix;
                    break;
            }

            base.Update(gameTime);
        }
    }
}