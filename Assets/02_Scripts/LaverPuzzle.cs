using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaverPuzzle : MonoBehaviour
{
    public GameObject[] lavers = new GameObject[5]; //래버를 받아올 배열
    public GameObject[] bulb = new GameObject[5]; //전구를 받아올 배열

    private bool[] isOn = new bool[5]; //전구 on, off를 확인할 배열

    public Light[] lights = new Light[5]; //전구 불빛을 받아올 배열

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
