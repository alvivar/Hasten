// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Hasten/Amplify/LambertScanLines"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Hologramcolor("Hologram color", Color) = (0.2509804,0.5019608,1,0.2509804)
		_ScanLines("Scan Lines", Range( 0 , 16)) = 2
		_Speed("Speed", Range( 0 , 360)) = 32
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		struct Input
		{
			float3 worldPos;
		};

		uniform half _ScanLines;
		uniform half _Speed;
		uniform half4 _Hologramcolor;

		void surf( Input i , inout SurfaceOutput o )
		{
			float3 ase_worldPos = i.worldPos;
			float componentMask105 = ( 1.0 - ( _Speed * _Time ) ).x;
			half4 ScanLines = ( lerp( half4(1,1,1,0) , half4(0,0,0,0) , clamp( (0.0 + (sin( ( ( ( _ScanLines * ase_worldPos.y ) + componentMask105 ) * UNITY_PI ) ) - -1.0) * (1.0 - 0.0) / (1.0 - -1.0)) , 0.0 , 1.0 ) ) - float4( 0,0,0,0 ) );
			o.Emission = ( ScanLines + _Hologramcolor ).rgb;
			o.Alpha = _Hologramcolor.a;
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
				float4 tSpace0 : TEXCOORD1;
				float4 tSpace1 : TEXCOORD2;
				float4 tSpace2 : TEXCOORD3;
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
				float3 worldPos = IN.worldPos;
				fixed3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
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
0;45;1440;851;3109.035;1125.688;3.17662;True;True
Node;AmplifyShaderEditor.CommentaryNode;170;-1978.974,-127.8768;Float;False;2395.538;862.9734;;19;30;17;18;16;15;14;155;2;10;8;105;26;13;11;107;3;106;27;6;Scan Lines;0;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-1917.292,230.0818;Half;False;Property;_Speed;Speed;2;0;32;0;360;0;1;FLOAT
Node;AmplifyShaderEditor.TimeNode;26;-1920.121,528.2178;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-1642.819,459.8714;Float;False;2;0;FLOAT;0.0,0,0,0;False;1;FLOAT4;0.0;False;1;FLOAT4
Node;AmplifyShaderEditor.RangedFloatNode;10;-1627.17,56.97134;Half;False;Property;_ScanLines;Scan Lines;1;0;2;0;16;0;1;FLOAT
Node;AmplifyShaderEditor.WorldPosInputsNode;2;-1582.511,207.3353;Float;False;0;4;FLOAT3;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.OneMinusNode;8;-1484.56,420.759;Float;False;1;0;FLOAT4;0.0;False;1;FLOAT4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-1287.394,189.914;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;6.06;False;1;FLOAT
Node;AmplifyShaderEditor.ComponentMaskNode;105;-1313.027,372.7928;Float;False;True;False;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;3;-1101.522,259.3631;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.PiNode;107;-1094.444,452.625;Float;False;1;0;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-924.0153,271.3237;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SinOpNode;13;-751.7628,361.0725;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.TFHCRemap;14;-574.9104,443.5371;Float;False;5;0;FLOAT;0.0;False;1;FLOAT;-1.0;False;2;FLOAT;1.0;False;3;FLOAT;0.0;False;4;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.ClampOpNode;15;-362.3516,296.6347;Float;False;3;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;17;-472.9254,-63.0449;Half;False;Constant;_Color0;Color 0;2;0;1,1,1,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ColorNode;18;-598.6686,139.4746;Half;False;Constant;_Color1;Color 1;2;0;0,0,0,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.LerpOp;16;-191.0019,69.53559;Float;False;3;0;COLOR;0.0;False;1;COLOR;0.0,0,0,0;False;2;FLOAT;0.0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleSubtractOpNode;155;-7.789355,229.6329;Float;False;2;0;COLOR;0.0;False;1;COLOR;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.RegisterLocalVarNode;30;184.7672,-6.77223;Half;True;ScanLines;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.ColorNode;28;-435.8694,-424.7974;Half;False;Property;_Hologramcolor;Hologram color;0;0;0.2509804,0.5019608,1,0.2509804;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.GetLocalVarNode;33;-400.1689,-578.9149;Float;False;30;0;1;COLOR
Node;AmplifyShaderEditor.SimpleAddOpNode;71;-126.7423,-540.7806;Float;False;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;73.18466,-584.1224;Half;False;True;2;Half;ASEMaterialInspector;0;Lambert;Hasten/Amplify/LambertScanLines;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Transparent;0.5;True;True;0;False;Transparent;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;Relative;0;Standard;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;13;OBJECT;0.0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;27;0;6;0
WireConnection;27;1;26;0
WireConnection;8;0;27;0
WireConnection;106;0;10;0
WireConnection;106;1;2;2
WireConnection;105;0;8;0
WireConnection;3;0;106;0
WireConnection;3;1;105;0
WireConnection;11;0;3;0
WireConnection;11;1;107;0
WireConnection;13;0;11;0
WireConnection;14;0;13;0
WireConnection;15;0;14;0
WireConnection;16;0;17;0
WireConnection;16;1;18;0
WireConnection;16;2;15;0
WireConnection;155;0;16;0
WireConnection;30;0;155;0
WireConnection;71;0;33;0
WireConnection;71;1;28;0
WireConnection;0;2;71;0
WireConnection;0;9;28;4
ASEEND*/
//CHKSM=4C02D3D445F64C006C8835CC0B8C90F73DC2407F