//meiyan5
precision lowp float;

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

uniform sampler2D aTexture0;

uniform vec2 imageSize;
uniform vec4 params;

const float radio = 4.0;
const float weightOuter = 0.66;//0.72;
const float weightInner = 0.69;//0.74;
const vec3 vDefault0 = vec3(0.0);
const vec3 vDefault1 = vec3(1.0);
const vec4 v4Default0 = vec4(0.0);
const vec4 v4Default1 = vec4(1.0);
const vec3 vLambda = vec3(0.4);
const vec3 vY = vec3(0.2126, 0.7152, 0.0722);
const mat3 mSaturate = mat3( 1.1102, -0.0598, -0.061,
                            -0.0774,  1.0826, -0.1186,
                            -0.0228, -0.0228,  1.1772);
void main(){
    // 14 ms
    vec3 centralColor = texture2D(aTexture0, v_texcoord0).rgb;
    vec4 vCentralColorG = vec4(centralColor.g);

    vec4 vSampleColorG = vec4(
                                texture2D(aTexture0, v_texcoord0 + blurCoordinates0).g,
                                texture2D(aTexture0, v_texcoord0 + blurCoordinates1).g,
                                texture2D(aTexture0, v_texcoord0 + blurCoordinates2).g,
                                texture2D(aTexture0, v_texcoord0 + blurCoordinates3).g
                             );
    vec4 vWeight = weightInner * max(v4Default1 - abs(vCentralColorG - vSampleColorG) * radio, v4Default0);
    vec4 vWeightTotal = vWeight;
    vec4 vSum = vWeight * vSampleColorG;

    vSampleColorG = vec4(
                             texture2D(aTexture0, v_texcoord0 + blurCoordinates4).g,
                             texture2D(aTexture0, v_texcoord0 + blurCoordinates5).g,
                             texture2D(aTexture0, v_texcoord0 + blurCoordinates6).g,
                             texture2D(aTexture0, v_texcoord0 + blurCoordinates7).g
                         );
    vWeight = weightInner * max(v4Default1 - abs(vCentralColorG - vSampleColorG) * radio, v4Default0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColorG;

    vSampleColorG = vec4(
                             texture2D(aTexture0, v_texcoord0 + blurCoordinates8 ).g,
                             texture2D(aTexture0, v_texcoord0 + blurCoordinates9 ).g,
                             texture2D(aTexture0, v_texcoord0 + blurCoordinates10).g,
                             texture2D(aTexture0, v_texcoord0 + blurCoordinates11).g
                         );
    vWeight = weightOuter * max(v4Default1 - abs(vCentralColorG - vSampleColorG) * radio, v4Default0);
    vWeightTotal += vWeight;
    vSum += vWeight * vSampleColorG;

    float alpha = dot(centralColor, vY);
    float grayG = (centralColor.g + vSum.r + vSum.g + vSum.b + vSum.a) / (1.0 + vWeightTotal.r + vWeightTotal.g + vWeightTotal.b + vWeightTotal.a);
    float highpass = centralColor.g - grayG + 0.5;
    highpass = 3.0 * highpass * highpass - 2.0 * highpass * highpass * highpass;
    highpass = 3.0 * highpass * highpass - 2.0 * highpass * highpass * highpass;
    highpass = 3.0 * highpass * highpass - 2.0 * highpass * highpass * highpass;

    vec3 smoothColor = centralColor + (centralColor - vec3(highpass)) * pow((1.0 - highpass), 1.2);
    smoothColor = clamp(smoothColor, vDefault0, vDefault1);
    smoothColor = mix(centralColor, smoothColor, params.r);              // soft
    smoothColor = mix(smoothColor, smoothColor * mSaturate, params.b);
    smoothColor = mix(smoothColor, pow(smoothColor, vLambda), params.g); // white

    gl_FragColor = vec4(mix(centralColor, smoothColor, alpha), 1.0);
    //gl_FragColor = vec4(1.0, 1.0, 0.0, 1.0);
}
