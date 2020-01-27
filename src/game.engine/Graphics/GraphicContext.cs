using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Game.Engine.Graphics
{
    public static class GraphicContext
    {
        public static IGraphicContext Create(Window window)
        {
            return  new OpenGLContext();
        }
    }
}
