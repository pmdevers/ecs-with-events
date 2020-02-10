using Game.Engine.Renderer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Platform.OpenGL.Materials
{
    public class OpenGLMaterial : Material
    {
        private readonly ShaderProgram _shader;

        public OpenGLMaterial(ShaderProgram shader)
        {
            _shader = shader;
        }
    }
}