using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    private bool[] isOn = new bool[5]; //���� on, off�� Ȯ���� �迭
    public Light[] lights = new Light[5]; //���� �Һ��� �޾ƿ� �迭

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
        //lights �迭�� ��⸦ ��� 0����, isOn �迭�� ��� false�� �ʱ�ȭ
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
    public GameObject levers; //������ �޾ƿ� �迭
    [SerializeField]
    public List<Light> list_bulb = new List<Light>(); //���� �迭�� �޾ƿ� ����Ʈ
}
