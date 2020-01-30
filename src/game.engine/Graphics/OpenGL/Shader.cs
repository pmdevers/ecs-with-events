using System;
using System.Collections.Generic;
using System.Text;

using game.glfw;
using static game.OpenGL.GL;

namespace Game.Engine.Graphics.OpenGL
{
    public class Shader
    {
        private uint _rendererId;

        public Shader(string vertexSource, string fragmentSource)
        {
            //// Read our shaders into the appropriate buffers
            //string vertexSource = // Get source code for vertex shader.
            //string fragmentSource = // Get source code for fragment shader.

            // Create an empty vertex shader handle
            uint vertexShader = CreateShader(VERTEX_SHADER);

            // Send the vertex shader source code to GL
            // Note that std::string's .c_str is NULL character terminated.
            int lenght = 0;
            ShaderSource(vertexShader, 1, vertexSource, ref lenght);

            // Compile the vertex shader
            CompileShader(vertexShader);

            int param = 0;
            GetShaderiv(vertexShader, COMPILE_STATUS, ref param);
            if (param == 0)
            {
                GetShaderiv(vertexShader, COMPILE_STATUS, ref param);

                // The maxLength includes the NULL character
                var infoLog = new StringBuilder();
                GetShaderInfoLog(vertexShader, param, ref param, infoLog);

                // We don't need the shader anymore.
                DeleteShader(vertexShader);

                // Use the infoLog as you see fit.

                // In this simple program, we'll just leave
                return;
            }

            // Create an empty fragment shader handle
            uint fragmentShader = CreateShader(FRAGMENT_SHADER);

            // Send the fragment shader source code to GL
            // Note that std::string's .c_str is NULL character terminated.
            ShaderSource(fragmentShader, 1, fragmentSource, ref lenght);

            // Compile the fragment shader
            CompileShader(fragmentShader);

            GetShaderiv(fragmentShader, COMPILE_STATUS, ref param);
            if (param == 0)
            {
                GetShaderiv(fragmentShader, INFO_LOG_LENGTH, ref param);

                // The maxLength includes the NULL character
                var infoLog = new StringBuilder();
                GetShaderInfoLog(fragmentShader, param, ref param, infoLog);

                // We don't need the shader anymore.
                DeleteShader(fragmentShader);
                // Either of them. Don't leak shaders.
                DeleteShader(vertexShader);

                // Use the infoLog as you see fit.

                // In this simple program, we'll just leave
                return;
            }

            // Vertex and fragment shaders are successfully compiled.
            // Now time to link them together into a program.
            // Get a program object.
            uint program = CreateProgram();

            // Attach our shaders to our program
            AttachShader(program, vertexShader);
            AttachShader(program, fragmentShader);

            // Link our program
            LinkProgram(program);

            // Note the different functions here: glGetProgram* instead of glGetShader*.
            GetProgramiv(program, LINK_STATUS, ref param);
            if (param == 0)
            {
                GetProgramiv(program, INFO_LOG_LENGTH, ref param);

                var infoLog = new StringBuilder();
                // The maxLength includes the NULL character
                GetProgramInfoLog(program, param,ref param, infoLog);

                // We don't need the program anymore.
                DeleteProgram(program);
                // Don't leak shaders either.
                DeleteShader(vertexShader);
                DeleteShader(fragmentShader);

                // Use the infoLog as you see fit.

                // In this simple program, we'll just leave
                return;
            }

            // Always detach shaders after a successful link.
            DetachShader(program, vertexShader);
            DetachShader(program, fragmentShader);
        }

        public string VectorSrc { get; }
        public string FragmentSrc { get; }

        public void Bind()
        {

        }

        public void Unbind()
        {

        }
    }
}
