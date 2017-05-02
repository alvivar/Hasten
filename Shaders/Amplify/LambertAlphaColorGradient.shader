// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Hasten/Amplify/LambertAlphaColorGradient"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_FromColor("From Color", Color) = (0.09019608,0.6509804,0.5921569,1)
		_ToColor("To Color", Color) = (0.8509804,0.1960784,0.2509804,1)
		_BlendBalance("Blend Balance", Range( -1 , 1)) = 0
		_UMultiplier("U Multiplier", Range( 0 , 1)) = 0
		_VMultiplier("V Multiplier", Range( 0 , 1)) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		CGINCLUDE
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform half4 _FromColor;
		uniform half4 _ToColor;
		uniform fixed _UMultiplier;
		uniform fixed _VMultiplier;
		uniform fixed _BlendBalance;

		void surf( Input i , inout SurfaceOutput o )
		{
			float temp_output_35_0 = ( ( ( i.uv_texcoord.x * _UMultiplier ) + ( i.uv_texcoord.y * _VMultiplier ) ) + _BlendBalance );
			o.Albedo = lerp( _FromColor , _ToColor , temp_output_35_0 ).rgb;
			o.Alpha = lerp( _FromColor.a , _ToColor.a , temp_output_35_0 );
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Lambert alpha:fade keepalpha fullforwardshadows noshadow 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			# include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float3 worldPos : TEXCOORD6;
				float4 texcoords01 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.texcoords01 = float4( v.texcoord.xy, v.texcoord1.xy );
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			fixed4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.texcoords01.xy;
				float3 worldPos = IN.worldPos;
				fixed3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				SurfaceOutput o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutput, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Standard"
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=7102
0;45;1440;851;1636.027;524.0513;1.557953;True;True
Node;AmplifyShaderEditor.TexCoordVertexDataNode;29;-951.8698,102.4723;Float;False;0;0;2;5;FLOAT2;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;49;-1040.724,299.7925;Fixed;False;Property;_UMultiplier;U Multiplier;3;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;50;-966.8577,450.3497;Fixed;False;Property;_VMultiplier;V Multiplier;4;0;1;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;47;-661.3591,296.1732;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;46;-651.7788,127.1969;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;52;-457.2791,254.0472;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;22;-599.7885,425.9901;Fixed;False;Property;_BlendBalance;Blend Balance;2;0;0;-1;1;0;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;2;-468.3012,-23.0183;Half;False;Property;_ToColor;To Color;1;0;0.8509804,0.1960784,0.2509804,1;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;35;-280.6747,287.3449;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;1;-361.5721,-258.8174;Half;False;Property;_FromColor;From Color;0;0;0.09019608,0.6509804,0.5921569,1;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.LerpOp;23;-33.63323,147.7174;Float;False;3;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0,0,0;False;1;FLOAT
Node;AmplifyShaderEditor.LerpOp;3;-63.86932,-167.1981;Float;True;3;0;COLOR;0.0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;250.6696,-61.44276;Half;False;True;2;Half;ASEMaterialInspector;0;Lambert;Hasten/Amplify/LambertAlphaColorGradient;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Transparent;0.5;True;True;0;False;Transparent;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;Relative;0;Standard;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;13;OBJECT;0.0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;47;0;29;2
WireConnection;47;1;50;0
WireConnection;46;0;29;1
WireConnection;46;1;49;0
WireConnection;52;0;46;0
WireConnection;52;1;47;0
WireConnection;35;0;52;0
WireConnection;35;1;22;0
WireConnection;23;0;1;4
WireConnection;23;1;2;4
WireConnection;23;2;35;0
WireConnection;3;0;1;0
WireConnection;3;1;2;0
WireConnection;3;2;35;0
WireConnection;0;0;3;0
WireConnection;0;9;23;0
ASEEND*/
//CHKSM=4187F1CBEFAB2C8E65E13EF113E89904A26708DA