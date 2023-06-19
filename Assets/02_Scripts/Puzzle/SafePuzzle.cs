using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : MonoBehaviour
{
    public TextManager textmanager;

    public InputField inputField;
    public string password; //������ ��й�ȣ

    public GameManager gm; //���콺 Ŀ�� Ǯ�� ����

    public AudioSource audioSource;
    public AudioClip lockOffAudio; //��� ���� �Ҹ�
    private void Start()
    {
        OffSafePuzzle();
        battery.SetActive(false);
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
            audioSource.PlayOneShot(lockOffAudio, 1.0f);
            //textmanager.Text("����", "");
            Debug.Log("����");
            ClearSafePuzzle();
        }
        else
        {
            //textmanager.Text("Ʋ��", "");
            Debug.Log("Ʋ��");
        }
        inputField.text = "";
        OffSafePuzzle();
    }
    public GameObject battery;
    private void ClearSafePuzzle()
    {
        battery.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
