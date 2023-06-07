using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���͸��� �ټ��� ���� ���⵵ �پ���.

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


    //������ on / off
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