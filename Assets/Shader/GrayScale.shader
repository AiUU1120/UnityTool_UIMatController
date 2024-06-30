Shader "Custom/GrayScale"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _IsGrayScale ("Is GrayScale", Range(0, 1)) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent" "RenderType"="Transparent"
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
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
            bool _IsGrayScale;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 tex = tex2D(_MainTex, i.uv);
                // 判断是否是灰度效果
                if (_IsGrayScale)
                {
                    // 转换为灰度
                    float gray = dot(tex.rgb, float3(0.299, 0.587, 0.114));
                    // 输出灰色
                    return fixed4(gray, gray, gray, tex.a);
                }
                else
                {
                    // 输出彩色
                    return tex;
                }
            }
            
            ENDCG
        }
    }
}