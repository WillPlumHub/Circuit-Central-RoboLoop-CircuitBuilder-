using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PowerBar : MonoBehaviour
{

    public float powerBarChargeSpeed = .01F;
    public bool powerBarRoutineRunning = false;
    public bool powerBarRunningUp = true;
    public float currentSliderValue;

    public Slider powerBarSlider;

    private float powerBarMin;
    private float powerBarMax;
    
    // Start is called before the first frame update
    void Start()
    {
        currentSliderValue = powerBarSlider.value;
        powerBarMin = powerBarSlider.minValue;
        powerBarMax = powerBarSlider.maxValue;

        powerBarChargeSpeed = UnityEngine.Random.Range(.1F, 1F);
    }

    // Update is called once per frame
    void Update()
    {
        
        currentSliderValue = powerBarSlider.value;
        powerBarSlider.value += powerBarChargeSpeed;
        
        if(currentSliderValue == powerBarMax)
        {
            powerBarSlider.value = 0;
            powerBarChargeSpeed = UnityEngine.Random.Range(.1F, 1F);
        }

        Debug.Log(currentSliderValue);

        if(currentSliderValue < powerBarMax)
        {
            powerBarSlider.value += powerBarChargeSpeed;
        }
    }
}
