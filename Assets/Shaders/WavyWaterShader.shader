Shader "Unlit/WavyWater"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_WaveHeight ("Wave Height", Float) = 1.0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			//this is the data passed to the vertext shader
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex; //this is a twin of the Property above
			float4 _MainTex_ST; //scale / translate
			
			float _WaveHeight;
			
			//VERTEX SHADER
			v2f vert (appdata v)
			{
				v2f o;
				_WaveHeight*=sin(_Time.y);
				//MVP = model view projection
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.vertex += float4(0.,sin(_Time.y + o.vertex.x + o.vertex.z)*_WaveHeight,0., 0.);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			//FRAGMENT SHADER
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv + fixed2(sin(_Time.x)*2,cos(_Time.x)*2));
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);				
				return col;
			}
			ENDCG
		}
	}
}
