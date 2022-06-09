using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR;
public class MainMenuScript : MonoBehaviour
{
         [SerializeField] private GameObject MainMenuPanel;
         [SerializeField] private GameObject SettingsPanel;
         [SerializeField] private GameObject PausePanel;
         [SerializeField] private GameObject HUDPanel;
         [SerializeField] private TMPro.TextMeshProUGUI KillValue;

    public int killcounter = 0;
    public bool fullscreen;
    private bool isPause = false;
    private void Awake()
    {
    }
    private void Update()
    {
        KillValue.text = killcounter.ToString();
        //if(false)
        //{
        //    if (isPause)
        //    {
        //        Resume();
        //    }
        //    else
        //    {
        //        Pause();
        //    }
        //}

    }
    public void TestFunc()
    {
        Debug.Log("HELLO MADAFAKA");
    }

    public void Play()
    {
        HUDPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        HUDPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    public void CloseSettings()
    {
        HUDPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        if(isPause)
        {
            MainMenuPanel.SetActive(false);
            PausePanel.SetActive(true);
        }
        else
        {
            MainMenuPanel.SetActive(true);
            PausePanel.SetActive(false);
        }
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        isPause = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        isPause = true;
    }
}
