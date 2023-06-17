using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : MonoBehaviour
{
    public InputField inputField;
    public string password; //������ ��й�ȣ

    private GameManager gm; //���콺 Ŀ�� Ǯ�� ����

    private void Start()
    {
        gm = GetComponent<GameManager>();
        OffSafePuzzle();
    }

    public void OnSafePuzzle()
    {
        inputField.gameObject.SetActive(true);
        gm.OffMouseLock();
    }
    public void OffSafePuzzle()
    {
        inputField.gameObject.SetActive(false);
        //gm.OnMouseLock();
    }

    public void ConfirmPassword()
    {
        if(password == inputField.text)
        {
            Debug.Log("��� ����");
        }
        else
        {
            Debug.Log("�ٽ�");
        }
        OffSafePuzzle();
    }
}
