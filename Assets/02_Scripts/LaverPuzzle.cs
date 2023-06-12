using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaverPuzzle : MonoBehaviour
{
    public GameObject[] lavers = new GameObject[5]; //������ �޾ƿ� �迭
    public GameObject[] bulb = new GameObject[5]; //������ �޾ƿ� �迭

    private bool[] isOn = new bool[5]; //���� on, off�� Ȯ���� �迭

    public Light[] lights = new Light[5]; //���� �Һ��� �޾ƿ� �迭

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
