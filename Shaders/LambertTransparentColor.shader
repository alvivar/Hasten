Shader "Hasten/Lambert/Transparent Color" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader {
		Tags {
			"RenderType"="Opaque"
			"Queue"="Overlay"
			"IgnoreProjector"="True"
		}
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert alpha:blend


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
