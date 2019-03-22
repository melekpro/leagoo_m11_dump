#version 300 es
precision mediump float;

layout(location = 0) in vec2 aPosition;
layout(location = 4) in vec2 aColor0;
layout(location = 6) in vec2 aTexcoord0;

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

uniform sampler2D aTexture0;

uniform vec2 texcoordClip;

out vec2 v_texcoord0;
out vec4 v_color0;

void main()
{
    v_texcoord0 = (aTexcoord0 - 0.5)*texcoordClip + 0.5;
    gl_Position = vec4(aPosition.xy,0.0,1.0);

    vec4 colorAll;
    colorAll = texture(aTexture0, location0);
    colorAll = colorAll + texture(aTexture0, location1);
    colorAll = colorAll + texture(aTexture0, location2);
    colorAll = colorAll + texture(aTexture0, location3);
    colorAll = colorAll + texture(aTexture0, location4);
    colorAll = colorAll + texture(aTexture0, location5);
    colorAll = colorAll + texture(aTexture0, location6);
    colorAll = colorAll + texture(aTexture0, location7);
    colorAll = colorAll + texture(aTexture0, location8);
    colorAll = colorAll + texture(aTexture0, location9);
    colorAll = colorAll + texture(aTexture0, location10);
    colorAll = colorAll + texture(aTexture0, location11);

    v_color0 = colorAll / 12.0;
}
