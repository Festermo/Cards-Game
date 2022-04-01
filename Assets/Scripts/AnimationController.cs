using System.Collections;
using UnityEngine;
using DG.Tweening;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private MoveController _moveContoller;
    [SerializeField] private float _animationTime = 0.1f;
    [SerializeField] private Card _playerCard;

    public IEnumerator StartAnimation(SpawnedCard clickedCard, Card createdCard)
    {
        yield return StartCoroutine(DestroyAnimation(clickedCard));
        Destroy(clickedCard.gameObject);
        yield return StartCoroutine(MoveAnimation(clickedCard));
        yield return StartCoroutine(SpawnAnimation(createdCard));
        _moveContoller.MoveEnded();
        yield return null;
    }

    private IEnumerator DestroyAnimation(SpawnedCard clickedCard)
    {
        clickedCard.transform.DOScale(0, _animationTime);
        yield return new WaitForSeconds(_animationTime);
    }

    private IEnumerator MoveAnimation(SpawnedCard clickedCard)
    {
        _playerCard.transform.DOLocalMove(clickedCard.transform.localPosition, _animationTime);
        yield return new WaitForSeconds(_animationTime);
    }

    private IEnumerator SpawnAnimation(Card createdCard)
    {
        createdCard.transform.DOScale(1, _animationTime);
        yield return new WaitForSeconds(_animationTime);
    }
}