using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad = "Game";
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private JSONController _jsonContoller;

    private void Awake()
    {
        _scoreText.text = "Max Score: " + _jsonContoller.LoadMaxScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}