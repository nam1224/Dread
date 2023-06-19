using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    // ���� �� �ѱ��, ���� ����,���� ���� ������ ����ϴ� ��ũ��Ʈ �ڼ��� ������ ������ ���� �ֱ�ٶ�

    public Slider soundSlider;  //���� ����
    public Slider mouseSlider;  //���� ����
    public GameObject optionPanel;  
    public float maxTime;   //�����÷��� �ð�
    public Text timeText;   //0�ú��� 6�ñ���
    public AudioMixer audioMixer;
    public AudioSource audioSource;
    public AudioClip soundClip;
    public GameObject diePanel;


    private bool m_cursorIsLocked = false;
    public float timer = 1f;
    private float interval = 1f;

    public void Volume()
    {
        audioMixer.SetFloat("Sound", Mathf.Log10(soundSlider.value) * 20);
    }
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
        diePanel.SetActive(false);
        soundSlider.value = PlayerPrefs.GetFloat("Sound");
        mouseSlider.value = PlayerPrefs.GetFloat("MouseSensitivity");   //���콺 ���� ��������

        if (SceneManager.GetActiveScene().name == "MainScene")  //ó�� ������ �� �ɼ��г� ����
        {
            optionPanel.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            OnMouseLock();
        }

        while (true)
        {
            yield return new WaitForSeconds(interval);  // 1�ʸ� ��ٸ��� WaitForSeconds ��ü ����

            if (timer == 0) //0��
            {
                timeText.text = "0:00";
            }
            else if (timer == maxTime / 6) //1��
            {
                Debug.Log("1��");
                timeText.text = "1:00";
                audioSource.PlayOneShot(soundClip);
            }
            else if (timer == maxTime / 6*2)  //2��
            {
                timeText.text = "2:00";
                audioSource.PlayOneShot(soundClip);
            }
            else if (timer == maxTime / 6*3)  //3��
            {
                timeText.text = "3:00";
                audioSource.PlayOneShot(soundClip);
            }
            else if (timer == maxTime / 6*4)  //4��
            {
                timeText.text = "4:00";
                audioSource.PlayOneShot(soundClip);
            }
            else if (timer == maxTime / 6*5)  //5��
            {
                timeText.text = "5:00";
                audioSource.PlayOneShot(soundClip);
            }
            else if (timer == maxTime)  //6��(Ŭ����)
            {
                timeText.text = "6:00";
                Clear();
                break;
            }

            timer += 1f;
        }
    }

    void Update()
    {
        Volume();
        LockCursor();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OptionButton();
        }
        if (optionPanel)
        {
            PlayerPrefs.SetFloat("MouseSensitivity", mouseSlider.value); //���� �����ͼ� �����̴��� ǥ��
            PlayerPrefs.SetFloat("Sound", soundSlider.value);
        }
    }

    public void StartButton()   //���۹�ư(������ ���������� �̵�)
    {
        SceneManager.LoadScene("HospitalScene");
        OnMouseLock();
    }
    public void OptionButton()  //�ɼ��г� Ȱ��ȭ
    {
        optionPanel.SetActive(true);
        OffMouseLock();
    }
    public void ReStartButton()   //���۹�ư(������ ���������� �̵�)
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Die()
    {
        diePanel.SetActive(true);
        OffMouseLock();
    }
    public void Clear()
    {

    }
    public void PanelOff()    //�ɼ��г� ����
    {
        optionPanel.SetActive(false);
        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            OnMouseLock();
        }
    }

    //@�ο�
    //���콺 ��� ����
    public void OffMouseLock()
    {
        m_cursorIsLocked = false;
    }

    //���콺 ���
    public void OnMouseLock()
    {
        m_cursorIsLocked = true;
    }

    public void ExitButton()    //���Ӳ���
    {
        Application.Quit();
    }
}
