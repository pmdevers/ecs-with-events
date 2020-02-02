using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Graphics
{
    public abstract class Window
    {
        public static Window Create(int width, int height, string title)
        {
            return new GLFWWindow(width, height, title);
        }

        public abstract void Init();

        public abstract void Update();
    }
}