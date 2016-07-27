// Shader、Property、Fallback等不区分大小写
Shader "Custom/BasicDiffuse" {
	/* 
	1、着色器属性（显示在Inspector面板上，暴露给美术调整，支持可视操作，保存面板值以便在Surf函数中使用）
	2、除了通过编辑器编辑Properties，脚本也可以通过Material的接口（比如SetFloat、SetTexture编辑）
	3、在Shader程序通过[name]（固定管线）或直接name（可编程Shader）访问这些属性。
	4、在每一个Property前面也能类似C#那样添加Attribute，以达到额外UI面板功能。详见MaterialPropertyDrawer.html。
	5、所有可能的参数如下所示。比较常用也就Float、Vector和Texture这3类
	*/
	Properties {		
		// slider滑动条取值
		_Range ("Range Property", Range(0, 10)) = 1
		// 颜色值
		_Color ("Color Property", Color) = (1, 1, 1,1)
		// 2D纹理
		_Texture2D ("Texture2D Property", 2D) = "" {}
		// 非2的幂次方纹理
		_Rect ("Rect Property", Rect) = ""
		// 立方体纹理（天空盒纹理）
		_Cube ("Cube Property", Cube) = ""
		// float值
		_Float ("Float Property", Float) = 0.1
		// Vector4(x, y, z, w)
		_Vector ("Vector Property", Vector) = (1, 1, 1, 1)


		/* -------------------如何扩展------------------------ */
		// Toggle类型
		[Toggle] _Toggle ("Toggle", Float) = 0
		// Enum列表类型
		[Enum(UnityEngine.Rendering.BlendMode)] _BlendMode ("BlendMode", Float) = 0
		// 自定义Enum列表
		[KeywordEnum(off, on)]_KeywordEnum ("KeywordEnum", Float) = 0
	}

	// 可编程管线
	SubShader {
		Pass {

		}
	}

	// 固定管线 fixed pipeline
	SubShader {
		Pass {
			Color[_Color]
		}
	}
	// 当本Shader的所有SubShader都不支持当前显卡，就会使用FallBack语句指定的另一个Shader。FallBack最好指定Unity自己预制的Shader实现，因其一般能够在当前所有显卡运行。
	FallBack "Diffuse"
}