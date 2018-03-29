@OpenGL4.Vertex
#version 400

// Input vertex data, different for all executions of this shader.
in vec3 vertexPosition;
in vec2 vertexUV;

// Output data ; will be interpolated for each fragment.
out vec2 UV;

// Values that stay constant for the whole mesh.
uniform mat4 MVP;

void main(){

    // Output position of the vertex, in clip space : MVP * position
    gl_Position =  MVP * vec4(vertexPosition,1);

    // UV of the vertex. No special space for this one.
    UV = vertexUV;
}

@OpenGL4.Fragment
#version 400

// Interpolated values from the vertex shaders
in vec2 UV;

// Ouput data
out vec3 color;

// Values that stay constant for the whole mesh.
uniform sampler2D textureSampler;

void main()
{
// Output color = color of the texture at the specified UV
color = texture(textureSampler, UV).rgb;
}
