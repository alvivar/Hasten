// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Hasten/Amplify/LambertDepthFog"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Color("Color", Color) = (0.4313726,0.4705882,0.5490196,0.2509804)
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityCG.cginc"
		#pragma target 3.0
		#pragma surface surf Lambert alpha:fade keepalpha noambient novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float4 screenPos;
		};

		uniform half4 _Color;
		uniform sampler2D _CameraDepthTexture;

		void surf( Input i , inout SurfaceOutput o )
		{
			o.Emission = _Color.rgb;
			float eyeDepth2 = LinearEyeDepth(UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture,UNITY_PROJ_COORD(i.screenPos))));
			o.Alpha = ( (0.001 + (_Color.a - 0.0) * (0.499 - 0.001) / (1.0 - 0.0)) * ( eyeDepth2 - i.screenPos.z ) );
		}

		ENDCG
	}
	Fallback "Standard"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=7102
0;45;1440;851;915;284.75;1;True;True
Node;AmplifyShaderEditor.ScreenPosInputsNode;1;-568,116.5;Float;False;1;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ColorNode;7;-443,-149.5;Half;False;Property;_Color;Color;0;0;0.4313726,0.4705882,0.5490196,0.2509804;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ScreenDepthNode;2;-378,82.5;Float;False;0;1;0;FLOAT4;0,0,0,0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleSubtractOpNode;3;-177,202.5;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.TFHCRemap;6;-180,0.5;Float;False;5;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;1.0;False;3;FLOAT;0.001;False;4;FLOAT;0.499;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;32,88.5;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;202,-39;Half;False;True;2;Half;ASEMaterialInspector;0;Lambert;Hasten/Amplify/LambertDepthFog;False;False;False;False;True;True;True;True;True;True;True;True;Back;0;0;False;0;0;Transparent;0.5;True;False;0;False;Transparent;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;False;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;Relative;0;Standard;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;13;OBJECT;0.0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;2;0;1;0
WireConnection;3;0;2;0
WireConnection;3;1;1;3
WireConnection;6;0;7;4
WireConnection;4;0;6;0
WireConnection;4;1;3;0
WireConnection;0;2;7;0
WireConnection;0;9;4;0
ASEEND*/
//CHKSM=C74D07453465CC73A2643E58F551B3BCCDC23D49