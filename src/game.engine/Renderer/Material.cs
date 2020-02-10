using Game.Engine.Platform.OpenGL.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public class Material
    {
        public static Material Create(ShaderProgram shader)
        {
            switch (RendererAPI.Api)
            {
                case API.None:
                    throw new NotSupportedException();
                case API.OpenGL:
                    return new OpenGLMaterial(shader);

                default:
                    break;
            }

            throw new NotImplementedException(nameof(ShaderProgram));
        }
    }
}