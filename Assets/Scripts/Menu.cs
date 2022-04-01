using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad = "Game";
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _scoreText.text = "Max Score: " + PlayerPrefs.GetInt("MaxScore").ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}