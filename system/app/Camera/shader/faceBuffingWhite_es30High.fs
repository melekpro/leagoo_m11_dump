#version 300 es
precision mediump float;

in vec3 v_faceColor;
in vec2 v_texcoord0;
in vec2 blurCoordinates0;
in vec2 blurCoordinates1;
in vec2 blurCoordinates2;
in vec2 blurCoordinates3;
in vec2 blurCoordinates4;
in vec2 blurCoordinates5;
in vec2 blurCoordinates6;
in vec2 blurCoordinates7;
in vec2 blurCoordinates8;
in vec2 blurCoordinates9;
in vec2 blurCoordinates10;
in vec2 blurCoordinates11;

uniform vec2 imageSize;
uniform sampler2D aTexture0;
uniform highp vec4 params;

layout(location = 0) out vec4 outColor;

const float radio = 6.0;
const float weightOuter = 0.66;//0.6065;
const float weightInner = 0.69;//0.6408;
const vec3 vDefault0 = vec3(0.0);
const vec3 vDefault1 = vec3(1.0);
const vec3 vLambda = vec3(0.7);
const vec3 vNormalize = vec3(0.5, 0.2, 0.3);
const highp mat3 mSaturate = mat3( 1.1102, -0.0598, -0.061,
                                  -0.0774,  1.0826, -0.1186,
                                  -0.0228, -0.0228,  1.1772);
void main(){    
    //  14 ms
    vec3 centralColor = texture(aTexture0, v_texcoord0).rgb;
    vec3 vSampleColor = centralColor;
    vec3 vWeight = vDefault1;
    vec3 vWeightTotal = vWeight;
    vec3 vSum = vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates0).rgb;
    vWeight = weightInner * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates1).rgb;
    vWeight = weightInner * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates2).rgb;
    vWeight = weightInner * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates3).rgb;
    vWeight = weightInner * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates4).rgb;
    vWeight = weightInner * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates5).rgb;
    vWeight = weightInner * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates6).rgb;
    vWeight = weightInner * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates7).rgb;
    vWeight = weightInner * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates8).rgb;
    vWeight = weightOuter * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates9).rgb;
    vWeight = weightOuter * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates10).rgb;
    vWeight = weightOuter * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vSampleColor = texture(aTexture0, v_texcoord0 + blurCoordinates11).rgb;
    vWeight = weightOuter * max(vDefault1 - abs(centralColor - vSampleColor) * radio, vDefault0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColor;

    vec3 deltaColor = centralColor - v_faceColor;
    deltaColor = deltaColor * deltaColor * vNormalize;
    float alpha = 1.0 - sqrt(deltaColor.r + deltaColor.g + deltaColor.b);

    vec3 smoothColor = vSum / vWeightTotal;
    smoothColor = mix(smoothColor, max(centralColor, smoothColor), alpha);
    smoothColor = mix(smoothColor, pow(smoothColor, vLambda), params.g); // white，如果 alpha * params.g 图像对比度过大
    smoothColor = mix(smoothColor, smoothColor * mSaturate, params.b);

    outColor = vec4(mix(centralColor, smoothColor, alpha * params.r), 1.0); // soft
    //outColor = vec4(1.0, 1.0, 0.0, 1.0);
}
