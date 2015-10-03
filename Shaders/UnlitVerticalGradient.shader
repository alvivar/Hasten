// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:33079,y:32515,varname:node_3138,prsc:2|emission-9684-OUT,alpha-8892-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32606,y:32477,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6901961,c2:0.7921569,c3:0.8431373,c4:1;n:type:ShaderForge.SFN_Color,id:6535,x:32435,y:32681,ptovrint:False,ptlb:Blend,ptin:_Blend,varname:node_6535,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1921569,c2:0.2705882,c3:0.3254902,c4:1;n:type:ShaderForge.SFN_TexCoord,id:5057,x:32405,y:32866,varname:node_5057,prsc:2,uv:0;n:type:ShaderForge.SFN_Lerp,id:9684,x:32855,y:32574,varname:node_9684,prsc:2|A-7241-RGB,B-6535-RGB,T-8549-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8549,x:32617,y:32882,varname:node_8549,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5057-V;n:type:ShaderForge.SFN_Lerp,id:8892,x:32855,y:32739,varname:node_8892,prsc:2|A-7241-A,B-6535-A,T-8549-OUT;proporder:7241-6535;pass:END;sub:END;*/

Shader "Shader Forge/UnlitVerticalGradient" {
    Properties {
        _Color ("Color", Color) = (0.6901961,0.7921569,0.8431373,1)
        _Blend ("Blend", Color) = (0.1921569,0.2705882,0.3254902,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float4 _Blend;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float node_8549 = i.uv0.g.r;
                float3 emissive = lerp(_Color.rgb,_Blend.rgb,node_8549);
                float3 finalColor = emissive;
                return fixed4(finalColor,lerp(_Color.a,_Blend.a,node_8549));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
