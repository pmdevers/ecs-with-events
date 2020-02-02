using Game.Engine.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static Game.Glfw.GLFW;

namespace Game.Engine.Input
{
    public class GLFWInputManager : InputManager
    {
        public readonly GLFWWindow _window;

        public GLFWInputManager(Window window)
        {
            _window = (GLFWWindow)window;
        }

        public override bool IsKeyPressed(int key)
        {
            return GetKey(_window.WindowHandle, key);
        }
    }
}