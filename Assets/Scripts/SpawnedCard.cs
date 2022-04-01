using UnityEngine;

public class SpawnedCard : Card
{
    [SerializeField] private string _tag;
    public string tag => _tag;
    private MoveController _moveController;

    private void Start()
    {
        _moveController = MoveController.Instance;
        _valueText.text = Value.ToString();
    }

    public void SendPosition() //to send this card position to MoveContoller on click
    {
        _moveController.CheckIfNeighbour(this);
    }
}