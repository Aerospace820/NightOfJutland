using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;
   
    

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue / 2f;
    }

    void Update()
    {
        if(slider.value != 0 && Input.GetKeyDown(KeyCode.Q))
        {
            slider.value -= 0.05f;
        }

        if(slider.value != 0.4 && Input.GetKeyDown(KeyCode.E))
        {
            slider.value += 0.05f;
        }

    }
}
