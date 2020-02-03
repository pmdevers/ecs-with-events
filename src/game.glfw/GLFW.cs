using System;
using System.Runtime.InteropServices;

namespace Game.Glfw
{
    public static class GLFW
    {
        private const string GLFW_DLL = "glfw3";

        public enum KeyActions
        {
            Release = 0,
            Press = 1,
            Repeat = 2,
        }

        // GLFW Bindings
        [DllImport(GLFW_DLL, EntryPoint = "glfwInit")] public static extern bool Initialise();

        [DllImport(GLFW_DLL, EntryPoint = "glfwCreateWindow")] public static extern IntPtr CreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share);

        [DllImport(GLFW_DLL, EntryPoint = "glfwMakeContextCurrent")] public static extern void MakeContextCurrent(IntPtr window);

        [DllImport(GLFW_DLL, EntryPoint = "glfwSwapBuffers")] public static extern void SwapBuffers(IntPtr window);

        [DllImport(GLFW_DLL, EntryPoint = "glfwGetProcAddress")] public static extern IntPtr GetProcAddress(string procname);

        [DllImport(GLFW_DLL, EntryPoint = "glfwPollEvents")] public static extern void PollEvents();

        [DllImport(GLFW_DLL, EntryPoint = "glfwWindowShouldClose")] public static extern int WindowShouldClose(IntPtr window);

        [DllImport(GLFW_DLL, EntryPoint = "glfwSetWindowUserPointer")] public static extern void SetWindowUserPointer(IntPtr window, IntPtr pointer);

        [DllImport(GLFW_DLL, EntryPoint = "glfwGetWindowUserPointer")] public static extern IntPtr GetWindowUserPointer(IntPtr window);

        [DllImport(GLFW_DLL, EntryPoint = "glfwDestroyWindow")] public static extern void DestroyWindow(IntPtr window);

        [DllImport(GLFW_DLL, EntryPoint = "glfwTerminate")] public static extern void Terminate();

        [DllImport(GLFW_DLL, EntryPoint = "glfwSetWindowSizeCallback")] public static extern void SetWindowSizeCallback(IntPtr window, GLFWwindowsizefun cbfun);

        [DllImport(GLFW_DLL, EntryPoint = "glfwSetWindowCloseCallback")] public static extern void SetWindowCloseCallback(IntPtr window, GLFWwindowclosefun cbfun);

        [DllImport(GLFW_DLL, EntryPoint = "glfwSetKeyCallback")] public static extern void SetKeyCallback(IntPtr window, GLFWKeyfun cbfun);

        [DllImport(GLFW_DLL, EntryPoint = "glfwSetMouseButtonCallback")] public static extern void SetMouseButtonCallback(IntPtr window, GLFWMousefun cbfun);

        [DllImport(GLFW_DLL, EntryPoint = "glfwSetScrollCallback")] public static extern void SetScrollCallback(IntPtr window, GLFWScrollfun cbfun);

        [DllImport(GLFW_DLL, EntryPoint = "glfwSetCursorPosCallback")] public static extern void SetCursorPosCallback(IntPtr window, GLFWCursorfun cbfun);

        [DllImport(GLFW_DLL, EntryPoint = "glfwGetKey")] public static extern bool GetKey(IntPtr window, int key);

        [DllImport(GLFW_DLL, EntryPoint = "glfwSwapInterval")] public static extern void SwapInterval(int enabled);

        public delegate void GLFWwindowsizefun(IntPtr window, int width, int height);

        public delegate void GLFWwindowclosefun(IntPtr window);

        public delegate void GLFWKeyfun(IntPtr window, int key, int scancode, int action, int mods);

        public delegate void GLFWMousefun(IntPtr window, int button, int action, int mods);

        public delegate void GLFWScrollfun(IntPtr window, double xOffset, double yOffset);

        public delegate void GLFWCursorfun(IntPtr window, double xPos, double yPos);
    }
}