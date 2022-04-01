using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private Stats _stats;
    [SerializeField] private string _levelToLoad = "GameOver";

    public void EndGame()
    {
        _stats.CheckMaxScore(); //to change MaxScore if current is higher
        SceneManager.LoadScene(_levelToLoad);
    }
}