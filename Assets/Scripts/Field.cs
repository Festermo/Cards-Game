using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Field : MonoBehaviour
{
    [Header("Field properties")]
    [SerializeField] private int _fieldSize = 3;
    [SerializeField] private float _spacing;
    [SerializeField] private Vector2 _cardSize;
    [Space(15)]
    [SerializeField] private RectTransform rectTransform;
    [Range(1, 10)]
    [SerializeField] private int _startPlayerValue = 3;
    [SerializeField] private Card _playerCard;
    [SerializeField] private Card[] _cardPrefabs; //dictionary is not visible in inspector
    private Vector2 _playerStartPosition; //not to spawn card in position of player
    private Dictionary<string, Card> _prefabsDictionary; //to find by tag

    private void Start()
    {
        _prefabsDictionary = new Dictionary<string, Card>() { 
            { "Red", _cardPrefabs[0] },
            { "Green", _cardPrefabs[1] } 
        };
        CreateField();
    }

    private void CreateField()
    {
        float fieldWidth = _fieldSize * (_cardSize.x + _spacing) + _spacing;
        float fieldHeight = _fieldSize * (_cardSize.y + _spacing) + _spacing;
        rectTransform.sizeDelta = new Vector2(fieldWidth, fieldHeight);
        float startX = -(fieldWidth / 2) + (_cardSize.x / 2) + _spacing;
        float startY = (fieldHeight / 2) - (_cardSize.y / 2) - _spacing;
        SetupPlayerCard(startX, startY);
        for (int x = 0; x < _fieldSize; x++)
        {
            for (int y = 0; y < _fieldSize; y++)
            {
                if (x == _playerStartPosition.x && y == _playerStartPosition.y) //not to spawn card in position of player
                {
                    continue;
                }
                Card card = Instantiate(ChooseCard(), transform);
                Vector2 position = new Vector2(startX + (x * (_cardSize.x + _spacing)), startY - (y * (_cardSize.y + _spacing)));
                card.transform.localPosition = position;
                card.SetPositionAndValue(x, y, GetRandomValue());
            }
        }
    }

    public Card CreateCard(Card oldCard)
    {
        Card newCard = Instantiate(ChooseCard(), transform);
        newCard.transform.localScale = Vector3.zero; //to start spawn animation properly
        newCard.transform.localPosition = oldCard.transform.localPosition;
        newCard.SetPositionAndValue(oldCard.X, oldCard.Y, GetRandomValue());
        return newCard;
    }

    private void SetupPlayerCard(float startX, float startY)
    {
        int randomX = Random.Range(0, _fieldSize);
        int randomY = Random.Range(0, _fieldSize);
        Vector2 Position = new Vector2(startX + (randomX * (_cardSize.x + _spacing)), startY - (randomY * (_cardSize.y + _spacing)));
        _playerCard.gameObject.SetActive(true);
        _playerCard.transform.localPosition = Position;
        _playerStartPosition = new Vector2(randomX, randomY);
        _playerCard.SetPositionAndValue(randomX, randomY, _startPlayerValue);
    }
    
    private Card ChooseCard()
    {
        Card randomCard;
        float currentChance = 0.1f * Stats.Level;
        if (currentChance > 0.5f) //chance of spawning red card can't be more than 50%
            currentChance = 0.5f;
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber < currentChance)
            randomCard =_prefabsDictionary["Red"];
        else
            randomCard = _prefabsDictionary["Green"];
        return randomCard;
    }

    private int GetRandomValue()
    {
        int randomValue = Random.Range(0, Stats.Level);
        return randomValue + 1;
    }
}