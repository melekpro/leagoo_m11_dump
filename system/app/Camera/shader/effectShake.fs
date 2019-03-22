#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_mouse;
uniform float u_time;
uniform vec2 texel;
varying lowp vec2 v_texcoord0;
uniform sampler2D aTexture0;

void main()
{
    
    float amount = 0.0;
    amount = sin(u_time*3.0);
    amount *= sin(u_time*12.0);
    amount *= sin(u_time*19.0);
    amount *= sin(u_time*33.0);
    amount = pow(amount, 2.0);
    amount = amount*200.0 + 6.0;
    
    
    vec2 uv = v_texcoord0;
    vec2 coords = (uv - 0.5) * 2.0;
    float coordDot = dot (coords, coords);
    
    vec2 precompute = amount * coordDot * coords;
    vec2 uvR = uv - texel.xy * precompute;
    vec2 uvB = uv + texel.xy * precompute;
    
    vec4 color;
    color.r = texture2D(aTexture0, uvR).r;
    color.g = texture2D(aTexture0, uv).g;
    color.b = texture2D(aTexture0, uvB).b;
    color *= (1.0 + amount*0.002);
    color.a=1.0;
    gl_FragColor = color;
}
