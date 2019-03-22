//meiyan1

precision highp float;
uniform sampler2D aTexture0;
varying highp vec2 v_texcoord0;



void main(){

vec3 centralColor;
float sampleColor;


vec2 blurCoordinates[20];

float mul = 2.0;

float mul_x = mul / 720.0;
float mul_y = mul / 1280.0;


blurCoordinates[0] = v_texcoord0 + vec2(0.0 * mul_x,-10.0 * mul_y);
blurCoordinates[1] = v_texcoord0 + vec2(5.0 * mul_x,-8.0 * mul_y);
blurCoordinates[2] = v_texcoord0 + vec2(8.0 * mul_x,-5.0 * mul_y);
blurCoordinates[3] = v_texcoord0 + vec2(10.0 * mul_x,0.0 * mul_y);
blurCoordinates[4] = v_texcoord0 + vec2(8.0 * mul_x,5.0 * mul_y);
blurCoordinates[5] = v_texcoord0 + vec2(5.0 * mul_x,8.0 * mul_y);
blurCoordinates[6] = v_texcoord0 + vec2(0.0 * mul_x,10.0 * mul_y);
blurCoordinates[7] = v_texcoord0 + vec2(-5.0 * mul_x,8.0 * mul_y);
blurCoordinates[8] = v_texcoord0 + vec2(-8.0 * mul_x,5.0 * mul_y);
blurCoordinates[9] = v_texcoord0 + vec2(-10.0 * mul_x,0.0 * mul_y);
blurCoordinates[10] = v_texcoord0 + vec2(-8.0 * mul_x,-5.0 * mul_y);
blurCoordinates[11] = v_texcoord0 + vec2(-5.0 * mul_x,-8.0 * mul_y);
blurCoordinates[12] = v_texcoord0 + vec2(0.0 * mul_x,-6.0 * mul_y);
blurCoordinates[13] = v_texcoord0 + vec2(-4.0 * mul_x,-4.0 * mul_y);
blurCoordinates[14] = v_texcoord0 + vec2(-6.0 * mul_x,0.0 * mul_y);
blurCoordinates[15] = v_texcoord0 + vec2(-4.0 * mul_x,4.0 * mul_y);
blurCoordinates[16] = v_texcoord0 + vec2(0.0 * mul_x,6.0 * mul_y);
blurCoordinates[17] = v_texcoord0 + vec2(4.0 * mul_x,4.0 * mul_y);
blurCoordinates[18] = v_texcoord0 + vec2(6.0 * mul_x,0.0 * mul_y);
blurCoordinates[19] = v_texcoord0 + vec2(4.0 * mul_x,-4.0 * mul_y);


sampleColor = texture2D(aTexture0, v_texcoord0).g * 22.0;

sampleColor += texture2D(aTexture0, blurCoordinates[0]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[1]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[2]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[3]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[4]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[5]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[6]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[7]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[8]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[9]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[10]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[11]).g;
sampleColor += texture2D(aTexture0, blurCoordinates[12]).g * 2.0;
sampleColor += texture2D(aTexture0, blurCoordinates[13]).g * 2.0;
sampleColor += texture2D(aTexture0, blurCoordinates[14]).g * 2.0;
sampleColor += texture2D(aTexture0, blurCoordinates[15]).g * 2.0;
sampleColor += texture2D(aTexture0, blurCoordinates[16]).g * 2.0;
sampleColor += texture2D(aTexture0, blurCoordinates[17]).g * 2.0;
sampleColor += texture2D(aTexture0, blurCoordinates[18]).g * 2.0;
sampleColor += texture2D(aTexture0, blurCoordinates[19]).g * 2.0;



sampleColor = sampleColor/50.0;


centralColor = texture2D(aTexture0, v_texcoord0).rgb;

float dis = centralColor.g - sampleColor + 0.5;


if(dis <= 0.5)
{
dis = dis * dis * 2.0;
}
else
{
dis = 1.0 - ((1.0 - dis)*(1.0 - dis) * 2.0);
}

if(dis <= 0.5)
{
dis = dis * dis * 2.0;
}
else
{
dis = 1.0 - ((1.0 - dis)*(1.0 - dis) * 2.0);
}

if(dis <= 0.5)
{
dis = dis * dis * 2.0;
}
else
{
dis = 1.0 - ((1.0 - dis)*(1.0 - dis) * 2.0);
}

if(dis <= 0.5)
{
dis = dis * dis * 2.0;
}
else
{
dis = 1.0 - ((1.0 - dis)*(1.0 - dis) * 2.0);
}

if(dis <= 0.5)
{
dis = dis * dis * 2.0;
}
else
{
dis = 1.0 - ((1.0 - dis)*(1.0 - dis) * 2.0);
}


float aa= 1.03;
vec3 smoothColor = centralColor*aa - vec3(dis)*(aa-1.0);

float hue = dot(smoothColor, vec3(0.299,0.587,0.114));

aa = 1.0 + pow(hue, 1.0)*0.1;
smoothColor = centralColor*aa - vec3(dis)*(aa-1.0);

smoothColor.r = clamp(pow(smoothColor.r, 1.0),0.0,1.0);
smoothColor.g = clamp(pow(smoothColor.g, 1.0),0.0,1.0);
smoothColor.b = clamp(pow(smoothColor.b, 1.0),0.0,1.0);


vec3 lvse = vec3(1.0)-(vec3(1.0)-smoothColor)*(vec3(1.0)-centralColor);
vec3 bianliang = max(smoothColor, centralColor);
vec3 rouguang = 2.0*centralColor*smoothColor + centralColor*centralColor - 2.0*centralColor*centralColor*smoothColor;


gl_FragColor = vec4(mix(centralColor, lvse, pow(hue, 1.0)), 1.0);
gl_FragColor.rgb = mix(gl_FragColor.rgb, bianliang, pow(hue, 1.0));
gl_FragColor.rgb = mix(gl_FragColor.rgb, rouguang, 0.15);



mat3 saturateMatrix = mat3(
1.1102,
-0.0598,
-0.061,
-0.0774,
1.0826,
-0.1186,
-0.0228,
-0.0228,
1.1772);

vec3 satcolor = gl_FragColor.rgb * saturateMatrix;
gl_FragColor.rgb = mix(gl_FragColor.rgb, satcolor, 0.15);


}