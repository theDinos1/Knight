using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Characters");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void HowToPlay()
    {
        UIManager.Instance.SetHowToPlayOn();
        UIManager.Instance.SetMenuOff();
    }
    public void Setting()
    {
        UIManager.Instance.SetSettingOn();
        UIManager.Instance.SetMenuOff();
    }
}
