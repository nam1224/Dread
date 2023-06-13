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

    void Start()
    {
        mouseSlider.value = PlayerPrefs.GetFloat("MouseSensitivity");
        optionPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            optionPanel.SetActive(true);
        }

    }
    public void StartButton()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", mouseSlider.value);
        SceneManager.LoadScene("HospitalScene");
    }
    public void OptionButton()
    {
        optionPanel.SetActive(true);
    }
    public void Cancel()
    {
        optionPanel.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
