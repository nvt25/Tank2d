using BASE.UI;
using DG.Tweening;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    [SerializeField]
    private RectTransform box;

    public void OpenUIPopup(TweenCallback callBack, float delay = 0f)
    {
        CanvaManager.Ins.isAnimRunning = true;
        box.localScale = Vector3.zero;
        box.DOScale(1f, 1f).SetEase(Ease.OutBack).SetDelay(delay).OnComplete(callBack);
    }

    public void CLoseUIPopup(TweenCallback callBack, float delay = 0f)
    {
        CanvaManager.Ins.isAnimRunning = true;
        box.DOScale(0f, 1f).SetEase(Ease.OutBack).SetDelay(delay).OnComplete(callBack);
    }

    public void OpenUIMenu(TweenCallback callBack, float delay = 0f)
    {
        CanvaManager.Ins.isAnimRunning = true;
        Vector3 lotication = transform.parent.position;
        box.position = lotication - new Vector3(5f, 0f, 0f);
        box.DOMove(lotication, 1f).SetEase(Ease.OutBack).SetDelay(delay).OnComplete(callBack);
    }
}