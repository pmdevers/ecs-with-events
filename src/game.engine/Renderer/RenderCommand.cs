namespace Game.Engine.Renderer
{
    public class RenderCommand
    {
        public static void SetClearColor(float red, float green, float blue, float alpha)
        {
            RendererAPI.GetAPI().SetClearColor(red, green, blue, alpha);
        }

        public static void Clear()
        {
            RendererAPI.GetAPI().Clear();
        }

        public static void DrawIndexed(VertexArray vertexArray)
        {
            RendererAPI.GetAPI().DrawIndexed(vertexArray);
        }
    }
}