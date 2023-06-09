using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    void Start()
    {
        talkPanel.SetActive(false);
    }
    public void Text(string atribute)
    {
        if (talkPanel.activeSelf == false)
        {
            if (atribute == "Locked")
            {
                talkText.text = "문이 잠겨있습니다.";
                talkPanel.SetActive(true);         
                StartCoroutine(CallFunctionWithDelay());
            }
        }
    }
    IEnumerator CallFunctionWithDelay()
    {
        yield return new WaitForSeconds(1.5f);
        DeleteText();
    }
    public void DeleteText()
    {
        talkPanel.SetActive(false);
    }

    void Update()
    {
        
    }
}
