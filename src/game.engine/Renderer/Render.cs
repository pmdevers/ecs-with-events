using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public static class Render
    {
        public static void BeginScene()
        {

        }

        public static void EndScene()
        {

        }

        public static void Submit(VertexArray vertexArray)
        {
            vertexArray.Bind();
            RenderCommand.DrawIndexed(vertexArray);
        }

    }
}
