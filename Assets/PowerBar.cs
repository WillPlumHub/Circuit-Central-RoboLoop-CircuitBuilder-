using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class PowerBar : MonoBehaviour
{

    public double FillPercent = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FillPercent += 0.1;
        
    }
}
