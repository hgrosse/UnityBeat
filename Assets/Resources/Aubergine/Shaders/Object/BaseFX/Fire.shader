Shader "Aubergine/Object/BaseFX/Fire" {
	Properties {
		_NoiseTex("Noise Texture", 2D) = "white" { }
		_FireTex("Fire Texture", 2D) = "white" { }
		_AlphaTex("Alpha Texture", 2D) = "white" { }
		_Speed1("Speed1", Float) = 0.68753
		_Speed2("Speed2", Float) = 0.52000
		_Speed3("Speed3", Float) = 0.75340
		_Perturb1("Perturb1", Float) = 0.12300
		_Perturb2("Perturb2", Float) = 0.09100
		_Perturb3("Perturb3", Float) = 0.07230
		_UvOffset("UvOffset", Float) = 0.44000
		_UvMulti("UvMulti", Float) = 0.29000
	}

	SubShader {
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" "IgnoreProjector" = "True" }
		LOD 100

		Pass {
			Name "BASE"
			Tags { "LightMode" = "Always" }

			Fog { Mode off }
			ZWrite Off
			Cull Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma exclude_renderers xbox360 ps3 flash
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			sampler2D _NoiseTex, _FireTex, _AlphaTex;
			fixed _Speed1, _Speed2, _Speed3, _Perturb1, _Perturb2, _Perturb3;
			fixed _UvOffset, _UvMulti;

			struct a2v {
				float4 vertex : POSITION;
				float4 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 pos : SV_POSITION;
				float4 uv0 : TEXCOORD0;
				float4 uv1 : TEXCOORD1;
			};

			v2f vert(a2v v) {
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv0.xy = v.texcoord.xy;
				o.uv0.z = v.texcoord.x;
				o.uv0.w = -v.texcoord.y + _Speed1 * _Time.y;
				o.uv1.x = v.texcoord.x;
				o.uv1.y = -v.texcoord.y + _Speed2 * _Time.y;
				o.uv1.z = v.texcoord.x;
				o.uv1.w = -v.texcoord.y + _Speed3 * _Time.y;
				return o;
			}

			fixed4 frag(v2f i) : COLOR {
				fixed n0 = tex2D(_NoiseTex, i.uv0.zw).r * 2.0 - 1.0;
				fixed n1 = tex2D(_NoiseTex, i.uv1.xy).r * 2.0 - 1.0;
				fixed n2 = tex2D(_NoiseTex, i.uv1.zw).r * 2.0 - 1.0;
				fixed2 n = n0 * _Perturb1 + n1 * _Perturb2 + n2 * _Perturb3;
				fixed2 uv = i.uv0.xy + n * (i.uv0.y * _UvOffset + _UvMulti);
				fixed3 base = tex2D(_FireTex, uv).rgb;
				fixed alpha = tex2D(_AlphaTex, uv).r;
				return fixed4(base.rgb, alpha);
			}
			ENDCG
		}
	}

	FallBack Off
}