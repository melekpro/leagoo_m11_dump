#version 300 es
precision mediump float;

layout(location = 0) in vec2 aPosition;
layout(location = 4) in vec2 aColor0;
layout(location = 6) in vec2 aTexcoord0;

uniform sampler2D aTexture0;
uniform vec2 texcoordClip;
uniform vec2 imageSize;

uniform lowp vec2 location0;
uniform lowp vec2 location1;
uniform lowp vec2 location2;
uniform lowp vec2 location3;
uniform lowp vec2 location4;
uniform lowp vec2 location5;
uniform lowp vec2 location6;
uniform lowp vec2 location7;
uniform lowp vec2 location8;
uniform lowp vec2 location9;
uniform lowp vec2 location10;
uniform lowp vec2 location11;

out vec3 v_faceColor;
out vec2 v_texcoord0;
out vec2 blurCoordinates0;
out vec2 blurCoordinates1;
out vec2 blurCoordinates2;
out vec2 blurCoordinates3;
out vec2 blurCoordinates4;
out vec2 blurCoordinates5;
out vec2 blurCoordinates6;
out vec2 blurCoordinates7;


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
    
    vec4 sampleColor = texture(aTexture0, location0);
    sampleColor += texture(aTexture0, location1);
    sampleColor += texture(aTexture0, location2);
    sampleColor += texture(aTexture0, location3);
    sampleColor += texture(aTexture0, location4);
    sampleColor += texture(aTexture0, location5);
    sampleColor += texture(aTexture0, location6);
    sampleColor += texture(aTexture0, location7);
    sampleColor /= 8.0;

    v_faceColor = sampleColor.rgb;
}
