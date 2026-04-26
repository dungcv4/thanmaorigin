Shader "effect/Falloff" {
	Properties {
		_FalloffLevel ("FalloffLevel", Range(0, 5)) = 1
		_Color ("Color", Vector) = (1,0,0,1)
		_Brightness ("Brightness(0-10)", Range(0, 10)) = 1
		[MaterialToggle] _Invert ("Invert", Float) = 1
		[HideInInspector] _BlendSet ("__mode", Float) = 1
		[HideInInspector] _SrcRGBMode ("__src_rgb", Float) = 5
		[HideInInspector] _SrcAlphaMode ("__src_alpha", Float) = 5
		[HideInInspector] _DestRGBMode ("__dst_rgb", Float) = 1
		[HideInInspector] _DestAlphaMode ("__dst_alpha", Float) = 1
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