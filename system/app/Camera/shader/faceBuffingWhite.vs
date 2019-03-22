precision lowp float;

attribute vec2 aPosition;
attribute vec2 aColor0;
attribute vec2 aTexcoord0;

uniform vec2 texcoordClip;
uniform vec2 imageSize;

varying vec2 v_texcoord0;

varying vec2 blurCoordinates0;
varying vec2 blurCoordinates1;
varying vec2 blurCoordinates2;
varying vec2 blurCoordinates3;
varying vec2 blurCoordinates4;
varying vec2 blurCoordinates5;
varying vec2 blurCoordinates6;
varying vec2 blurCoordinates7;
varying vec2 blurCoordinates8;
varying vec2 blurCoordinates9;
varying vec2 blurCoordinates10;
varying vec2 blurCoordinates11;


void main()
{
    v_texcoord0 = (aTexcoord0 - 0.5)*texcoordClip + 0.5;
    gl_Position = vec4(aPosition.xy,0.0,1.0);

    vec2 singleStepOffset = 1.0 / imageSize;

    blurCoordinates0 = singleStepOffset * vec2( 5.0, 8.0);
    blurCoordinates1 = singleStepOffset * vec2( 5.0,-8.0);
    blurCoordinates2 = singleStepOffset * vec2(-5.0, 8.0);
    blurCoordinates3 = singleStepOffset * vec2(-5.0,-8.0);
    blurCoordinates4 = singleStepOffset * vec2( 8.0, 5.0);
    blurCoordinates5 = singleStepOffset * vec2( 8.0,-5.0);
    blurCoordinates6 = singleStepOffset * vec2(-8.0, 5.0);
    blurCoordinates7 = singleStepOffset * vec2(-8.0,-5.0);

    blurCoordinates8  = singleStepOffset * vec2( 10.0,  0.0);
    blurCoordinates9  = singleStepOffset * vec2(-10.0,  0.0);
    blurCoordinates10 = singleStepOffset * vec2(  0.0, 10.0);
    blurCoordinates11 = singleStepOffset * vec2(  0.0,-10.0);
}
