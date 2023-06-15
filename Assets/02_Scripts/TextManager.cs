using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    // 게임에서 얻는 아이템 이나 상호작용을 할때 어떤 일이 발생했는지 설명하는 텍스트를 UI로 시각화 자세한 코드 설명은 우준혁 내용넣기바람.

    public GameObject talkPanel;
    public Text talkText;
    void Start()
    {
        talkPanel.SetActive(false);
    }
    public void Text(string atribute,string keyName)
    {
        if (talkPanel.activeSelf == false)
        {
            if (atribute == "Locked")
            {
                talkText.text = "문이 잠겨있다.";
                talkPanel.SetActive(true);         
                StartCoroutine(CallFunctionWithDelay());
            }
            else if(atribute == "GetKey")
            {
                talkText.text = keyName +" 열쇠를 얻었다.";
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
