using System;
using System.Collections.Generic;
using System.Text;

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

        public static void Submit(ShaderProgram shader, VertexArray vertexArray)
        {
            shader.Bind();
            shader.UploadUniformMatrix("v_ViewProjection", _viewProjectionMatrix);
            vertexArray.Bind();
            RenderCommand.DrawIndexed(vertexArray);
        }
    }
}