Shader "Custom/ShaderInfo" {
	// 着色器属性（显示在Inspector面板上，并支持可视操作，保存面板值）
	Properties {		
		_MainTex ("1-Base Tex (RGB)", 2D) = "white" {}
		//_Range ("2-Range", Range(0, 10)) = 1
		//_Color ("3-Color", Color) = (1,1,1,1)
		// _Rect ("4-Rect", Rect) = 
		// _Cube ("5-Cube", Cube) = 
		//_Float ("6-Float", Float) = 0.1
		//_Vector ("7-Vector", Vector) = (1,1,1,1)

	}

	// 渲染通道
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// 表面着色器，光照模型
		#pragma surface surf Lambert

		// 取样（从纹理中取样数据）
		sampler2D _MainTex;

		// 表面处理输入结构
		struct Input {
			float2 uv_MainTex; // 取样的UV数据
		};

		// 表面着色器处理函数（接受一个输入结构Input，并输出）
		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
