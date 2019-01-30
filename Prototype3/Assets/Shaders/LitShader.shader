// Upgrade NOTE: replaced 'glstate.matrix.mvp' with 'UNITY_MATRIX_MVP'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/LitShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        // Physically based Standard lighting model, and enable shadows on all light types
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows fragment:frag vertex:vert addshadow
		
		struct appdata {
			float4 vertex : POSITION;
			float4 texcoord : TEXCOORD0;
		};
		struct v2f {
			float4 pos : POSITION;
			float uv : TEXCOORD0;
		};
		float4 getNewVertPosition(float4 p)
		{
			float speed = 1;
			float amount = 5;
			float distance = 0.1;
			p.x += sin(_Time.y * speed + p.y * amount) * distance;
			return p;
		}
		void vert(inout appdata_full v)
		{
			float meltY = -4.0;
			float meltDistance = 6.0;

			float melt = (UnityObjectToClipPos(v.vertex).y - meltY / meltDistance);
			melt = 0 - saturate(melt);
			v.vertex.y += melt;

			/*v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = float4(v.texcoord1.xy, 0, 0);
			float4 bitangent = float4(cross(v.normal, v.tangent), 1.0);
			float4 position = getNewVertPosition(v.vertex);
			float4 positionAndTangent = getNewVertPosition(v.vertex.x * v.tangent * 0.01);
			float4 positionAndBitangent = getNewVertPosition(v.vertex.x + bitangent * 0.01);

			float4 newTangent = (positionAndTangent - position);
			float4 newBitangent = (positionAndBitangent - position);

			float newNormal = cross(newTangent, newBitangent);
			v.normal = newNormal;

			float4 worldSpacePosition = mul(unity_ObjectToWorld, o.pos);
			float worldSpaceNormal = mul(unity_ObjectToWorld, float4(v.normal, 0));
			return o;*/
			//v.vertex.x += sin(_Time.y * speed + v.vertex.y * amount) * distance;
		}


        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
