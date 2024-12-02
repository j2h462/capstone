using UnityEngine;
using UnityEngine.UI; 

public class BrightnessController : MonoBehaviour
{
    // 슬라이더와 초기값
    public Slider brightnessSlider; 
    public Light directionalLight;

    void Start()
    {
        brightnessSlider.onValueChanged.AddListener(OnBrightnessChange);
        
        brightnessSlider.value = 0.5f; 
    }

    void OnBrightnessChange(float value)
    {
        if (directionalLight != null)
        {
    
            directionalLight.intensity = Mathf.Lerp(0.1f, 2f, value);
        }

    
        RenderSettings.ambientLight = Color.white * value;
    }
}
