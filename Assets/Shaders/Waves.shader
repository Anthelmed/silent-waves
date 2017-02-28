Shader "Waves" {
	Properties {
		_Color("Color", Color) = (1,1,1,1)
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_BumpMap("Normal map", 2D) = "bump" {}
		_DisplacementMap("Displacement map", 2D) = "gray" {}
		_DisplacementScale("Displacement Scale", Range(0,1)) = 0
		_NoiseMap("Noise map", 2D) = "gray" {}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM

	#pragma surface surf Standard vertex:vert addshadow fullforwardshadows
	#pragma glsl
	#pragma target 3.0

	struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
	};
	sampler2D _DisplacementMap;
	float _DisplacementScale;
	sampler2D _NoiseMap;

	void vert(inout appdata_full v) {
		float noisePixel = tex2Dlod(_NoiseMap, float4(v.texcoord.xy * _SinTime * 2, 0, 0)).r * 0.15;
		float noise = noisePixel * (1 + _DisplacementScale);
		float displacementPixel = tex2Dlod(_DisplacementMap, float4(v.texcoord.xy, 0, 0)).r;
		float displacement = displacementPixel * (_DisplacementScale * 3.5);
		v.vertex.xyz += v.normal * (displacement > 0.01f) ? displacement + noise : displacement;
	}

	sampler2D _BumpMap;
	fixed4 _Color;
	half _Glossiness;
	half _Metallic;

	void surf(Input IN, inout SurfaceOutputStandard o) {
		fixed4 c = _Color;
		o.Albedo = c.rgb;
		o.Metallic = _Metallic;
		o.Smoothness = _Glossiness;
		o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
		o.Alpha = c.a;
	}
	ENDCG
	}
		Fallback "Diffuse"
}