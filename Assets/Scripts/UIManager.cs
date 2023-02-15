using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject _Menu;
    [SerializeField] private GameObject _Setting;
    [SerializeField] private GameObject _HowToPlay;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void SetMenuOn()
    {
        _Menu.SetActive(true);
    }
    public void SetMenuOff()
    {
        _Menu.SetActive(false);
    }
    public void SetSettingOn()
    {
        _Setting.SetActive(true);
    }
    public void SetSettingOff()
    {
        _Setting.SetActive(false);
    }public void SetHowToPlayOn()
    {
        _HowToPlay.SetActive(true);
    }
    public void SetHowToPlayOff()
    {
        _HowToPlay.SetActive(false);
    }

}
