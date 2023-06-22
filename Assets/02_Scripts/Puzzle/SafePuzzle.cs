using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : MonoBehaviour
{
    public TextManager textmanager;

    public InputField inputField;
    public string password; //설정된 비밀번호

    public GameManager gm; //마우스 커서 풀기 위해

    public AudioSource audioSource;
    public AudioClip lockOffAudio; //잠금 해제 소리

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
            textmanager.Text("맞음", "");
            //Debug.Log("맞음");
            ClearSafePuzzle();
        }
        else
        {
            textmanager.Text("틀림", "");
            //Debug.Log("틀림");
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
