using System;
using System.Text;

using static Game.Glfw.GL;

namespace Game.Engine.Graphics.OpenGL.Shaders
{
    public class OpenGLShader
    {
        private uint _shaderObject;
        public OpenGLShader(uint shaderType, string source)
        {
            _shaderObject = CreateShader(shaderType);

            ShaderSource(_shaderObject, 1, new[] { source }, new[] { source.Length });

            CompileShader(_shaderObject);

            if (!GetCompilerStatus())
            {
                Console.WriteLine($"Failed to compile shader with ID {_shaderObject}.");
                Console.WriteLine(GetInfoLog());
            }
        }

        public uint ShaderObject => _shaderObject;
        

        public void Delete()
        {
            DeleteShader(_shaderObject);
        }

        public bool GetCompilerStatus()
        {
            var p = new[] { 0 };
            GetShaderiv(_shaderObject, COMPILE_STATUS, p);
            return p[0] == 1;
        }

        public string GetInfoLog()
        {
            var infoLenght = new[] { 0 };
            GetShaderiv(_shaderObject, INFO_LOG_LENGTH, infoLenght);

            int buffSize = infoLenght[0];

            var info = new StringBuilder(buffSize);
            GetShaderInfoLog(_shaderObject, buffSize, IntPtr.Zero, info);

            return info.ToString();
        }
    }
}
