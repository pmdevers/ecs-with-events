using Game.Engine.Renderer;
using Game.Glfw;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Graphics.OpenGL
{
    public class OpenGLRendererAPI : IRenderAPI
    {
        public void Clear()
        {
            GL.Clear(GL.COLOR_BUFFER_BIT);
        }

        public void DrawIndexed(VertexArray vertexArray)
        {
            GL.DrawElements(GL.TRIANGLES, vertexArray.GetIndexBuffer().GetCount(), GL.UNSIGNED_INT, IntPtr.Zero);

        }

        public void SetClearColor(float red, float green, float blue, float alpha)
        {
            GL.ClearColor(red, green, blue, alpha);
        }
    }

    public static class Extensions
    {
        public static uint ToOpenGL(this ShaderDataType dataType)
        {
            switch (dataType)
            {
                case ShaderDataType.Float: return GL.FLOAT;
                case ShaderDataType.Float2: return GL.FLOAT;
                case ShaderDataType.Float3: return GL.FLOAT;
                case ShaderDataType.Float4: return GL.FLOAT;
                case ShaderDataType.Mat3: return GL.FLOAT;
                case ShaderDataType.Mat4: return GL.FLOAT;
                case ShaderDataType.Int: return GL.UNSIGNED_INT;
                case ShaderDataType.Int2: return GL.UNSIGNED_INT;
                case ShaderDataType.Int3: return GL.UNSIGNED_INT;
                case ShaderDataType.Int4: return GL.UNSIGNED_INT;
                case ShaderDataType.Bool: return GL.UNSIGNED_INT;
            }
            return 0;
        }
    }
}
