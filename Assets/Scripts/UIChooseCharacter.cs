using UnityEngine;
using UnityEngine.SceneManagement;

public class UIChooseCharacter : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

}
