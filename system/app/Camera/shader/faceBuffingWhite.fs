//meiyan5
precision mediump float;

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
uniform highp vec4 params;

const float radio = 4.0;
const float weightOuter = 0.66;//0.72;
const float weightInner = 0.69;//0.74;
const vec3 vDefault0 = vec3(0.0);
const vec3 vDefault1 = vec3(1.0);
const vec4 v4Default0 = vec4(0.0);
const vec4 v4Default1 = vec4(1.0);
const vec3 vLambda = vec3(0.4);
const highp vec3 vY = vec3(0.2126, 0.7152, 0.0722);
const highp mat3 mSaturate = mat3( 1.1102, -0.0598, -0.061,
                                  -0.0774,  1.0826, -0.1186,
                                  -0.0228, -0.0228,  1.1772);
// #define RGB2HSL(rgb, hsl) {\
//     float minRGB = min(min(rgb.r, rgb.g), rgb.b);\
//     float maxRGB = max(max(rgb.r, rgb.g), rgb.b);\
//     float sum = maxRGB + minRGB;\
//     float chroma = maxRGB - minRGB;\
//     float luminance = 0.5 * sum;\
//     hsl = vec3(0.0, 0.0, luminance);\
//     if (chroma != 0.0){\
//         hsl.y = luminance == 1.0 ? 0.0 : chroma / (1.0 - abs(2.0 * luminance - 1.0));\
//         if (rgb.r == maxRGB) {\
//             hsl.x =  (rgb.g - rgb.b) / chroma / 6.0;\
//         } else if (rgb.g == maxRGB) {\
//             hsl.x = ((rgb.b - rgb.r) / chroma + 2.0) / 6.0;\
//         } else {\
//             hsl.x = ((rgb.r - rgb.g) / chroma + 4.0) / 6.0;\
//         }\
//         hsl.x = hsl.x < 0.0 ? hsl.x + 1.0 : hsl.x;\
//     }\
// }

// #define HSL2RGB(hsl, rgb) {\
//     if (hsl.y == 0.0) {\
//         rgb = vec3(hsl.z);\
//     } else {\
//         float hue = hsl.x;\
//         hue *= 6.0;\
//         float chroma = (1.0 - abs(2.0 * hsl.z - 1.0)) * hsl.y;\
//         float m = hsl.z - 0.5 * chroma;\
//         float x = (1.0 - abs(mod(hue, 2.0) - 1.0)) * chroma;\
//         if (hue < 1.0){\
//             rgb = vec3(chroma + m, x + m, m);\
//         } else if (hue < 2.0){\
//             rgb = vec3(x + m, chroma + m, m);\
//         } else if (hue < 3.0){\
//             rgb = vec3(m, chroma + m, x + m);\
//         } else if (hue < 4.0){\
//             rgb = vec3(m, x + m, chroma + m);\
//         } else if (hue < 5.0){\
//             rgb = vec3(x + m, m, chroma + m);\
//         } else {\
//             rgb = vec3(chroma + m, m, x + m);\
//         }\
//     }\
// }

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

    vec3 smoothColor = centralColor + (centralColor - vec3(highpass)) * (1.0 - highpass);
    smoothColor = clamp(smoothColor, vDefault0, vDefault1);
    smoothColor = mix(centralColor, smoothColor, params.r);  // soft
    smoothColor = mix(smoothColor, smoothColor * mSaturate, params.b);

    // vec3 hsl;
    // RGB2HSL(smoothColor, hsl);
    // hsl.y = pow(hsl.y, 0.9);
    // hsl.z = mix(hsl.z, pow(hsl.z, 0.5), params.g);           // white
    // HSLToRGB(hsl, smoothColor);
    smoothColor = mix(smoothColor, pow(smoothColor, vLambda), params.g); // white

    gl_FragColor = vec4(mix(centralColor, smoothColor, alpha), 1.0);
    //gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
}
