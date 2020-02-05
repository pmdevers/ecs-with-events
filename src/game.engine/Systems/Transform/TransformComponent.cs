namespace Game.Engine.Systems.Transform
{
    public class TransformComponent : Component
    {
        public Vector3 Position => new Vector3(X, Y, Z);
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; }
        public Matrix4 Transform { get; set; }
    }
}