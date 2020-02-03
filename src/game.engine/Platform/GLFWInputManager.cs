using Game.Engine.Graphics;
using static Game.Glfw.GLFW;

namespace Game.Engine.Input
{
    public class GLFWInputManager : InputManager
    {
        public readonly GLFWWindow _window;

        public GLFWInputManager()
        {
            _window = (GLFWWindow)Game.Instance.Window;
        }

        protected override bool IsKeyPressedImpl(int key)
        {
            return GetKey(_window.WindowHandle, key);
        }

        protected override bool IsMouseButtonPressedImpl(int mouseButton)
        {
            throw new System.NotImplementedException();
        }

        protected override float GetMosueXImpl()
        {
            throw new System.NotImplementedException();
        }

        protected override Vector2 GetMousePositionImpl()
        {
            throw new System.NotImplementedException();
        }

        protected override float GetMouseYImpl()
        {
            throw new System.NotImplementedException();
        }
    }
}