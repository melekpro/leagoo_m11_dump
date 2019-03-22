precision mediump float;

varying vec2 v_texcoord0;
uniform sampler2D aTexture0;
uniform sampler2D aTexture1;
uniform sampler2D aTexture2;
void main()
{
    vec4 bgcolor = texture2D(aTexture0,v_texcoord0);
    vec2 t_texcoord = vec2(v_texcoord0.x,1.0-v_texcoord0.y);
    vec4 maskcolor = texture2D(aTexture1,t_texcoord);
    vec4 templatecolor = texture2D(aTexture2,t_texcoord);

    vec4 color1 = vec4(bgcolor.rgb*(1.0-maskcolor.rgb),bgcolor.a*(1.0-maskcolor.r));
    vec4 color2 = vec4(templatecolor.rgb*(maskcolor.rgb),templatecolor.a*(maskcolor.r));
    gl_FragColor = color1;
}
