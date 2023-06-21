using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�ð��� �帣�� ���͸��� �ٰ�, ���͸��� �ٸ� ���� ���⵵ �پ���.

public class Flashlight : MonoBehaviour
{
    public Light light;
    public float energy; //���� ���͸��� ��
    public GameManager gameManager;
    private const float ENERGY_MAX = 420; //���͸��� �ִ��
    private int newWidth;

    private float useTime; //����� �ð�

    private bool isOn = false; //������ on, off

    public Image image; // �̹��� ������Ʈ�� �Ҵ��ϱ� ���� ����

    private RectTransform imageRectTransform; // �̹����� RectTransform ������Ʈ


    private void Start()
    {
        imageRectTransform = image.GetComponent<RectTransform>();
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
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            LightOn(isOn);
        }
        */
        if (energy>350)
        {
            newWidth = 100;
        }
        else if (energy > 280)
        {
            newWidth = 80;
        }
        else if (energy>210)
        {
            newWidth = 60;
        }
        else if (energy > 140)
        {
            newWidth = 40;
        }
        else if (energy > 70)
        {
            newWidth = 20;
        }
        else
        {
            newWidth = 0;
        }

        // ������ �ʺ� ��

        // �̹����� ���� RectTransform �� ����
        Vector2 sizeDelta = imageRectTransform.sizeDelta;

        // �ʺ� ����
        sizeDelta.x = newWidth;

        // ����� �ʺ� �̹����� ����
        imageRectTransform.sizeDelta = sizeDelta;

        if (energy <= 0)  //if player enegry <= 0 = player die
        {
            gameManager.Die();//�ͽ� 4? ���ͽ��� �÷��̾ �����Ŵ(ȭ��Ǳͽ�ó��)   
        }
    }


    //������ on / off
    public int brightness = 10;
    void LightOn(bool _isOn)
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
    public void ChargeEnergy()
    {
        energy += chargeAmount;
        useTime -= chargeAmount;
        if (energy > ENERGY_MAX) energy = ENERGY_MAX;
        if (useTime < 0) useTime = 0;
        //Debug.Log(energy + useTime);
    }


    //�������� ������ �������� ���� �����ϴ� �Լ� @����
    public void EnergyDown(int G_damage)
    {
        //energy = energy-G_damage;
        energy = energy - G_damage;
        Debug.Log(energy);
    }
}