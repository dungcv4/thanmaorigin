Shader "UI_Shader/Alpha/distort_add_for_dianji" {
	Properties {
		_Brightness ("Brightness", Float) = 1
		_Contrast ("Contrast", Float) = 1
		_MainColor ("Main Color", Vector) = (1,1,1,1)
		_MainTex ("Main Tex (A)", 2D) = "white" {}
		_MainAlpha ("Main Alpha", 2D) = "white" {}
		_MainPannerX ("Main Panner X", Float) = 0
		_MainPannerY ("Main Panner X", Float) = 0
		_TurbulenceTex ("Turbulence Tex", 2D) = "white" {}
		_MaskTex ("Mask Tex", 2D) = "white" {}
		_DistortPower ("Distort Power", Float) = 0
		_PowerX ("Power X", Range(0, 1)) = 0
		_PowerY ("Power Y", Range(0, 1)) = 0
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

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy);
			}

			ENDHLSL
		}
	}
}