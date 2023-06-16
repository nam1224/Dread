using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임 신 넘기기, 게임 실행,게임 세팅 설정을 담당하는 스크립트 자세한 내용은 우준혁 내용 넣기바람

    public Slider soundSlider;  //사운드 조절
    public Slider mouseSlider;  //감도 조절
    public GameObject optionPanel;  
    public float maxTime;   //게임플레이 시간
    public Text timeText;   //0시부터 6시까지
    public Sound sound;     //사운드 가져오기


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
        mouseSlider.value = PlayerPrefs.GetFloat("MouseSensitivity");   //마우스 감도 가져오기

        if (SceneManager.GetActiveScene().name == "MainScene")  //처음 시작할 때 옵션패널 끄기
        {
            optionPanel.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            m_cursorIsLocked = true;
        }

        while (true)
        {
            yield return new WaitForSeconds(interval);  // 1초를 기다리는 WaitForSeconds 객체 생성

            timer += 1f;

            if (timer == 0) //0시
            {
                timeText.text = "0:00";
            }
            else if (timer == maxTime / 6) //1시
            {
                Debug.Log("1시");
                timeText.text = "1:00";
                sound.PlaySound();
            }
            else if (timer == maxTime / 5)  //2시
            {
                timeText.text = "2:00";
                sound.PlaySound();
            }
            else if (timer == maxTime / 4)  //3시
            {
                timeText.text = "3:00";
                sound.PlaySound();
            }
            else if (timer == maxTime / 3)  //4시
            {
                timeText.text = "4:00";
                sound.PlaySound();
            }
            else if (timer == maxTime / 2)  //5시
            {
                timeText.text = "5:00";
                sound.PlaySound();
            }
            else if (timer == maxTime)  //6시(클리어)
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
            PlayerPrefs.SetFloat("MouseSensitivity", mouseSlider.value); //감도 가져와서 슬라이더에 표시
        }
    }

    public void StartButton()   //시작버튼(누르면 병원씬으로 이동)
    {
        SceneManager.LoadScene("HospitalScene");
        m_cursorIsLocked = true;
    }
    public void OptionButton()  //옵션패널 활성화
    {
        optionPanel.SetActive(true);
        m_cursorIsLocked = false;
    }
    public void Cancel()    //옵션패널 끄기
    {
        optionPanel.SetActive(false);
        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            m_cursorIsLocked = true;
        }
      
    }
    public void ExitButton()    //게임끄기
    {
        Application.Quit();
    }
}
