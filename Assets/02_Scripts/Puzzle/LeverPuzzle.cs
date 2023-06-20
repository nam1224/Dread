using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeverPuzzle : MonoBehaviour
{
    public GameObject[] bulbs = new GameObject[5];
    public GameObject[] onBulbs = new GameObject[5];
    bool[] isOn = new bool[5];

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
            if (isOnLight) onBulbs[i].SetActive(true);
            else onBulbs[i].SetActive(false);
            i++;
        }
    }

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        ClearLeverPuzzle(isOn);
    }

    private void Reset()
    {
        //모두 초기화
        for (int i = 0; i < onBulbs.Length; i++)
        {
            onBulbs[i].SetActive(false);
            isOn[i] = false;
        }
    }

    private void ClearLeverPuzzle(bool[] _isOn)
    {
        //모두 불이 켜졌는가?
        foreach (bool isTrue in _isOn)
        {
            if (true != isTrue) return;
        }
        
    }
}
