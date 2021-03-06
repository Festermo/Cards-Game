using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private JSONController _jsonController;
    public static int Score { get; private set; }
    public static int Level { get; private set; }

    private void Start()
    {
        Score = 0;
        Level = 1;
    }

    public void IncreaseScore()
    {
        Score++;
        if (Score % 10 == 0)
        {
            IncreaseLevel();
        }
        UpdateScore();
    }

    private void IncreaseLevel()
    {
        Level++;
        UpdateLevel();
    }

    private void UpdateScore()
    {
        _scoreText.text = "Score: " + Score.ToString();
    }

    private void UpdateLevel()
    {
        _levelText.text = "Level: " + Level.ToString();
    }

    public void CheckMaxScore()
    {
        if (Score > _jsonController.LoadMaxScore())
        {
            StructToRemember structToRemember = new StructToRemember { MaxScore = Score };
            _jsonController.SaveMaxScore(structToRemember);
        }
    }
}