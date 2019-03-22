precision mediump float;

uniform sampler2D aTexture0;

varying vec4 v_color;
varying vec2 v_texcoord0;

void main()
{
    vec4 color1 = texture2D(aTexture0,v_texcoord0);
    vec4 color = vec4(1.0,1.0,1.0,1.0);
    float t_y = 7.0*v_texcoord0.y;
    if(t_y>=0.0 && t_y<1.0){
        color = vec4(1.0,0.0,0.0,1.0);
    }else if(t_y>=1.0 && t_y<2.0){
        color = vec4(1.0,0.647,0.0,1.0);
    }else if(t_y>=2.0 && t_y<3.0){
        color = vec4(1.0,1.0,0.0,1.0);
    }else if(t_y>=3.0 && t_y<4.0){
        color = vec4(0.0,1.0,0.0,1.0);
    }else if(t_y>=4.0 && t_y<5.0){
        color = vec4(0.0,0.498,1.0,1.0);
    }else if(t_y>=5.0 && t_y<6.0){
        color = vec4(1.0,0.0,1.0,1.0);
    }else if(t_y>=6.0 && t_y<=7.0){
        color = vec4(0.545,0.0,1.0,1.0);
    }
    gl_FragColor = color1*0.5+color*0.5;
}
