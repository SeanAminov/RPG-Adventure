using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
    public Health playerHealth;
   public Image fillImage;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;
        

        if (slider.value <= slider.minValue) {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue &&!fillImage.enabled) {
            fillImage.enabled = true;
        }

        if (fillValue <= slider.maxValue/33) {
            fillImage.color = Color.white;
        } else if (fillValue > slider.maxValue/33) {
            fillImage.color = Color.red;
        }

        slider.value = fillValue;
    }
}
