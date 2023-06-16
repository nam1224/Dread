using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���� �� �ѱ��, ���� ����,���� ���� ������ ����ϴ� ��ũ��Ʈ �ڼ��� ������ ������ ���� �ֱ�ٶ�

    public Slider soundSlider;
    public Slider mouseSlider;
    public GameObject optionPanel;
    public float maxTime;
    public Text timeText;
    public Sound sound;


    private bool m_cursorIsLocked = false;
    public float timer = 0f;
    private float interval = 1f;

    private void LockCursor()
    {

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
             Cursor.lockState = CursorLockMode.None;
             Cursor.visible = true;
        }

    }
    private IEnumerator Start()
    {
        mouseSlider.value = PlayerPrefs.GetFloat("MouseSensitivity");

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            optionPanel.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            m_cursorIsLocked = true;
        }

        while (true)
        {
            yield return new WaitForSeconds(interval);  // 1�ʸ� ��ٸ��� WaitForSeconds ��ü ����

            timer += 1f;

            if (timer == 0) //0��
            {
                timeText.text = "0:00";
            }
            else if (timer == maxTime / 6) //1��
            {
                Debug.Log("1��");
                timeText.text = "1:00";
                sound.PlaySound();
            }
            else if (timer == maxTime / 5)  //2��
            {
                timeText.text = "2:00";
                sound.PlaySound();
            }
            else if (timer == maxTime / 4)  //3��
            {
                timeText.text = "3:00";
                sound.PlaySound();
            }
            else if (timer == maxTime / 3)  //4��
            {
                timeText.text = "4:00";
                sound.PlaySound();
            }
            else if (timer == maxTime / 2)  //5��
            {
                timeText.text = "5:00";
                sound.PlaySound();
            }
            else if (timer == maxTime)  //6��(Ŭ����)
            {
                timeText.text = "6:00";
                sound.PlaySound();
            }
        }

    }

    void Update()
    {
        LockCursor();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OptionButton();
        }
        if (optionPanel)
        {
            PlayerPrefs.SetFloat("MouseSensitivity", mouseSlider.value);
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene("HospitalScene");
        m_cursorIsLocked = true;
    }
    public void OptionButton()
    {
        optionPanel.SetActive(true);
        m_cursorIsLocked = false;
    }
    public void Cancel()
    {
        optionPanel.SetActive(false);
        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            m_cursorIsLocked = true;
        }
      
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
