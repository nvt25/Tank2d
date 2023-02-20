using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BASE.UI;
using DG.Tweening;
public class UILoadingControl : BaseUIControl
{
    [SerializeField]
    private Image barFill;
    [SerializeField]
    private float timeLoading = 1.5f;
    public override void Init(object[] prametter)
    {
        barFill.fillAmount = 0f;
        StartCoroutine(WaitLoading());
    }
    IEnumerator WaitLoading()
    {
        yield return new WaitUntil(() => (DynamicData.Ins.isLoadedBase));
        DynamicData.Ins.loadDataPlayer?.Invoke();
        barFill.DOFillAmount(1f, timeLoading).OnComplete(() =>
        {
            CanvaManager.Ins.OpenUI(StaticData.HOME, new object[] {this});
        }).SetDelay(1f);
    }
    public override void Close()
    {
        base.Close();
    }
}
