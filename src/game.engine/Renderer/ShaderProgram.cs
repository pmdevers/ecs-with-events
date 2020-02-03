using Game.Engine.Graphics.OpenGL.Shaders;
using System;
using System.Collections.Generic;

namespace Game.Engine.Renderer
{
    public abstract class ShaderProgram
    {
        public static ShaderProgram Create(string vertexShaderSource, string fragmentShaderSource,
            Dictionary<uint, string> attributeLocations)
        {
            switch (RendererAPI.Api)
            {
                case API.None:
                    throw new NotSupportedException();
                case API.OpenGL:
                    return new OpenGLShaderProgram(vertexShaderSource, fragmentShaderSource, attributeLocations);
            }

            throw new NotImplementedException(nameof(ShaderProgram));
        }

        public abstract void UploadUniformMatrix(string name, Matrix4 matrix);

        public abstract void Delete();

        public abstract void Bind();

        public abstract void Unbind();
    }
}