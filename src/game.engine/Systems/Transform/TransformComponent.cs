namespace Game.Engine.Systems.Transform
{
    public class TransformComponent : Component
    {
        //private Vector3 _velocity = new Vector3(0.0f);
        public Vector3 Velocity { get; set; }
        public Vector3 Position { get; set; }= new Vector3(0.0f);
        public float Rotation { get; set; } = 0.0f;
        public float Scale { get; set; } = 1.0f;
        public Matrix4 Transform { get; set; } = Matrix4.Identity();
    }
}