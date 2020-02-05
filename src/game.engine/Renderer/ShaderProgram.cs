using Game.Engine.Graphics.OpenGL.Shaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game.Engine.Renderer
{
    public abstract class ShaderProgram
    {
        public static ShaderProgram Create(string filename)
        {
            var lines = File.ReadLines(filename);
            bool vShader = false;
            bool fShader = false;
            var vBuilder = new StringBuilder();
            var fBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                if (line == "## VERTEX SHADER")
                {
                    fShader = false;
                    vShader = true;
                    continue;
                }
                else if (line == "## FRAGMENT SHADER")
                {
                    fShader = true;
                    vShader = false;
                    continue;
                }

                if (vShader)
                {
                    vBuilder.AppendLine(line);
                }
                if (fShader)
                {
                    fBuilder.AppendLine(line);
                }
            }

            return Create(vBuilder.ToString(), fBuilder.ToString(), null);
        }

        public static ShaderProgram Create(string vertexShaderSource, string fragmentShaderSource,
            Dictionary<uint, string> attributeLocations)
        {
            switch (RendererAPI.Api)
            {
                case API.None:
                    throw new NotSupportedException();
                case API.OpenGL:
                    return new OpenGLShaderProgram(vertexShaderSource, fragmentShaderSource, attributeLocations);

                default:
                    break;
            }

            throw new NotImplementedException(nameof(ShaderProgram));
        }

        public abstract void UploadUniformMatrix(string name, Matrix4 matrix);

        public abstract void Delete();

        public abstract void Bind();

        public abstract void Unbind();
    }
}