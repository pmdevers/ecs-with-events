
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public interface IRenderAPI
    {
        void SetClearColor(float red, float green, float blue, float alpha);
        void Clear();
        void DrawIndexed(VertexArray vertexArray);
    }
}
