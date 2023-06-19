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
        talkPanel.SetActive(false);     //������ �� �ɼ��г� ���� ����
    }
    public void Text(string atribute,string talk)    //� �༮���� atribute�� Ȯ��, keyName���� � ���踦 �Ծ����� �߰�
    {
        if (talkPanel.activeSelf == false)
        {
            if (atribute == "Locked")
            {
                talkText.text = "���� ����ִ�.";
                talkPanel.SetActive(true);         
                StartCoroutine(CallFunctionWithDelay(1.5f));    //1.5���� ������� �Լ��� ȣ��
            }
            else if(atribute == "GetKey")
            {
                talkText.text = talk +" ���踦 �����.";
                talkPanel.SetActive(true);
                StartCoroutine(CallFunctionWithDelay(1.5f));
            }
            else if(atribute == "����")
            {
                talkText.text = "Ǯ����.";
                talkPanel.SetActive(true);
                StartCoroutine(CallFunctionWithDelay(1.5f));
            }
            else if(atribute == "Ʋ��")
            {
                talkText.text = "Ʋ�� �� ����.";
                talkPanel.SetActive(true);
                StartCoroutine(CallFunctionWithDelay(1.5f));
            }
            else if (atribute == "����")
            {
                talkText.text = talk;
                talkPanel.SetActive(true);
                StartCoroutine(CallFunctionWithDelay(3));
            }
        }
    }
    IEnumerator CallFunctionWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);      //1.5�ʵ� �ؽ�Ʈ ����
        DeleteText();
    }
    public void DeleteText()    //�ؽ�Ʈ ����
    {
        talkPanel.SetActive(false);
    }

    void Update()
    {
        
    }
}
