precision highp float;

attribute vec3 aPosition;
attribute vec2 aTexcoord0;
attribute vec3 aNormal;
attribute vec4 aBoneID;
attribute vec4 aBoneWeight;



varying vec2 v_texcoord0;
varying vec3 v_Normal0;
varying vec3 v_WorldPos0;

const int MAX_BONES = 100;


uniform mat4 aMatrixM;
uniform mat4 aMatrixVP;
uniform mat4 gBones[MAX_BONES];

void main()
{

	vec3 blendPos = vec3(0.0);
	vec3 blendNorm = vec3(0.0);

    vec4 PosL    = vec4(aPosition, 1.0);

	//max four bone
	for (int bone = 0; bone < 4; ++bone)
	{
		mat4 BoneTransform = gBones[int(floor(aBoneID[bone]))];
		BoneTransform[3] = vec4(0.0);


	    float weight = aBoneWeight[bone];
		blendPos += (PosL * BoneTransform).xyz * weight;

        mat3 worldRotMatrix = mat3(BoneTransform[0].xyz, BoneTransform[1].xyz, BoneTransform[2].xyz);
        blendNorm += (aNormal * worldRotMatrix) * weight;
	}

	gl_Position  = aMatrixVP * vec4(blendPos,1.0);
	v_texcoord0 = aTexcoord0;
    v_WorldPos0 = blendPos;
    v_Normal0 = blendNorm;
}
