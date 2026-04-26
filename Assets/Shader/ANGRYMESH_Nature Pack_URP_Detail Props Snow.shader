Shader "ANGRYMESH/Nature Pack/URP/Detail Props Snow" {
	Properties {
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		[Header(Base)] _BaseSmoothness ("Base Smoothness", Range(0, 1)) = 0.5
		_BaseAOIntensity ("Base AO Intensity", Range(0, 1)) = 0.5
		_BumpScale ("Base Normal Intensity", Range(0, 2)) = 1
		_BaseColor ("Base Color", Vector) = (1,1,1,0)
		[NoScaleOffset] _BaseAlbedoASmoothness ("Base Albedo (A Smoothness)", 2D) = "gray" {}
		[NoScaleOffset] [Normal] _BaseNormalMap ("Base NormalMap", 2D) = "bump" {}
		[NoScaleOffset] _BaseAOANoiseMask ("Base AO (A NoiseMask)", 2D) = "white" {}
		[Header(Top)] [Toggle(_TOPENABLENOISE_ON)] _TopEnableNoise ("Top Enable Noise", Float) = 0
		_TopNoiseUVScale ("Top Noise UV Scale", Range(0.2, 10)) = 1
		_TopSmoothness ("Top Smoothness", Range(0, 1)) = 1
		_TopUVScale ("Top UV Scale", Range(1, 30)) = 10
		_TopIntensity ("Top Intensity", Range(0, 1)) = 0
		_TopOffset ("Top Offset", Range(0, 1)) = 0.5
		_TopContrast ("Top Contrast", Range(0, 2)) = 1
		_TopNormalIntensity ("Top Normal Intensity", Range(0, 2)) = 1
		_TopColor ("Top Color", Vector) = (1,1,1,0)
		[NoScaleOffset] _TopAlbedoASmoothness ("Top Albedo (A Smoothness)", 2D) = "gray" {}
		[NoScaleOffset] [Normal] _TopNormalMap ("Top NormalMap", 2D) = "bump" {}
		[Header(Detail)] _DetailUVScale ("Detail UV Scale", Range(0, 40)) = 10
		_DetailAlbedoIntensity ("Detail Albedo Intensity", Range(0, 1)) = 1
		_DetailNormalMapIntensity ("Detail NormalMap Intensity", Range(0, 2)) = 1
		[NoScaleOffset] _DetailAlbedo ("Detail Albedo", 2D) = "gray" {}
		[ASEEnd] [NoScaleOffset] [Normal] _DetailNormalMap ("Detail NormalMap", 2D) = "bump" {}
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
			};

			struct Vertex_Stage_Output
			{
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return float4(1.0, 1.0, 1.0, 1.0); // RGBA
			}

			ENDHLSL
		}
	}
	Fallback "Hidden/InternalErrorShader"
}