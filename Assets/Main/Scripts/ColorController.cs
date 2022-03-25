using UnityEngine;
using UnityEngine.UI;

namespace Main.Scripts
{
    public class ColorController : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [SerializeField] private Image backgroundSliderHandle;
        [SerializeField] private SkinnedMeshRenderer heroSkinnedMeshRenderer;
        
        private static readonly int TintColor = Shader.PropertyToID("_Color1");

        public void ChangeCameraColor(float value)
        {
            Color.RGBToHSV(camera.backgroundColor, out _, out var s, out var v);
            camera.backgroundColor = backgroundSliderHandle.color = Color.HSVToRGB(value, s, v);
        }

        public void ChangeSkinColor(float value)
        {
            if (value > .7f) value = .7f;
            
            foreach (var material in heroSkinnedMeshRenderer.materials)
            {
                material.SetColor(TintColor, Color.HSVToRGB(0.06f, value, 1f - value));
            }
        }
    }
}