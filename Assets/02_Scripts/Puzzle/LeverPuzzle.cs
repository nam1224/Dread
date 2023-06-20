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
        //levers list�� ���̸�ŭ �ݺ����� ����.
        for(int i = 0; i < levers.Count; i++)
        {
            //Debug.Log("i :" + i);
            //levers�� levers�̸��� raycast�� ���� ������ collider.name������ ���ٸ�
            if (levers[i].levers.name.Equals(_hit.collider.name))
            {
                //�� �ȿ� lightIndex-1�� �ؼ� isOn�迭�� ���� �ٲ۴�.
                foreach (int Index in levers[i].lightIndex)
                {
                    //Debug.Log("Index :" + (Index-1));
                    isOn[Index-1] = !isOn[Index-1];
                }
                //�ݺ����� ��������
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
        //��� �ʱ�ȭ
        for (int i = 0; i < onBulbs.Length; i++)
        {
            onBulbs[i].SetActive(false);
            isOn[i] = false;
        }
    }

    private void ClearLeverPuzzle(bool[] _isOn)
    {
        //��� ���� �����°�?
        foreach (bool isTrue in _isOn)
        {
            if (true != isTrue) return;
        }
        
    }
}
