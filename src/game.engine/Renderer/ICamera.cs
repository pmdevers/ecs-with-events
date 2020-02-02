namespace Game.Engine.Renderer
{
    public interface ICamera
    {
        Vector3 Position { get; set; }
        Matrix4 ProjectionMatrix { get; }
        float Rotation { get; set; }
        Matrix4 ViewMatrix { get; }
        Matrix4 ViewProjectionMatrix { get; }
    }
}