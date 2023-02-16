using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIChooseCharacter : MonoBehaviour
{
    [SerializeField] private Button _PlayButton;
    [SerializeField] private List<GameObject> _Characters;
    private int _Index = 0;
    private int _LastIndex;

    private void Start()
    {
        _LastIndex = _Index;
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Next()
    {
        if(_Index < _Characters.Count - 1)
        {
            _LastIndex = _Index;
            _Index++;
            OnIndexChange();
        }
    }


    public void Previous()
    {
        if (_Index > 0)
        {
            _LastIndex = _Index;
            _Index--;
            OnIndexChange();
        }
    }
    private void OnIndexChange()
    {
        _Characters[_Index].SetActive(true);
        _Characters[_LastIndex].SetActive(false);
        if(_Index == 2)
        {
            _PlayButton.interactable = true;
        }
        else
        {
            _PlayButton.interactable = false;
        }
    }

}
