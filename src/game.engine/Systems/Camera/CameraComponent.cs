namespace Game.Engine.Systems.Camera
{
    public enum CameraType
    {
        Orthographic = 0,
    }

    public class CameraComponent : Component
    {
        public CameraType CameraType { get; set; }

        public float Left { get; set; } = 0f;
        public float Right { get; set; } = 0f;
        public float Top { get; set; } = 0f;
        public float Bottom { get; set; } = 0f;

        public Matrix4 ViewMatrix { get; set; }
        public Matrix4 ProjectionMatrix { get; set; }
        public Matrix4 ViewProjectionMatrix { get; set; }
    }
}