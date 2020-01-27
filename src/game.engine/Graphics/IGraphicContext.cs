using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Graphics
{
    public interface IGraphicContext
    {
        void Init();
        void SwapBuffers();
    }
}
