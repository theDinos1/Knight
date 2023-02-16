using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _Win;
    [SerializeField] private GameObject _GameOver;
    [SerializeField] private TMP_Text _ScoreText;
    [SerializeField] private TMP_Text _TotalText;
    public static UIGameManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SetUpScore(int score)
    {
        _ScoreText.text = score.ToString();
    }
    public void GameOver()
    {
        _GameOver.SetActive(true);
    }
    public void Win()
    {
        _TotalText.text = $"Total score {_ScoreText.text}";
        _Win.SetActive(true);
    }
    public void Back()
    {
        PlayerController.ResetScore();
        SceneManager.LoadScene("Menu");
        Destroy(gameObject);
    }
    public void Retry()
    {
        PlayerController.ResetScore();
        SceneManager.LoadScene("Game");
        _GameOver.SetActive(false);
        
    }
}
