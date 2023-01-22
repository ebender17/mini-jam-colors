Shader "Unlit/Grayscale"
{
    Properties
    {
        [_PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _GrayscaleAmount("Grayscale Amount", Range(0, 1)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile DUMMY PIXELSNAP_ON

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }

            uniform float _GrayscaleAmount;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                //1st way
                //col = (col.r + col.b + col.g) / 3;
                
                //2nd way
                col.rgb = lerp(col.rgb, dot(col.rgb, float3(0.3, 0.59, 0.11)), _GrayscaleAmount);
                return col;
            }
            ENDCG
        }
    }
}
