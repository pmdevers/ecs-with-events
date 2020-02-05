using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Input;
using System;
using static Game.Glfw.GLFW;

namespace Game.Engine.Graphics
{
    public class GLFWWindow : Window
    {
        private static readonly GLFWwindowsizefun onWindowRezise = OnWindowResize;
        private static readonly GLFWwindowclosefun onWindowClosed = OnWindowClosed;
        private static readonly GLFWKeyfun onkeyDown = OnKey;
        private static readonly GLFWMousefun onMouseButton = OnMouseButton;
        private static readonly GLFWScrollfun onMouseScroll = OnMouseScroll;
        private static readonly GLFWCursorfun onMouseMove = OnMouseMove;

        public IGraphicContext Context;

        public IntPtr WindowHandle;

        public GLFWWindow(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;
        }

        public int Width { get; }
        public int Height { get; }
        public string Title { get; }

        public override void Init()
        {
            Initialise();
            WindowHandle = CreateWindow(Width, Height, Title, IntPtr.Zero, IntPtr.Zero);
            Context = new OpenGLContext(ref WindowHandle);
            Context.Init();

            SetWindowSizeCallback(WindowHandle, onWindowRezise);
            SetWindowCloseCallback(WindowHandle, onWindowClosed);
            SetKeyCallback(WindowHandle, onkeyDown);
            SetMouseButtonCallback(WindowHandle, onMouseButton);
            SetScrollCallback(WindowHandle, onMouseScroll);
            SetCursorPosCallback(WindowHandle, onMouseMove);

            Game.EventManager.RegisterListener<CloseWindowEvent>(Shutdown);
        }

        private static void OnMouseMove(IntPtr window, double xpos, double ypos)
        {
            Game.EventManager.QueueEvent(new MouseMovedEvent((float)xpos, (float)ypos));
        }

        private static void OnMouseScroll(IntPtr window, double xoffset, double yoffset)
        {
            Game.EventManager.QueueEvent(new MouseScrolledEvent((float)xoffset, (float)yoffset));
        }

        private static void OnMouseButton(IntPtr window, int button, int action, int mods)
        {
            switch ((KeyActions)action)
            {
                case KeyActions.Press:
                    {
                        Game.EventManager.QueueEvent(new MouseButtonPressedEvent((MouseCode)button));
                        break;
                    }

                case KeyActions.Release:
                    {
                        Game.EventManager.QueueEvent(new MouseButtonReleasedEvent((MouseCode)button));
                        break;
                    }
            }
        }

        private static void OnKey(IntPtr window, int key, int scancode, int action, int mods)
        {
            switch ((KeyActions)action)
            {
                case KeyActions.Press:
                    {
                        Game.EventManager.QueueEvent(new KeyPressedEvent((KeyCode)key, 0));
                        break;
                    }

                case KeyActions.Release:
                    {
                        Game.EventManager.QueueEvent(new KeyReleasedEvent((KeyCode)key));
                        break;
                    }

                case KeyActions.Repeat:
                    {
                        Game.EventManager.QueueEvent(new KeyPressedEvent((KeyCode)key, 1));
                        break;
                    }
            }
        }

        private static void OnWindowClosed(IntPtr window)
        {
            Game.EventManager.QueueEvent(new CloseWindowEvent());
        }

        public static void OnWindowResize(IntPtr window, int width, int height)
        {
            Game.EventManager.QueueEvent(new CloseWindowEvent());
        }

        public override void Update()
        {
            Context.SwapBuffers();
            PollEvents();
        }

        public void Shutdown(Event e)
        {
            DestroyWindow(WindowHandle);
            Terminate();
        }

        public override void EnableVsync(bool enabled)
        {
            SwapInterval(enabled ? 1 : 0);
        }
    }
}