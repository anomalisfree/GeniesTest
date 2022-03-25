Shader "Custom/TwoTextures"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color1 ("Tint Color", Color) = (1,1,1)
        _BlendTex ("Alpha Blended (RGBA) ", 2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            Lighting On

            SetTexture [_MainTex] {
            ConstantColor [_Color1]
            combine texture * constant
            }

            SetTexture [_BlendTex] {
            combine texture lerp (texture) previous
            }
        }
    }
}