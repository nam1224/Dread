using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ð��� �帣�� ���͸��� �ٰ�, ���͸��� �ٸ� ���� ���⵵ �پ���.

public class Flashlight : MonoBehaviour
{
    public Light light;
    public float energy; //���� ���͸��� ��
    private const float ENERGY_MAX = 100; //���͸��� �ִ��

    private float useTime; //����� �ð�
    private const float USE_TIME_MAX = 300; //����� �� �ִ� �ִ� �ð�

    private bool isOn = true; //������ on, off

    private void Start()
    {

    }


    void Update()
    {
        useTime += Time.deltaTime;
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