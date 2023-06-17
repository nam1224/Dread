using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : MonoBehaviour
{
    public InputField inputField;
    public string password; //설정된 비밀번호

    private GameManager gm; //마우스 커서 풀기 위해

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
            Debug.Log("잠금 해제");
        }
        else
        {
            Debug.Log("다시");
        }
        OffSafePuzzle();
    }
}
