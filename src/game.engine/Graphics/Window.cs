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
        private EventManager _eventManager;
        
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

        public IntPtr GetHandle(string procname)
        {
            return GLFW.GetProcAddress(procname);
        }

        public void Init(EventManager eventManager)
        {
            _eventManager = eventManager;
            GLFW.Initialise();
            WindowHandle = GLFW.CreateWindow(Width, Height, Title, IntPtr.Zero, IntPtr.Zero);
            GLFW.MakeContextCurrent(WindowHandle);
            Context = GraphicContext.Create(this);

            GLFW.SetWindowSizeCallback(WindowHandle, OnWindowResize);
            GLFW.SetWindowCloseCallback(WindowHandle, OnWindowClosed);
            GLFW.SetKeyCallback(WindowHandle, OnKey);
            GLFW.SetMouseButtonCallback(WindowHandle, OnMouseButton);
            GLFW.SetScrollCallback(WindowHandle, OnMouseScroll);
            GLFW.SetCursorPosCallback(WindowHandle, OnMouseMove);

            _eventManager.RegisterListener<CloseWindowEvent>(Shutdown);
        }

        private void OnMouseMove(IntPtr window, double xpos, double ypos)
        {
            _eventManager.QueueEvent(new MouseMovedEvent((float)xpos, (float)ypos));
        }

        private void OnMouseScroll(IntPtr window, double xoffset, double yoffset)
        {
            _eventManager.QueueEvent(new MouseScrolledEvent((float)xoffset, (float)yoffset));
        }

        private void OnMouseButton(IntPtr window, int button, int action, int mods)
        {
            switch ((GLFW.KeyActions)action)
            {
                case GLFW.KeyActions.Press:
                {
                   _eventManager.QueueEvent(new MouseButtonPressedEvent(new MouseCode(button)));
                    break;
                }
                case GLFW.KeyActions.Release:
                {
                    _eventManager.QueueEvent(new MouseButtonReleasedEvent(new MouseCode(button)));
                    break;
                }
            }
        }

        private void OnKey(IntPtr window, int key, int scancode, int action, int mods)
        {
            switch ((GLFW.KeyActions)action)
            {
                case GLFW.KeyActions.Press:
                {
                    _eventManager.QueueEvent(new KeyPressedEvent(new KeyCode(key), 0));
                    break;
                }
                case GLFW.KeyActions.Release:
                {
                    _eventManager.QueueEvent(new KeyReleasedEvent(new KeyCode(key)));
                    break;
                }
                case GLFW.KeyActions.Repeat:
                {
                    _eventManager.QueueEvent(new KeyPressedEvent(new KeyCode(key), 1));
                    break;
                }
            }
        }

        private void OnWindowClosed(IntPtr window)
        {
            _eventManager.QueueEvent(new CloseWindowEvent());
        }

        private void OnWindowResize(IntPtr window, int width, int height)
        {
            Width = width;
            Height = height;
            _eventManager.QueueEvent(new CloseWindowEvent());
        }

        public void Update(TimeSpan gameTime)
        {
            Context.SwapBuffers();
            GLFW.SwapBuffers(WindowHandle);
            GLFW.PollEvents();
        }

        public void Shutdown(Event e)
        {
            GLFW.DestroyWindow(WindowHandle);
            GLFW.Terminate();
        }
    }
}
