using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//시간이 흐르면 베터리가 줄고, 베터리가 줄면 빛의 세기도 줄어든다.

public class Flashlight : MonoBehaviour
{
    public Light light;
    public float energy; //현재 베터리의 양
    public GameManager gameManager;
    private const float ENERGY_MAX = 420; //베터리의 최대양
    private int newWidth;

    private float useTime; //사용한 시간

    private bool isOn = false; //손전등 on, off

    public Image image; // 이미지 컴포넌트를 할당하기 위한 변수

    private RectTransform imageRectTransform; // 이미지의 RectTransform 컴포넌트


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

        // 변경할 너비 값

        // 이미지의 현재 RectTransform 값 복사
        Vector2 sizeDelta = imageRectTransform.sizeDelta;

        // 너비 변경
        sizeDelta.x = newWidth;

        // 변경된 너비를 이미지에 적용
        imageRectTransform.sizeDelta = sizeDelta;

        if (energy <= 0)  //if player enegry <= 0 = player die
        {
            gameManager.Die();//귀신 4? 우빈귀신이 플레이어를 사망시킴(화장실귀신처럼)   
        }
    }


    //손전등 on / off
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
    //베터리 충전 함수
    public void ChargeEnergy()
    {
        energy += chargeAmount;
        useTime -= chargeAmount;
        if (energy > ENERGY_MAX) energy = ENERGY_MAX;
        if (useTime < 0) useTime = 0;
        //Debug.Log(energy + useTime);
    }


    //손전등의 전력이 유령으로 인해 감소하는 함수 @공명
    public void EnergyDown(int G_damage)
    {
        //energy = energy-G_damage;
        energy = energy - G_damage;
        Debug.Log(energy);
    }
}