using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
         [SerializeField] private GameObject MainMenuPanel;
         [SerializeField] private GameObject SettingsPanel;
    public void TestFunc()
    {
        Debug.Log("HELLO MADAFAKA");
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void SetResolution(int val)
    {
        switch (val)
        {
            case 0:
                Screen.SetResolution(1920, 1080, false);
                Debug.Log("1080");
                break;
            case 1:
                Screen.SetResolution(1280, 720, false);
                Debug.Log("720");

                break;
            case 2:
                Screen.SetResolution(640, 360, false);
                Debug.Log("360");

                break;

        }
    }
}
