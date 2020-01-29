using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Text;

using Game.Engine.Events;
using Game.Engine.EventSystem;
using Game.Engine.Input;
using Game.Engine.Tools;

namespace Game.Engine.Graphics
{

    
    public class Window
    {
        private static readonly GLFW.GLFWwindowsizefun onWindowRezise = new GLFW.GLFWwindowsizefun(OnWindowResize);
        private static readonly GLFW.GLFWwindowclosefun onWindowClosed = new GLFW.GLFWwindowclosefun(OnWindowClosed);
        private static readonly GLFW.GLFWKeyfun onkeyDown = new GLFW.GLFWKeyfun(OnKey);
        private static readonly GLFW.GLFWMousefun onMouseButton = new GLFW.GLFWMousefun(OnMouseButton);
        private static readonly GLFW.GLFWScrollfun onMouseScroll = new GLFW.GLFWScrollfun(OnMouseScroll);
        private static readonly GLFW.GLFWCursorfun onMouseMove = new GLFW.GLFWCursorfun(OnMouseMove);
      
        public int Width {get; private set; }
        public int Height { get; private set; }
        public string Title { get; private set; }
    
        public IntPtr WindowHandle;
        public IGraphicContext Context;

        public Window(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;
        }

        public void Init()
        {
            GLFW.Initialise();
            WindowHandle = GLFW.CreateWindow(Width, Height, Title, IntPtr.Zero, IntPtr.Zero);
            //GLFW.MakeContextCurrent(WindowHandle);
            Context = new OpenGLContext(ref WindowHandle);
            Context.Init();

            GLFW.SetWindowSizeCallback(WindowHandle, onWindowRezise);
            GLFW.SetWindowCloseCallback(WindowHandle, onWindowClosed);
            GLFW.SetKeyCallback(WindowHandle, onkeyDown);
            GLFW.SetMouseButtonCallback(WindowHandle, onMouseButton);
            GLFW.SetScrollCallback(WindowHandle, onMouseScroll);
            GLFW.SetCursorPosCallback(WindowHandle, onMouseMove);

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
            
            switch ((GLFW.KeyActions)action)
            {
                case GLFW.KeyActions.Press:
                {
                        Game.EventManager.QueueEvent(new MouseButtonPressedEvent(new MouseCode(button)));
                    break;
                }
                case GLFW.KeyActions.Release:
                {
                        Game.EventManager.QueueEvent(new MouseButtonReleasedEvent(new MouseCode(button)));
                    break;
                }
            }
        }

        private static void OnKey(IntPtr window, int key, int scancode, int action, int mods)
        {
           

            switch ((GLFW.KeyActions)action)
            {
                case GLFW.KeyActions.Press:
                {

                        Game.EventManager.QueueEvent(new KeyPressedEvent(new KeyCode(key), 0));
                    break;
                }
                case GLFW.KeyActions.Release:
                {
                        Game.EventManager.QueueEvent(new KeyReleasedEvent(new KeyCode(key)));
                    break;
                }
                case GLFW.KeyActions.Repeat:
                {
                        Game.EventManager.QueueEvent(new KeyPressedEvent(new KeyCode(key), 1));
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

        public void Update(TimeSpan gameTime)
        {
            Context.SwapBuffers();
            GLFW.PollEvents();
        }

        public void Shutdown(Event e)
        {
            GLFW.DestroyWindow(WindowHandle);
            GLFW.Terminate();
        }
    }
}
