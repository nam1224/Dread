using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    // ���ӿ��� ��� ������ �̳� ��ȣ�ۿ��� �Ҷ� � ���� �߻��ߴ��� �����ϴ� �ؽ�Ʈ�� UI�� �ð�ȭ �ڼ��� �ڵ� ������ ������ ����ֱ�ٶ�.

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
                talkText.text = "���� ����ִ�.";
                talkPanel.SetActive(true);         
                StartCoroutine(CallFunctionWithDelay());
            }
            else if(atribute == "GetKey")
            {
                talkText.text = keyName +" ���踦 �����.";
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
