namespace Game.Engine.Systems.Camera
{
    public enum CameraType
    {
        Orthographic = 0,
    }

    public class CameraComponent : Component
    {
        public CameraType CameraType { get; set; }

        public float Left { get; set; }
        public float Right { get; set; }
        public float Top { get; set; }
        public float Bottom { get; set; }

        public Vector3 Position { get; set; }
        public float Rotation { get; set; }

        public Matrix4 ViewMatrix { get; set; }
        public Matrix4 ProjectionMatrix { get; internal set; }
        public Matrix4 ViewProjectionMatrix { get; internal set; }
    }
}