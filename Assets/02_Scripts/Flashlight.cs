using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ð��� �帣�� ���͸��� �ٰ�, ���͸��� �ٸ� ���� ���⵵ �پ���.

public class Flashlight : MonoBehaviour
{
    public Light light;
    public float energy; //���� ���͸��� ��
    private const float ENERGY_MAX = 300; //���͸��� �ִ��

    private float useTime; //����� �ð�

    private bool isOn = false; //������ on, off

    private void Start()
    {

    }


    void Update()
    {
        if (!isOn)
        {
            useTime += Time.deltaTime;
            energy = ENERGY_MAX - useTime;
            light.intensity = energy / ENERGY_MAX;
            //Debug.Log(energy);
        }

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

    public float chargeAmount;
    //���͸� ���� �Լ�
    public void chargeEnergy()
    {
        energy += chargeAmount;
        useTime -= chargeAmount;
        if (energy > ENERGY_MAX) energy = ENERGY_MAX;
        if (useTime < 0) useTime = 0;
        Debug.Log(energy + useTime);
    }
}