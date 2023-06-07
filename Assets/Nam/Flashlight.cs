using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//베터리가 줄수록 빛의 세기도 줄어든다.

public class Flashlight : MonoBehaviour
{
    public Light light;
    private bool isOn = true;

    private void Start()
    {
        //light.intensity = 1.5f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lightOn(isOn);
        }
    }


    //손전등 on / off
    public int brightness = 10;
    void lightOn(bool _isOn)
    {
        if (_isOn)
        {
            Debug.Log("on");
            light.range = brightness;
            isOn = false;
        }
        else
        {
            Debug.Log("off");
            light.range = 0;
            isOn = true;
        }
    }
}