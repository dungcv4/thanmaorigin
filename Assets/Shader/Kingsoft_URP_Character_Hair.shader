Shader "Kingsoft/URP/Character/Hair" {
	Properties {
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[Enum(TwoSide,0,Back,1,Front,2)] _Rendermode ("Render mode", Float) = 2
		_BaseColor ("Base Color", Vector) = (0,0,0,0)
		_BaseMap ("Base Map", 2D) = "white" {}
		_NormalScale ("NormalScale", Range(0, 5)) = 1
		_NormalMap ("Normal Map", 2D) = "bump" {}
		_AniostropicMap ("Aniostropic Map", 2D) = "white" {}
		_Gloss1 ("Gloss1", Range(0, 20)) = 0
		_Gloss2 ("Gloss2", Range(0, 20)) = 0
		_specularColor1 ("specularColor1", Vector) = (0,0,0,0)
		_specularColor2 ("specularColor2", Vector) = (0,0,0,0)
		_Shift1 ("Shift1", Float) = 0
		_Shift2 ("Shift2", Float) = 0
		[HideInInspector] _texcoord ("", 2D) = "white" {}
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
	//CustomEditor "UnityEditor.ShaderGraph.PBRMasterGUI"
}