precision mediump float;

uniform sampler2D aTexture0;

varying vec4 v_color;
varying vec2 v_texcoord0;

uniform float u_expand;
uniform float u_maxsize;

void main()
{
    vec4 color1 = texture2D(aTexture0,v_texcoord0);
    float t_min = 0.5 - (0.5/u_expand);
    float t_max = 0.5 + (0.5/u_expand);
    vec2 t_newtexcoord = vec2(t_min,t_min) + v_texcoord0*(t_max-t_min);
    vec4 color2 = texture2D(aTexture0,t_newtexcoord);
    gl_FragColor = color1 + color2*(0.3 - u_expand/u_maxsize*0.3);
}
