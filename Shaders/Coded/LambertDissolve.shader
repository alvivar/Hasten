
// Simple Lambert texture with color that dissolves into another texture.

// @matnesis
// 2016/12/10 08:43 PM


Shader "Hasten/Coded/Lambert Dissolve" {

	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_DissolveTex ("Dissolve Texture (RGB)", 2D) = "white" {}
		_DissolveAmmout ("Dissolve Amount", Range(0.0, 1.0)) = 0.5
	}

	SubShader {

		Tags {
			"RenderType"="Opaque"
			"Queue"="Transparent"
			"IgnoreProjector"="True"
		}

		Cull Off // Both sides
		LOD 200

		CGPROGRAM

		#pragma surface surf Lambert
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _DissolveTex;

		fixed4 _Color;
		float _DissolveAmmout;

		struct Input {
			float2 uv_MainTex;
			float2 uv_DissolveTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {

			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;

			// Kills pixels when < 0
			clip(tex2D (_DissolveTex, IN.uv_DissolveTex).rgb - _DissolveAmmout);
		}

		ENDCG
	}
	FallBack "Diffuse"
}
