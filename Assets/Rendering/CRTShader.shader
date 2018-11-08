Shader "Hidden/CRTShader" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			uniform sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target {           
				float2 cc = i.uv - 0.5f;
				float dist = dot(cc, cc) * 0.3f;
				float2 xy = (i.uv + cc * (1.0f + dist) * dist);
				return tex2D(_MainTex, xy);
			}
			ENDCG
		}
	}
}