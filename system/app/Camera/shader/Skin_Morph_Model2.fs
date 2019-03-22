precision highp float;
varying vec2 v_texcoord0;
varying vec3 v_Normal0;
varying vec3 v_WorldPos0;

uniform sampler2D aTexture0;

uniform vec3 uLightDir;
uniform vec3 uLightColor;
uniform vec3 uMatDiffuse;

uniform vec3 uLightDir1;
uniform vec3 uLightColor1;
uniform vec3 uMatDiffuse1;

uniform vec3 uLightDir2;
uniform vec3 uLightColor2;
uniform vec3 uMatDiffuse2;

uniform vec3 uLightDir3;
uniform vec3 uLightColor3;
uniform vec3 uMatDiffuse3;

uniform vec3 uAmbientLightColor;
uniform vec3 uAmbientLightStrength;

void main()
{
	vec3 norm = normalize(v_Normal0);
    vec3 ambient = uAmbientLightColor * uAmbientLightStrength;

	vec3 lightDir   = normalize(uLightDir - v_WorldPos0);
	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * uLightColor;
	diffuse = diffuse * uMatDiffuse;

	vec3 lightDir1   = normalize(uLightDir1 - v_WorldPos0);
	float diff1 = max(dot(norm, lightDir1), 0.0);
	vec3 diffuse1 = diff1 * uLightColor1;
	diffuse1 = diffuse1 * uMatDiffuse1;

	vec3 lightDir2   = normalize(uLightDir2 - v_WorldPos0);
	float diff2 = max(dot(norm, lightDir2), 0.0);
	vec3 diffuse2 = diff2 * uLightColor2;
	diffuse2 = diffuse2 * uMatDiffuse2;

	vec3 lightDir3   = normalize(uLightDir3 - v_WorldPos0);
	float diff3 = max(dot(norm, lightDir3), 0.0);
	vec3 diffuse3 = diff3 * uLightColor3;
	diffuse3 = diffuse3 * uMatDiffuse3;

	vec4 objectColor = texture2D(aTexture0, v_texcoord0);
	vec3 result =  (diffuse + diffuse1 + diffuse2 + diffuse3 + ambient) * vec3(objectColor.rgb);
	gl_FragColor.rgba = vec4(result, 1.0);
}