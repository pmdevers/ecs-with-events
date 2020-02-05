
## VERTEX SHADER

#version 430 
layout(location = 0) in vec3 a_position; 

uniform mat4 u_ViewProjection; 
uniform mat4 u_Transform;

out vec3 v_position;
 
void main() { 
	v_position = a_position; 
	gl_Position = u_ViewProjection * u_Transform * vec4(a_position, 1.0); 
}

## FRAGMENT SHADER

#version 430
 
layout(location = 0) out vec4 color;

in vec4 v_color;

void main() 
{ 
    color = vec4(0.2, 0.3, 0.8, 1.0); 
}