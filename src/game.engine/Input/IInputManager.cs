using Game.Engine.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Input
{
    public abstract class InputManager
    {
        public static InputManager Create(Window window)
        {
            return new GLFWInputManager(window);
        }

        public abstract bool IsKeyPressed(int key);
    }
}