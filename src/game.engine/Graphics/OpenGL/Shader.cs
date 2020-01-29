using System;
using System.Collections.Generic;
using System.Text;

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
            uint vertexShader = GL.CreateShader(GL.VERTEX_SHADER);

            // Send the vertex shader source code to GL
            // Note that std::string's .c_str is NULL character terminated.
            int lenght = 0;
            GL.ShaderSource(vertexShader, 1, vertexSource, ref lenght);

            // Compile the vertex shader
            GL.CompileShader(vertexShader);

            int isCompiled = 0;
            GL.GetShaderiv(vertexShader, GL.COMPILE_STATUS, ref isCompiled);
            if (isCompiled == 0)
            {
                int maxLength = 0;
                GL.GetShaderiv(vertexShader, GL.INFO_LOG_LENGTH, ref maxLength);

                // The maxLength includes the NULL character
                std::vector<GLchar> infoLog(maxLength);
                glGetShaderInfoLog(vertexShader, maxLength, &maxLength, &infoLog[0]);

                // We don't need the shader anymore.
                glDeleteShader(vertexShader);

                // Use the infoLog as you see fit.

                // In this simple program, we'll just leave
                return;
            }

            // Create an empty fragment shader handle
            GLuint fragmentShader = glCreateShader(GL_FRAGMENT_SHADER);

            // Send the fragment shader source code to GL
            // Note that std::string's .c_str is NULL character terminated.
            source = (const GLchar*)fragmentSource.c_str();
            glShaderSource(fragmentShader, 1, &source, 0);

            // Compile the fragment shader
            glCompileShader(fragmentShader);

            glGetShaderiv(fragmentShader, GL_COMPILE_STATUS, &isCompiled);
            if (isCompiled == GL_FALSE)
            {
                GLint maxLength = 0;
                glGetShaderiv(fragmentShader, GL_INFO_LOG_LENGTH, &maxLength);

                // The maxLength includes the NULL character
                std::vector<GLchar> infoLog(maxLength);
                glGetShaderInfoLog(fragmentShader, maxLength, &maxLength, &infoLog[0]);

                // We don't need the shader anymore.
                glDeleteShader(fragmentShader);
                // Either of them. Don't leak shaders.
                glDeleteShader(vertexShader);

                // Use the infoLog as you see fit.

                // In this simple program, we'll just leave
                return;
            }

            // Vertex and fragment shaders are successfully compiled.
            // Now time to link them together into a program.
            // Get a program object.
            GLuint program = glCreateProgram();

            // Attach our shaders to our program
            glAttachShader(program, vertexShader);
            glAttachShader(program, fragmentShader);

            // Link our program
            glLinkProgram(program);

            // Note the different functions here: glGetProgram* instead of glGetShader*.
            GLint isLinked = 0;
            glGetProgramiv(program, GL_LINK_STATUS, (int*)&isLinked);
            if (isLinked == GL_FALSE)
            {
                GLint maxLength = 0;
                glGetProgramiv(program, GL_INFO_LOG_LENGTH, &maxLength);

                // The maxLength includes the NULL character
                std::vector<GLchar> infoLog(maxLength);
                glGetProgramInfoLog(program, maxLength, &maxLength, &infoLog[0]);

                // We don't need the program anymore.
                glDeleteProgram(program);
                // Don't leak shaders either.
                glDeleteShader(vertexShader);
                glDeleteShader(fragmentShader);

                // Use the infoLog as you see fit.

                // In this simple program, we'll just leave
                return;
            }

            // Always detach shaders after a successful link.
            glDetachShader(program, vertexShader);
            glDetachShader(program, fragmentShader);
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
