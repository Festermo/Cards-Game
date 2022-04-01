using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _valueText;
    public int Value { get; protected set; }
    public int X { get; protected set; }
    public int Y { get; protected set; }

    private void Start()
    {
        _valueText.text = Value.ToString();
    }

    public void SetPositionAndValue(int x, int y, int value)
    {
        X = x;
        Y = y;
        Value = value;
    }
}