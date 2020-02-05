namespace Game.Engine.Renderer
{
    public static class Render
    {
        private static Matrix4 _viewProjectionMatrix;

        public static void BeginScene(Matrix4 viewProjectionMatrix)
        {
            _viewProjectionMatrix = viewProjectionMatrix;
        }

        public static void EndScene()
        {
        }

        public static void Submit(ShaderProgram shader, VertexArray vertexArray, Matrix4 transform)
        {
            shader.Bind();
            shader.UploadUniformMatrix("u_ViewProjection", _viewProjectionMatrix);
            shader.UploadUniformMatrix("u_Transform", transform);

            vertexArray.Bind();
            RenderCommand.DrawIndexed(vertexArray);
        }
    }
}