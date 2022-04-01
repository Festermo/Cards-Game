using UnityEngine;

public class PlayerCard : Card
{
    [SerializeField] private Stats _stats;
    [SerializeField] private GameEnder _gameEnder;

    public void GetCardValue(SpawnedCard card)
    {
        if (card.tag == "Green")
            Value += card.Value;
        else if (card.tag == "Red")
            Value -= card.Value;
        if (Value <= 0)
        {
            _gameEnder.EndGame();
        }
    }

    public void UpdateValueText()
    {
        _valueText.text = Value.ToString();
    }
}