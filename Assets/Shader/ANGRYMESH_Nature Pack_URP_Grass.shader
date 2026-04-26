Shader "ANGRYMESH/Nature Pack/URP/Grass" {
	Properties {
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		_Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.5
		[Header(Base)] _Glossiness ("Base Smoothness", Range(0, 1)) = 0.5
		_Color ("Base Color", Vector) = (1,1,1,1)
		_BaseBottomColor ("Base Bottom Color", Vector) = (1,1,1,0)
		_BaseBottomOffset ("Base Bottom Offset", Range(0, 5)) = 5
		[NoScaleOffset] _MainTex ("Albedo (A Opacity)", 2D) = "gray" {}
		[NoScaleOffset] [Normal] _BumpMap ("Normal Map", 2D) = "bump" {}
		[Header(Tint Color)] _TintColor1 ("Tint Color 1", Vector) = (1,1,1,0)
		_TintColor2 ("Tint Color 2", Vector) = (1,1,1,0)
		_TintNoiseTile ("Tint Noise Tile", Range(0.001, 30)) = 10
		[Header(Wind)] _WindAmplitude ("Wind Amplitude", Range(0, 3)) = 1
		_WindSpeed ("Wind Speed", Range(0, 10)) = 5
		_WindScale ("Wind Scale", Range(0, 30)) = 10
		_WindGrassStiffness ("Wind Grass Stiffness", Range(0, 2)) = 1
		[ASEEnd] [Header(Transmission)] _TransmissionStrenght ("Transmission Strenght", Range(0, 10)) = 2
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
		_TransmissionShadow ("Transmission Shadow", Range(0, 1)) = 0.5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;
			float4 _MainTex_ST;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct Vertex_Stage_Output
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.uv = (input.uv.xy * _MainTex_ST.xy) + _MainTex_ST.zw;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			Texture2D<float4> _MainTex;
			SamplerState sampler_MainTex;
			float4 _Color;

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy) * _Color;
			}

			ENDHLSL
		}
	}
	Fallback "Hidden/InternalErrorShader"
}