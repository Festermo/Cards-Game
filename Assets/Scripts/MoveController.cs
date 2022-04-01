using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private PlayerCard _playerCard;
    [SerializeField] private Field _field;
    [SerializeField] private Stats _stats;
    [SerializeField] private AnimationController _animationController;
    private bool _isMoving;

    #region Singleton

    public static MoveController Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void CheckIfNeighbour(SpawnedCard clickedCard) //check if clicked card is next to player card
    {
        if (clickedCard.X == _playerCard.X)
        {
            if (Mathf.Abs(clickedCard.Y - _playerCard.Y) == 1)
            { 
                DoStep(clickedCard);            
            }
        }
        else if (clickedCard.Y == _playerCard.Y)
        {
            if (Mathf.Abs(clickedCard.X - _playerCard.X) == 1)
            {
                DoStep(clickedCard);
            }
        }
    }

    private void DoStep(SpawnedCard clickedCard) //initializing new card on the place of player card and move 
    {
        if (!_isMoving)
        {
            Card createdCard = _field.CreateCard(_playerCard);
            _playerCard.SetPositionAndValue(clickedCard.X, clickedCard.Y, _playerCard.Value);
            _playerCard.GetCardValue(clickedCard);
            _playerCard.UpdateValueText();
            _stats.IncreaseScore();
            _isMoving = true;
            StartCoroutine(_animationController.StartAnimation(clickedCard, createdCard));
        }
    }

    public void MoveEnded()
    {
        _isMoving = false;
    }
}