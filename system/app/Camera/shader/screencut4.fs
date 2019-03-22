precision mediump float;

uniform sampler2D aTexture0;

varying vec4 v_color;
varying vec2 v_texcoord0;

void main()
{
    vec2 t_newtexcoord = fract(v_texcoord0*2.0);
    vec4 color1 = texture2D(aTexture0,t_newtexcoord);
    gl_FragColor = v_color*color1;
}
