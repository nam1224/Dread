using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    public Light[] lights = new Light[5]; //���� �Һ��� �޾ƿ� �迭
    [SerializeField] bool[] isOn = new bool[5];

    [SerializeField] List<Lever> levers = new List<Lever>();
    public void OnBulb()
    {
        //levers[0].
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        /*
        //lights �迭�� ��⸦ ��� 0����, isOn �迭�� ��� false�� �ʱ�ȭ
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = 0;
            isOn[i] = false;
        }
        */
    }
}
