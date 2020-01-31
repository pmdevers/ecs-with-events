using Game.Engine.Graphics.OpenGL.Shaders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public abstract class ShaderProgram
    {
        public static ShaderProgram Create(string vertexShaderSource, string fragmentShaderSource,
            Dictionary<uint, string> attributeLocations)
        {
            switch (Renderer.GetAPI())
            {
                case RendererAPI.none:
                    break;
                case RendererAPI.OpenGL:
                    return new OpenGLShaderProgram(vertexShaderSource, fragmentShaderSource, attributeLocations);
                default:
                    break;
            }

            throw new NotImplementedException(nameof(ShaderProgram));
        }

        public abstract uint ShaderProgramObject { get; }
        public abstract void Delete();
        public abstract void Bind();
        public abstract void Unbind();
        public abstract bool GetLinkStatus();
        public abstract string GetInfoLog();
    }

    public abstract class Shader
    {
        public abstract uint ShaderObject { get; }
        public abstract void Delete();
        public abstract bool GetCompilerStatus();
        public abstract string GetInfoLog();

    }
}
