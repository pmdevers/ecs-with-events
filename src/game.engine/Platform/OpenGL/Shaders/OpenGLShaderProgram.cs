using Game.Engine.Renderer;
using System;
using System.Collections.Generic;
using System.Text;

using static Game.Glfw.GL;

namespace Game.Engine.Graphics.OpenGL.Shaders
{
    public class OpenGLShaderProgram : ShaderProgram
    {
        private readonly OpenGLShader _vertexShader;
        private readonly OpenGLShader _fragmentShader;

        public OpenGLShaderProgram(string vertexShaderSource, string fragmentShaderSource,
            Dictionary<uint, string> attributeLocations)
        {
            _vertexShader = new OpenGLShader(VERTEX_SHADER, vertexShaderSource);
            _fragmentShader = new OpenGLShader(FRAGMENT_SHADER, fragmentShaderSource);

            ShaderProgramObject = CreateProgram();

            AttachShader(ShaderProgramObject, _vertexShader.ShaderObject);
            AttachShader(ShaderProgramObject, _fragmentShader.ShaderObject);

            if (attributeLocations != null)
            {
                foreach (var vertexAttributeLocation in attributeLocations)
                {
                    // TODO: glBindAttributeLocation
                }
            }

            LinkProgram(ShaderProgramObject);

            if (!GetLinkStatus())
            {
                Console.WriteLine($"Failed to compile program with ID {ShaderProgramObject}.");
                Console.WriteLine(GetInfoLog());
            }

            Bind();
        }

        public override void Delete()
        {
            DetachShader(ShaderProgramObject, _vertexShader.ShaderObject);
            DetachShader(ShaderProgramObject, _fragmentShader.ShaderObject);
            _vertexShader.Delete();
            _fragmentShader.Delete();

            DeleteProgram(ShaderProgramObject);
            ShaderProgramObject = 0;
        }

        public override void Bind()
        {
            UseProgram(ShaderProgramObject);
        }

        public override void Unbind()
        {
            UseProgram(0);
        }

        public uint ShaderProgramObject { get; private set; }

        public bool GetLinkStatus()
        {
            var p = new[] { 0 };
            GetProgramiv(ShaderProgramObject, LINK_STATUS, p);
            return p[0] == 1;
        }

        public string GetInfoLog()
        {
            var infoLenght = new[] { 0 };
            GetProgramiv(ShaderProgramObject, INFO_LOG_LENGTH, infoLenght);

            int buffSize = infoLenght[0];

            var info = new StringBuilder(buffSize);
            GetProgramInfoLog(ShaderProgramObject, buffSize, IntPtr.Zero, info);

            return info.ToString();
        }

        public override void UploadUniformMatrix(string name, Matrix4 matrix)
        {
            var location = GetUniformLocation(ShaderProgramObject, name);
            UniformMatrix4Fv(location, 1, false, matrix.ToArray());
        }

        public override void UploadUniformFloat4(string name, Vector4 values)
        {
            var location = GetUniformLocation(ShaderProgramObject, name);
            Uniform4fv(location, 4, values.ToArray());
        }
    }
}