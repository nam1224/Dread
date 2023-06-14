using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Slider soundSlider;
    public Slider mouseSlider;
    public GameObject optionPanel;
    
    private bool m_cursorIsLocked = false;

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
    void Start()
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
