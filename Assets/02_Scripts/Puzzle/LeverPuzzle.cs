using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    public Light[] lights = new Light[5]; //���� �Һ��� �޾ƿ� �迭
    [SerializeField] bool[] isOn = new bool[5];

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
        //lights �迭�� ��⸦ ��� 0����, isOn �迭�� ��� false�� �ʱ�ȭ
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = 0;
            isOn[i] = false;
        }
    }
}
