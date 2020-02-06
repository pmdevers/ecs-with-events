using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Systems.Transform
{
    public class TransformSystem : EntitySystem
    {
        public override void Update(GameTime gameTime)
        {
            var components = Registery.GetComponentsOf<TransformComponent>();
            foreach (var c in components)
            {
                c.Position += c.Velocity * (float)gameTime;
                var transform = Math1.Translate(Matrix4.Identity(), c.Position);
                var scale = Math1.Scale(Matrix4.Identity(), new Vector3(c.Scale));

                c.Transform = transform * scale;
            }
        }
    }
}