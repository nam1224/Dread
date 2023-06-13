using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    private bool[] isOn = new bool[5]; //전구 on, off를 확인할 배열
    public Light[] lights = new Light[5]; //전구 불빛을 받아올 배열

    [SerializeField] List<Lever> leverSystem = new List<Lever>();

    public void WorkBulb()
    {
        
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        //lights 배열의 밝기를 모두 0으로, isOn 배열을 모두 false로 초기화
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = 0;
            isOn[i] = false;
        }
    }
}

[System.Serializable]
public class Lever
{
    public GameObject levers; //래버를 받아올 배열
    [SerializeField]
    public List<Light> list_bulb = new List<Light>(); //전구 배열을 받아올 리스트
}
