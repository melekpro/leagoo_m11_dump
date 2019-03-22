#version 300 es
precision lowp float;

in vec2 v_texcoord0;
in vec4 v_color0;

uniform sampler2D aTexture0;
uniform vec2 imageSize;
uniform float softenStrength;

layout(location = 0) out vec4 outColor;

void main(){
    vec3 centralColor;
    centralColor = texture(aTexture0, v_texcoord0).rgb;
    if(abs(centralColor.r - v_color0.r) >= 0.5 )
    {
        outColor = vec4(centralColor , 1.0);
        return;
    }
    float mul_x = 1.6 / imageSize.x;
    float mul_y = 1.6 / imageSize.y;
    vec2 blurCoordinates0 = v_texcoord0 + vec2(0.0 * mul_x,-10.0 * mul_y);
    vec2 blurCoordinates1 = v_texcoord0 + vec2(5.0 * mul_x,-8.0 * mul_y);
    vec2 blurCoordinates2 = v_texcoord0 + vec2(8.0 * mul_x,-5.0 * mul_y);
    vec2 blurCoordinates3 = v_texcoord0 + vec2(10.0 * mul_x,0.0 * mul_y);
    vec2 blurCoordinates4 = v_texcoord0 + vec2(8.0 * mul_x,5.0 * mul_y);
    vec2 blurCoordinates5 = v_texcoord0 + vec2(5.0 * mul_x,8.0 * mul_y);
    vec2 blurCoordinates6 = v_texcoord0 + vec2(0.0 * mul_x,10.0 * mul_y);
    vec2 blurCoordinates7 = v_texcoord0 + vec2(-5.0 * mul_x,8.0 * mul_y);
    vec2 blurCoordinates8 = v_texcoord0 + vec2(-8.0 * mul_x,5.0 * mul_y);
    vec2 blurCoordinates9 = v_texcoord0 + vec2(-10.0 * mul_x,0.0 * mul_y);
    vec2 blurCoordinates10 = v_texcoord0 + vec2(-8.0 * mul_x,-5.0 * mul_y);
    vec2 blurCoordinates11 = v_texcoord0 + vec2(-5.0 * mul_x,-8.0 * mul_y);

    float central;
    float gaussianWeightTotal;
    float sum;
    float sample_g;
    float distanceFromCentralColor;
    float gaussianWeight;
    float distanceNormalizationFactor = 3.6;
    
    central = texture(aTexture0, v_texcoord0).g;
    gaussianWeightTotal = 0.2;
    sum = central * 0.2;
    
    sample_g = texture(aTexture0, blurCoordinates0).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates1).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates2).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates3).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates4).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates5).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates6).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates7).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates8).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates9).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates10).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;
    
    sample_g = texture(aTexture0, blurCoordinates11).g;
    distanceFromCentralColor = min(abs(central - sample_g) * distanceNormalizationFactor, 1.0);
    gaussianWeight = 0.08 * (1.0 - distanceFromCentralColor);
    gaussianWeightTotal += gaussianWeight;
    sum += sample_g * gaussianWeight;

    sum = sum/gaussianWeightTotal;
    sample_g = centralColor.g - sum + 0.5;
    for(int i = 0; i < 5; ++i)
    {
        if(sample_g <= 0.5)
        {
            sample_g = sample_g * sample_g * 2.0;
        }
        else
        {
            sample_g = 1.0 - ((1.0 - sample_g)*(1.0 - sample_g) * 2.0);
        }
    }
    float aa = 1.0 + pow(sum, 0.3)*0.07;
    vec3 smoothColor = centralColor*aa - vec3(sample_g)*(aa-1.0);// get smooth color
    smoothColor = clamp(smoothColor,vec3(0.0),vec3(1.0));//make smooth color right
    smoothColor = mix(centralColor, smoothColor, pow(centralColor.g, 0.33));
    smoothColor = mix(centralColor, smoothColor, pow(centralColor.g, 0.39));
    smoothColor = mix(centralColor, smoothColor, softenStrength);
    outColor = vec4(pow(smoothColor, vec3(0.96)),1.0);
    //outColor = vec4(1.0,0.0,0.0,1.0);
}
