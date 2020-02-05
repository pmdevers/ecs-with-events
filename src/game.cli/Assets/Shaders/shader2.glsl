## VERTEX SHADER

#version 430 
 
layout(location = 0) in vec3 a_position; 
layout(location = 1) in vec4 a_color;

uniform mat4 u_ViewProjection;
uniform mat4 u_Transform; 

out vec3 v_position;
out vec4 v_color;

void main() { 
    v_position = a_position;
    v_color = a_color;
    gl_Position = u_ViewProjection * u_Transform * vec4(a_position, 1.0); 
}

## FRAGMENT SHADER

#version 430
 
layout(location = 0) out vec4 color;

in vec3 v_position;
in vec4 v_color;


void main() 
{ 
    color = v_color; 
}