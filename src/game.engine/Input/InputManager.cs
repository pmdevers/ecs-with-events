using Game.Engine.Graphics;

namespace Game.Engine.Input
{
    public abstract class InputManager
    {
        private static readonly InputManager _Instance = Create();

        public static InputManager Create()
        {
            return new GLFWInputManager();
        }

        public static bool IsKeyPressed(KeyCode key)
        {
            return _Instance.IsKeyPressedImpl(key);
        }

        public static bool IsMouseButtonPressed(int mouseButton)
        {
            return _Instance.IsMouseButtonPressedImpl(mouseButton);
        }

        public static Vector2 GetMousePosition()
        {
            return _Instance.GetMousePositionImpl();
        }

        public static float GetMouseX()
        {
            return _Instance.GetMosueXImpl();
        }

        public static float GetMouseY()
        {
            return _Instance.GetMouseYImpl();
        }

        protected abstract bool IsKeyPressedImpl(KeyCode key);
        protected abstract bool IsMouseButtonPressedImpl(int mouseButton);
        protected abstract Vector2 GetMousePositionImpl();
        protected abstract float GetMosueXImpl();
        protected abstract float GetMouseYImpl();
    }
}