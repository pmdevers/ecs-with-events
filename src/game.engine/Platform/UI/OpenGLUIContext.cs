using System;
using System.Collections.Generic;
using System.Text;

using Game.Engine.Graphics;
using Game.Engine.Gui;

namespace Game.Engine.Platform.UI
{
    public class OpenGLUIContext : UIContext
    {
        private GLFWWindow _window;

        public OpenGLUIContext(Window window)
        {
            _window = (GLFWWindow)window;
        }
    }
}
