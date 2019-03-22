precision highp float;

attribute vec3 aPosition;
attribute vec2 aColor0;
attribute vec2 aTexcoord0;

uniform vec2 texcoordClip;
uniform mat4 aMatrixM;
uniform mat4 aMatrixVP;

varying vec2 v_texcoord0;

void main()
{
    v_texcoord0 = (aTexcoord0 - 0.5)*texcoordClip + 0.5;
    gl_Position = aMatrixVP*aMatrixM*vec4(aPosition.xyz,1.0);

    gl_PointSize = 10.0;
}
