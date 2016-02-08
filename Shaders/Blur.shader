// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Standard,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:33710,y:33347,varname:node_9361,prsc:2|custl-3158-OUT;n:type:ShaderForge.SFN_ScreenPos,id:2553,x:31315,y:32312,varname:node_2553,prsc:2,sctp:2;n:type:ShaderForge.SFN_Slider,id:4058,x:31315,y:32549,ptovrint:False,ptlb:Blur,ptin:_Blur,varname:_Offset,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.02;n:type:ShaderForge.SFN_SceneColor,id:9052,x:32421,y:32873,varname:node_9052,prsc:2|UVIN-6636-OUT;n:type:ShaderForge.SFN_Set,id:883,x:31645,y:32528,varname:blurOffset,prsc:2|IN-4058-OUT;n:type:ShaderForge.SFN_Set,id:8205,x:31493,y:32292,varname:screenPosUV,prsc:2|IN-2553-UVOUT;n:type:ShaderForge.SFN_Set,id:5039,x:31493,y:32352,varname:screenPosU,prsc:2|IN-2553-U;n:type:ShaderForge.SFN_Set,id:2669,x:31495,y:32407,varname:screenPosV,prsc:2|IN-2553-V;n:type:ShaderForge.SFN_Get,id:5645,x:31831,y:32873,varname:node_5645,prsc:2|IN-883-OUT;n:type:ShaderForge.SFN_Get,id:8657,x:31831,y:32933,varname:node_8657,prsc:2|IN-5039-OUT;n:type:ShaderForge.SFN_Add,id:5126,x:32035,y:32873,varname:node_5126,prsc:2|A-5645-OUT,B-8657-OUT;n:type:ShaderForge.SFN_Get,id:5204,x:31831,y:33102,varname:node_5204,prsc:2|IN-883-OUT;n:type:ShaderForge.SFN_Get,id:1976,x:31831,y:33164,varname:node_1976,prsc:2|IN-2669-OUT;n:type:ShaderForge.SFN_Add,id:292,x:32035,y:33102,varname:node_292,prsc:2|A-5204-OUT,B-1976-OUT;n:type:ShaderForge.SFN_SceneColor,id:5516,x:32421,y:33102,varname:node_5516,prsc:2|UVIN-7298-OUT;n:type:ShaderForge.SFN_Append,id:6636,x:32229,y:32873,varname:node_6636,prsc:2|A-5126-OUT,B-3857-OUT;n:type:ShaderForge.SFN_Get,id:3857,x:32208,y:32811,varname:node_3857,prsc:2|IN-2669-OUT;n:type:ShaderForge.SFN_Append,id:7298,x:32229,y:33102,varname:node_7298,prsc:2|A-450-OUT,B-292-OUT;n:type:ShaderForge.SFN_Get,id:450,x:32208,y:33022,varname:node_450,prsc:2|IN-5039-OUT;n:type:ShaderForge.SFN_Set,id:576,x:32636,y:32873,varname:horizontal,prsc:2|IN-9052-RGB;n:type:ShaderForge.SFN_Set,id:1344,x:32636,y:33102,varname:vertical,prsc:2|IN-5516-RGB;n:type:ShaderForge.SFN_SceneColor,id:2909,x:32421,y:32666,varname:node_2909,prsc:2|UVIN-3255-OUT;n:type:ShaderForge.SFN_Get,id:2846,x:31831,y:32666,varname:node_2846,prsc:2|IN-883-OUT;n:type:ShaderForge.SFN_Get,id:2460,x:31831,y:32726,varname:node_2460,prsc:2|IN-5039-OUT;n:type:ShaderForge.SFN_Append,id:3255,x:32229,y:32666,varname:node_3255,prsc:2|A-5472-OUT,B-2778-OUT;n:type:ShaderForge.SFN_Get,id:2778,x:32208,y:32604,varname:node_2778,prsc:2|IN-2669-OUT;n:type:ShaderForge.SFN_Set,id:8659,x:32636,y:32666,varname:horizontalInv,prsc:2|IN-2909-RGB;n:type:ShaderForge.SFN_Subtract,id:5472,x:32035,y:32666,varname:node_5472,prsc:2|A-2460-OUT,B-2846-OUT;n:type:ShaderForge.SFN_Get,id:6927,x:31831,y:33329,varname:node_6927,prsc:2|IN-883-OUT;n:type:ShaderForge.SFN_Get,id:6833,x:31831,y:33389,varname:node_6833,prsc:2|IN-2669-OUT;n:type:ShaderForge.SFN_SceneColor,id:3328,x:32421,y:33329,varname:node_3328,prsc:2|UVIN-4284-OUT;n:type:ShaderForge.SFN_Append,id:4284,x:32229,y:33329,varname:node_4284,prsc:2|A-7277-OUT,B-2291-OUT;n:type:ShaderForge.SFN_Get,id:7277,x:32208,y:33249,varname:node_7277,prsc:2|IN-5039-OUT;n:type:ShaderForge.SFN_Set,id:2951,x:32636,y:33329,varname:verticalInv,prsc:2|IN-3328-RGB;n:type:ShaderForge.SFN_Subtract,id:2291,x:32035,y:33329,varname:node_2291,prsc:2|A-6833-OUT,B-6927-OUT;n:type:ShaderForge.SFN_Get,id:4509,x:32838,y:33329,varname:node_4509,prsc:2|IN-1344-OUT;n:type:ShaderForge.SFN_Get,id:7480,x:32838,y:33392,varname:node_7480,prsc:2|IN-2951-OUT;n:type:ShaderForge.SFN_Add,id:4222,x:33058,y:33329,varname:node_4222,prsc:2|A-4509-OUT,B-7480-OUT;n:type:ShaderForge.SFN_Get,id:7481,x:32838,y:33522,varname:node_7481,prsc:2|IN-576-OUT;n:type:ShaderForge.SFN_Get,id:5444,x:32838,y:33585,varname:node_5444,prsc:2|IN-8659-OUT;n:type:ShaderForge.SFN_Add,id:9388,x:33058,y:33522,varname:node_9388,prsc:2|A-7481-OUT,B-5444-OUT;n:type:ShaderForge.SFN_Vector1,id:6569,x:33494,y:33347,varname:node_6569,prsc:2,v1:9;n:type:ShaderForge.SFN_Add,id:9096,x:33295,y:33439,varname:node_9096,prsc:2|A-4222-OUT,B-9388-OUT,C-1707-OUT,D-5450-OUT;n:type:ShaderForge.SFN_Divide,id:3158,x:33494,y:33439,varname:node_3158,prsc:2|A-9096-OUT,B-6569-OUT;n:type:ShaderForge.SFN_Get,id:8871,x:31831,y:33523,varname:node_8871,prsc:2|IN-883-OUT;n:type:ShaderForge.SFN_Get,id:2087,x:31831,y:33596,varname:node_2087,prsc:2|IN-8205-OUT;n:type:ShaderForge.SFN_Add,id:7886,x:32035,y:33523,varname:node_7886,prsc:2|A-8871-OUT,B-2087-OUT;n:type:ShaderForge.SFN_SceneColor,id:7273,x:32229,y:33523,varname:node_7273,prsc:2|UVIN-7886-OUT;n:type:ShaderForge.SFN_Set,id:742,x:32421,y:33523,varname:corner1,prsc:2|IN-7273-RGB;n:type:ShaderForge.SFN_Get,id:9998,x:32838,y:33705,varname:node_9998,prsc:2|IN-742-OUT;n:type:ShaderForge.SFN_Add,id:1707,x:33058,y:33705,varname:node_1707,prsc:2|A-9998-OUT,B-4493-OUT;n:type:ShaderForge.SFN_Get,id:4493,x:32838,y:33789,varname:node_4493,prsc:2|IN-5806-OUT;n:type:ShaderForge.SFN_Get,id:770,x:31831,y:33730,varname:node_770,prsc:2|IN-883-OUT;n:type:ShaderForge.SFN_Get,id:7253,x:31831,y:33803,varname:node_7253,prsc:2|IN-8205-OUT;n:type:ShaderForge.SFN_SceneColor,id:5041,x:32229,y:33730,varname:node_5041,prsc:2|UVIN-2382-OUT;n:type:ShaderForge.SFN_Set,id:5806,x:32421,y:33730,varname:corner1Inv,prsc:2|IN-5041-RGB;n:type:ShaderForge.SFN_Subtract,id:2382,x:32035,y:33730,varname:node_2382,prsc:2|A-7253-OUT,B-770-OUT;n:type:ShaderForge.SFN_Get,id:1746,x:31831,y:33957,varname:node_1746,prsc:2|IN-5039-OUT;n:type:ShaderForge.SFN_Get,id:6431,x:31831,y:34049,varname:node_6431,prsc:2|IN-883-OUT;n:type:ShaderForge.SFN_Get,id:6295,x:31831,y:34150,varname:node_6295,prsc:2|IN-2669-OUT;n:type:ShaderForge.SFN_Add,id:7102,x:32035,y:33957,varname:node_7102,prsc:2|A-1746-OUT,B-6431-OUT;n:type:ShaderForge.SFN_Subtract,id:8341,x:32035,y:34127,varname:node_8341,prsc:2|A-6295-OUT,B-6431-OUT;n:type:ShaderForge.SFN_Append,id:8371,x:32229,y:33957,varname:node_8371,prsc:2|A-7102-OUT,B-8341-OUT;n:type:ShaderForge.SFN_Set,id:7830,x:32621,y:33953,varname:corner2,prsc:2|IN-3619-RGB;n:type:ShaderForge.SFN_Get,id:6211,x:31831,y:34304,varname:node_6211,prsc:2|IN-2669-OUT;n:type:ShaderForge.SFN_Get,id:1962,x:31831,y:34396,varname:node_1962,prsc:2|IN-883-OUT;n:type:ShaderForge.SFN_Get,id:7979,x:31831,y:34497,varname:node_7979,prsc:2|IN-5039-OUT;n:type:ShaderForge.SFN_Add,id:3052,x:32035,y:34304,varname:node_3052,prsc:2|A-6211-OUT,B-1962-OUT;n:type:ShaderForge.SFN_Subtract,id:6876,x:32035,y:34474,varname:node_6876,prsc:2|A-7979-OUT,B-1962-OUT;n:type:ShaderForge.SFN_Append,id:1620,x:32229,y:34304,varname:node_1620,prsc:2|A-6876-OUT,B-3052-OUT;n:type:ShaderForge.SFN_Set,id:1964,x:32646,y:34296,varname:corner2Inv,prsc:2|IN-3650-RGB;n:type:ShaderForge.SFN_Add,id:5450,x:33058,y:33893,varname:node_5450,prsc:2|A-5844-OUT,B-465-OUT,C-8727-OUT;n:type:ShaderForge.SFN_Get,id:5844,x:32838,y:33893,varname:node_5844,prsc:2|IN-7830-OUT;n:type:ShaderForge.SFN_Get,id:465,x:32838,y:33969,varname:node_465,prsc:2|IN-1964-OUT;n:type:ShaderForge.SFN_SceneColor,id:3619,x:32430,y:33953,varname:node_3619,prsc:2|UVIN-8371-OUT;n:type:ShaderForge.SFN_SceneColor,id:3650,x:32434,y:34296,varname:node_3650,prsc:2|UVIN-1620-OUT;n:type:ShaderForge.SFN_SceneColor,id:9171,x:32421,y:32445,varname:node_9171,prsc:2|UVIN-1487-OUT;n:type:ShaderForge.SFN_Set,id:8935,x:32636,y:32445,varname:all,prsc:2|IN-9171-RGB;n:type:ShaderForge.SFN_Get,id:1487,x:32208,y:32445,varname:node_1487,prsc:2|IN-8205-OUT;n:type:ShaderForge.SFN_Get,id:8727,x:32838,y:34044,varname:node_8727,prsc:2|IN-8935-OUT;proporder:4058;pass:END;sub:END;*/

