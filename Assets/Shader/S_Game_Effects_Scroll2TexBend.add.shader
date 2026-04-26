Shader "S_Game_Effects/Scroll2TexBend.add" {
	Properties {
		[WrapMode] _MainTex1_Wrap ("Tex1 Wrap Mode", Float) = 0
		_MainTex1 ("Tex1(RGB)", 2D) = "white" {}
		[WrapMode] _MainTex2_Wrap ("Tex2 Wrap Mode", Float) = 0
		_MainTex2 ("Tex2(RGB)", 2D) = "white" {}
		_ScrollX ("Tex1 speed X", Float) = 1
		_ScrollY ("Tex1 speed Y", Float) = 0
		_Scroll2X ("Tex2 speed X", Float) = 1
		_Scroll2Y ("Tex2 speed Y", Float) = 0
		_Color ("Color", Vector) = (1,1,1,1)
		_UVXX ("UVXX", Vector) = (0.3,1,1,1)
		_MMultiplier ("Layer Multiplier", Float) = 2
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

			float4 _Color;

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return _Color; // RGBA
			}

			ENDHLSL
		}
	}
}