using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//시간이 흐르면 베터리가 줄고, 베터리가 줄면 빛의 세기도 줄어든다.

public class Flashlight : MonoBehaviour
{
    public Light light;
    public float energy; //현재 베터리의 양
    private const float ENERGY_MAX = 300; //베터리의 최대양

    private float useTime; //사용한 시간
    private const float USE_TIME_MAX = 300; //사용할 수 있는 최대 시간

    private bool isOn = false; //손전등 on, off

    private void Start()
    {

    }


    void Update()
    {
        //시간이 흐르면 에너지가 소모됨
        if(!isOn)
        {
            useTime += Time.deltaTime;
            energy = ENERGY_MAX - useTime;
            light.intensity = energy / ENERGY_MAX;
            //Debug.Log(energy);
        }   

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