Shader "effect/C_EffectStandard" {
	Properties {
		[Enum(TwoSide,0,Off,2)] _TwoSide ("2-Side", Float) = 2
		[KeywordEnum(OFF, ON)] _FogMode ("FogMode", Float) = 1
		[HideInInspector] _ZWrite ("__zw", Float) = 1
		_AlphaCutout ("_AlphaCutout", Range(0, 1)) = 0
		_Diffuse ("第一层贴图", 2D) = "white" {}
		[Toggle] _DiffuseRo ("旋转", Float) = 0
		_DiffuseAng ("旋转角度", Float) = 0
		[HDR] _Color ("颜色", Vector) = (1,1,1,1)
		_Brightness ("亮度(0-10)", Range(0, 10)) = 1
		_Uspeed ("Uspeed", Float) = 0
		_Vspeed ("Vspeed", Float) = 0
		[Foldout] _DiffuseMaskShown ("", Float) = 1
		[Toggle] _DiffuseMask ("第一层遮罩", Float) = 0
		_DiffuseMaskTex ("遮罩贴图", 2D) = "white" {}
		_MaskMaskTex ("遮罩的遮罩", 2D) = "white" {}
		[Toggle] _DiffuseMaskRo ("旋转", Float) = 0
		_DiffuseMaskAng ("旋转角度", Float) = 0
		_USpeed_diffusem ("USpeed", Float) = 0
		_VSpeed_diffusem ("VSpeed", Float) = 0
		[Foldout] _SecondLayerShown ("", Float) = 1
		[Toggle] _SecondLayerBlock ("第二层", Float) = 0
		_SecondLayerTex ("第二层贴图", 2D) = "white" {}
		_SecondLayerColor ("颜色", Vector) = (1,1,1,1)
		_SecondLayerBrightness ("亮度(0-10)", Range(0, 10)) = 1
		[Toggle] _SecondLayerRo ("旋转", Float) = 0
		_SecondLayerAng ("旋转角度", Float) = 0
		_Uspeed_second ("Uspeed", Float) = 0
		_Vspeed_second ("Vspeed", Float) = 0
		[Foldout] _SecondLayerMaskShown ("", Float) = 1
		[Toggle] _SecondLayerMask ("第二层遮罩", Float) = 0
		_SecondLayerMaskTex ("遮罩贴图", 2D) = "white" {}
		[Toggle] _SecondLayerMaskRo ("旋转", Float) = 0
		_SecondLayerMaskAng ("旋转角度", Float) = 0
		_Uspeed_secondm ("USpeed", Float) = 0
		_Vspeed_secondm ("VSpeed", Float) = 0
		[Foldout] _DissolveShown ("", Float) = 1
		[Toggle] _DissolveBlock ("溶解", Float) = 0
		_DissolveTex ("溶解贴图", 2D) = "white" {}
		_DissolveProgress ("DissolveProgress", Float) = 1
		_EdgeWidth ("Edge Width", Float) = 0
		[HDR] _EdgeColor ("Edge Col", Vector) = (1,1,1,1)
		_DissolveUSpeed ("USpeed_Dissolve", Float) = 0
		_DissolveVSpeed ("VSpeed_Dissolve", Float) = 0
		[Foldout] _DistortShown ("", Float) = 1
		[Toggle] _DistortBlock ("扭曲", Float) = 0
		_DistortTex ("扭曲贴图", 2D) = "white" {}
		_ForceX ("强度 X(0 1)", Float) = 0.1
		_ForceY ("强度 Y(0 1)", Float) = 0.1
		_USpeed_distort ("USpeed", Float) = 0
		_VSpeed_distort ("VSpeed", Float) = 0
		[Foldout] _DistortMaskShown ("", Float) = 1
		[Toggle] _DistortMask ("扭曲遮罩", Float) = 0
		_DistortMaskTex ("遮罩贴图", 2D) = "white" {}
		[Enum(Off,0,equal,4)] _StencilComp ("Stencil模式", Float) = 0
		_StencilID ("Stencil ID", Float) = 0
		[HideInInspector] _BlendSet ("__mode", Float) = 1
		[HideInInspector] _SrcRGBMode ("__src_rgb", Float) = 5
		[HideInInspector] _SrcAlphaMode ("__src_alpha", Float) = 5
		[HideInInspector] _DestRGBMode ("__dst_rgb", Float) = 10
		[HideInInspector] _DestAlphaMode ("__dst_alpha", Float) = 10
		[HideInInspector] _cpfv ("cpfv", Float) = 0
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
	//CustomEditor "CustomEffectMatGUI"
}