
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
 
uniform vec4 u_Color;

uniform vec4 u_LightDirection;

void main() 
{ 
    color = u_Color; 
}