using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject upgradeMenu;

    private void Start()
    {
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Arena");
    }

    public void SettingsButton()
    {
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void UpgradeButton()
    {
        upgradeMenu.SetActive(true);
    }
    public void CloseUpgrade()
    {
        upgradeMenu.SetActive(false);
    }
}
