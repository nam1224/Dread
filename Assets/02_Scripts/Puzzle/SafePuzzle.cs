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

    Flashlight flashlight;
    private void Start()
    {
        OffSafePuzzle();
        flashlight = GameObject.Find("Flashlight").GetComponent<Flashlight>();
    }

    public void OnSafePuzzle()
    {
        Time.timeScale = 0;
        inputField.gameObject.SetActive(true);
        gm.OffMouseLock();
    }
    public void OffSafePuzzle()
    {
        inputField.gameObject.SetActive(false);
        Time.timeScale = 1;
        gm.OnMouseLock();
    }

    public void ConfirmPassword()
    {
        if(password == inputField.text)
        {
            audioSource.PlayOneShot(lockOffAudio, 1.0f);
            textmanager.Text("����", "");
            //Debug.Log("����");
            ClearSafePuzzle();
        }
        else
        {
            textmanager.Text("Ʋ��", "");
            //Debug.Log("Ʋ��");
            Debug.Log(password);
        }
        inputField.text = "";
        OffSafePuzzle();
    }
    private void ClearSafePuzzle()
    {
        flashlight.ChargeEnergy();
    }
}
