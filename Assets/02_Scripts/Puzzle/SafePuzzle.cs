using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : MonoBehaviour
{
    public InputField inputField;
    public string password; //설정된 비밀번호

    public GameManager gm; //마우스 커서 풀기 위해

    public AudioSource audioSource;
    public AudioClip lockOffAudio; //잠금 해제 소리
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
            Debug.Log("잠금 해제");
            audioSource.PlayOneShot(lockOffAudio, 1.0f);
        }
        else
        {
            Debug.Log("다시");
        }
        OffSafePuzzle();
    }
}
