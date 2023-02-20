using UnityEngine;
using DG.Tweening;
using BASE.UI;
public class PassLevel : MonoBehaviour
{
    [SerializeField]
    private Transform pass;
    private Tween tween;
    private void Start()
    {
        SpriteRenderer img = pass.GetComponent<SpriteRenderer>();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(img.DOFade(1f, 0.4f).SetEase(Ease.Linear));
        sequence.Append(pass.DOLocalMoveY(0.4f, 0.4f).SetEase(Ease.Linear));
        sequence.Append(img.DOFade(0f, 0.4f).SetEase(Ease.Linear));
        sequence.SetLoops(-1, LoopType.Restart);
        tween = sequence;
    }
    private void OnDisable()
    {
        tween.Kill();
    }
    private void OnDestroy()
    {
        tween.Kill();
    }
}