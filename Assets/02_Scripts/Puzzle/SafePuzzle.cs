using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : MonoBehaviour
{
    public InputField inputField;
    public string password; //������ ��й�ȣ

    public GameManager gm; //���콺 Ŀ�� Ǯ�� ����

    public AudioSource audioSource;
    public AudioClip lockOffAudio; //��� ���� �Ҹ�
    private void Start()
    {
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
        gm.OnMouseLock();
    }

    public void ConfirmPassword()
    {
        if(password == inputField.text)
        {
            Debug.Log("��� ����");
            audioSource.PlayOneShot(lockOffAudio, 1.0f);
        }
        else
        {
            Debug.Log("�ٽ�");
        }
        OffSafePuzzle();
    }
}
