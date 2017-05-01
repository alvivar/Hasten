
// The simple Lambert Alpha Color I could make.

// @matnesis
// 2016/12/10 08:43 PM


Shader "Hasten/Coded/Lambert Alpha Color" {

	Properties {
		_Color ("Color", Color) = (1,1,1,1)
	}

	SubShader {

		Tags {
			"RenderType"="Opaque" // The mix between Opaque & Transparent is what makes this shader works
			"Queue"="Transparent"
			"IgnoreProjector"="True"
		}

		LOD 200


		CGPROGRAM

		#pragma surface surf Lambert alpha:blend
		#pragma target 3.0 // Better lighting, theorically

		fixed4 _Color;

		struct Input {
			fixed _None;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color.rgb;
			o.Emission = _Color.rgb;
			o.Alpha = _Color.a;
		}

		ENDCG
	}

	FallBack "Diffuse"
}
