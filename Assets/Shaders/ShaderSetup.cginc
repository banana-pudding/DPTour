struct appdata {
    float4 vertex : POSITION;
    float2 uv : TEXCOORD0;
    float4 color : COLOR;  // set from Image component property
};

struct v3f {
    float2 uv : TEXCOORD0;
    float4 vertex : SV_POSITION;
    float4 color : COLOR;
};

v3f vert (appdata v) {
    v3f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = v.uv;
    o.color = v.color;
    return o;
}

inline fixed4 mixAlpha(fixed4 mainTexColor, fixed4 color, float sdfAlpha){
    fixed4 col = mainTexColor * color;
    col.a = min(col.a, sdfAlpha);
    return col;
}
