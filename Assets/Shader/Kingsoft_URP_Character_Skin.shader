Shader "Kingsoft/URP/Character/Skin" {
	Properties {
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[ASEBegin] _Albedo ("Albedo", 2D) = "white" {}
		_Curvature ("Curvature", 2D) = "white" {}
		_Normal ("Normal", 2D) = "bump" {}
		_NormalScale ("NormalScale", Range(0, 1)) = 1
		_SmoothMap ("SmoothMap（B:Thickness；A:Smoothness）", 2D) = "white" {}
		_Smoothness ("Smoothness", Range(0, 2)) = 1
		[ASEEnd] _Curve ("SSSWidth", Range(0, 1)) = 1
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		_SSSMap ("SSS Map", 2D) = "white" {}
		_TransmissionWidth ("TransmissionWidth", Range(0, 1)) = 0.27
		_TransmissionIndencity ("TransmissionIndencity", Range(0, 1)) = 0.14
		_TransColor ("TransmissionColor", Vector) = (1,0.466,0.457,1)
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