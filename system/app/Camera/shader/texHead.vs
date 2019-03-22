precision mediump float;

attribute vec2 aPosition;
attribute vec2 aTexcoord0;
attribute vec4 aColor;
uniform vec2 texcoordClip;

varying vec2 v_texcoord0;
varying vec4 v_color;
void main()
{
    v_texcoord0 = (aTexcoord0 - 0.5)*texcoordClip  + 0.5;
    v_color = aColor/255.0;
    vec4 t_pos = vec4(aPosition.x,aPosition.y,0.0,1.0);
    gl_Position = t_pos;

}
