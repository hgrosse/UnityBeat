Shader "Aubergine/Object/Surf/Sample/Diffuse-Fire" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
		/* FIRE SHADER PROPERTIES */
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
		Tags { "RenderType" = "Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma exclude_renderers xbox360 ps3 flash
		#pragma surface surf Lambert

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG

		/* FIRE SHADER PASS */
		UsePass "Aubergine/Object/BaseFX/Fire/BASE"
	} 

	FallBack "Diffuse"
}