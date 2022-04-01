using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad = "Game";
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _levelText;

    private void Awake()
    {
        _scoreText.text = "Score: " + Stats.Score.ToString();
        _levelText.text = "Level: " + Stats.Level.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}