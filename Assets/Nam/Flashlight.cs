using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light light;
    private bool isOn = true;
    
    private void Start()
    {
        //light.intensity = 1.5f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            lightOn(isOn);
        }
    }

    void lightOn(bool isOn)
    {
        if(isOn)
        {
            light.range = 50;
            isOn = false;
        }
        else
        {
            light.range = 0;
            isOn = true;
        }
    }
}
