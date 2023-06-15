using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    public Light[] lights = new Light[5]; //전구 불빛을 받아올 배열
    [SerializeField] bool[] isOn = new bool[5];

    [SerializeField] List<Lever> levers = new List<Lever>();
    public void PullLever(RaycastHit _hit)
    {
        //levers list의 길이만큼 반복문을 돈다.
        for(int i = 0; i < levers.Count; i++)
        {
            //Debug.Log("i :" + i);
            //levers에 levers이름이 raycast를 쏴서 가져온 collider.name정보와 같다면
            if (levers[i].levers.name.Equals(_hit.collider.name))
            {
                //그 안에 lightIndex-1을 해서 isOn배열의 값을 바꾼다.
                foreach (int Index in levers[i].lightIndex)
                {
                    //Debug.Log("Index :" + (Index-1));
                    isOn[Index-1] = !isOn[Index-1];
                }
                //반복문을 빠져나감
                break;
            }
        }
        OnLight();
    }

    private void OnLight()
    {
        int i = 0;
        foreach(bool isOnLight in isOn)
        {
            if (isOnLight) lights[i].intensity = 1;
            else lights[i].intensity = 0;
            i++;
        }
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
