using System;
using System.Collections.Generic;
using System.Text;

using static Game.Glfw.GL;

namespace Game.Engine.Graphics.OpenGL.Shaders
{
    public class ShaderProgram
    {
        private uint _shaderProgramObject;
        private readonly Shader _vertexShader;
        private readonly Shader _fragmentShader;
        public ShaderProgram(string vertexShaderSource, string fragmentShaderSource,
            Dictionary<uint, string> attributeLocations)
        {
            _vertexShader = new Shader(VERTEX_SHADER, vertexShaderSource);
            _fragmentShader = new Shader(FRAGMENT_SHADER, fragmentShaderSource);

            _shaderProgramObject = CreateProgram();

            AttachShader(_shaderProgramObject, _vertexShader.ShaderObject);
            AttachShader(_shaderProgramObject, _fragmentShader.ShaderObject);

            if (attributeLocations != null)
            {
                foreach (var vertexAttributeLocation in attributeLocations)
                {
                    // TODO: glBindAttributeLocation
                }
            }

            LinkProgram(_shaderProgramObject);

            if (!GetLinkStatus())
            {
                Console.WriteLine($"Failed to compile program with ID {_shaderProgramObject}.");
                Console.WriteLine(GetInfoLog());
            }
        }


        public void Delete()
        {
            DetachShader(_shaderProgramObject, _vertexShader.ShaderObject);
            DetachShader(_shaderProgramObject, _fragmentShader.ShaderObject);
            _vertexShader.Delete();
            _fragmentShader.Delete();

            DeleteProgram(_shaderProgramObject);
            _shaderProgramObject = 0;
        }

        public void Bind()
        {
            UseProgram(_shaderProgramObject);
        }

        public void Unbind()
        {
            UseProgram(0);
        }

        public uint ShaderProgramObject => _shaderProgramObject;
        
        public bool GetLinkStatus()
        {
            var p = new[] { 0 };
            GetShaderiv(_shaderProgramObject, LINK_STATUS, p);
            return p[0] == 1;
        }
        public string GetInfoLog()
        {
            var infoLenght = new[] { 0 };
            GetProgramiv(_shaderProgramObject, INFO_LOG_LENGTH, infoLenght);

            int buffSize = infoLenght[0];

            var info = new StringBuilder(buffSize);
            GetProgramInfoLog(_shaderProgramObject, buffSize, IntPtr.Zero, info);

            return info.ToString();
        }
    }
}
