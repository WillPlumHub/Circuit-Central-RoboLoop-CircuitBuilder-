using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;

public class PowerBar : MonoBehaviour
{

    public float powerBarChargeSpeed = .25F;
    public bool powerBarRoutineRunning = true;

    public Slider powerBarSlider;
    public TextMeshProUGUI powerDisplay;
    public Image powerBarPressSpace;

    private float currentSliderValue;
    private float powerBarMin;
    private float powerBarMax;


    private float interval = .1f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentSliderValue = powerBarSlider.value;
        powerBarMin = powerBarSlider.minValue;
        powerBarMax = powerBarSlider.maxValue;

        powerBarChargeSpeed = UnityEngine.Random.Range(2f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (powerBarRoutineRunning)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                timer -= interval;

                currentSliderValue = powerBarSlider.value;
                powerBarSlider.value += powerBarChargeSpeed;

                if (currentSliderValue == powerBarMax)
                {
                    powerBarSlider.value = 0;
                    powerBarChargeSpeed = UnityEngine.Random.Range(2f, 2.5f);
                }

                if (currentSliderValue < powerBarMax)
                {
                    powerBarSlider.value += powerBarChargeSpeed;
                }

                currentSliderValue = powerBarSlider.value;


                powerDisplay.text = MathF.Round(currentSliderValue).ToString() + "x";
            }
        }

    }
}
