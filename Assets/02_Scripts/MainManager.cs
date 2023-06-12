using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject optionPanel;
    private void Start()
    {
        optionPanel.SetActive(false);
    }
    public void StartButton()
    {
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