Shader "Shader Forge/Hasten/Blur" {
    Properties {
        _Blur ("Blur", Range(0, 0.02)) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11 gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float _Blur;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 screenPos : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float screenPosU = sceneUVs.r;
                float blurOffset = _Blur;
                float screenPosV = sceneUVs.g;
                float3 vertical = tex2D( _GrabTexture, float2(screenPosU,(blurOffset+screenPosV))).rgb;
                float3 verticalInv = tex2D( _GrabTexture, float2(screenPosU,(screenPosV-blurOffset))).rgb;
                float3 horizontal = tex2D( _GrabTexture, float2((blurOffset+screenPosU),screenPosV)).rgb;
                float3 horizontalInv = tex2D( _GrabTexture, float2((screenPosU-blurOffset),screenPosV)).rgb;
                float2 screenPosUV = sceneUVs.rg;
                float3 corner1 = tex2D( _GrabTexture, (blurOffset+screenPosUV)).rgb;
                float3 corner1Inv = tex2D( _GrabTexture, (screenPosUV-blurOffset)).rgb;
                float node_6431 = blurOffset;
                float3 corner2 = tex2D( _GrabTexture, float2((screenPosU+node_6431),(screenPosV-node_6431))).rgb;
                float node_1962 = blurOffset;
                float3 corner2Inv = tex2D( _GrabTexture, float2((screenPosU-node_1962),(screenPosV+node_1962))).rgb;
                float3 all = tex2D( _GrabTexture, screenPosUV).rgb;
                float3 finalColor = (((vertical+verticalInv)+(horizontal+horizontalInv)+(corner1+corner1Inv)+(corner2+corner2Inv+all))/9.0);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Standard"
    CustomEditor "ShaderForgeMaterialInspector"
}
