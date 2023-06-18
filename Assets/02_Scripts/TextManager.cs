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
        talkPanel.SetActive(false);     //시작할 때 옵션패널 끄고 시작
    }
    public void Text(string atribute,string keyName)    //어떤 녀석인지 atribute로 확인, keyName으로 어떤 열쇠를 먹었는지 추가
    {
        if (talkPanel.activeSelf == false)
        {
            if (atribute == "Locked")
            {
                talkText.text = "문이 잠겨있다.";
                talkPanel.SetActive(true);         
                StartCoroutine(CallFunctionWithDelay());    //1.5초후 사라지는 함수를 호출
            }
            else if(atribute == "GetKey")
            {
                talkText.text = keyName +" 열쇠를 얻었다.";
                talkPanel.SetActive(true);
                StartCoroutine(CallFunctionWithDelay());
            }
            else if(atribute == "맞음")
            {
                talkText.text = "풀었다.";
                talkPanel.SetActive(true);
                StartCoroutine(CallFunctionWithDelay());
            }
            else if(atribute == "틀림")
            {
                talkText.text = "틀린 거 같다.";
                talkPanel.SetActive(true);
                StartCoroutine(CallFunctionWithDelay());
            }
        }
    }
    IEnumerator CallFunctionWithDelay()
    {
        yield return new WaitForSeconds(1.5f);      //1.5초뒤 텍스트 삭제
        DeleteText();
    }
    public void DeleteText()    //텍스트 삭제
    {
        talkPanel.SetActive(false);
    }

    void Update()
    {
        
    }
}
