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
        //if (talkPanel == false)
        {
            if (atribute == "Door")
            {
                talkPanel.SetActive(true);
                talkText.text = "���� ����ֽ��ϴ�.";
            }
        }
    }

    void Update()
    {
        
    }
}
