using BASE.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UILoseControl : BaseUIControl
{
    [SerializeField]
    private Button rePlay;

    [SerializeField]
    private Button goHome;

    [SerializeField]
    private Text coinText;

    private int coinReward;

    private void Start()
    {
        rePlay.onClick.AddListener(OnclickReplay);
        goHome.onClick.AddListener(OnclickGoHome);
    }

    public override void Init(object[] prametter)
    {
        coinReward = (int)prametter[0];
        DynamicData.Ins.Coin += coinReward;
        coinText.text = "+ 0";
        anim.OpenUIPopup(() =>
        {
            CanvaManager.Ins.isAnimRunning = false;
            DOVirtual.Int(0, coinReward, 2f, (v) => coinText.text = "+ " + v.ToString());
        });
    }

    private void OnclickReplay()
    {
        if (CanvaManager.Ins.isAnimRunning) return;
        anim.CLoseUIPopup(() =>
        {
            CanvaManager.Ins.isAnimRunning = false;
            CanvaManager.Ins.uIGamePlay.CloseTransitinImg();
            Close();
            GameManager.Ins.CreatControl(DynamicData.Ins.CurrentLevel);
            CanvaManager.Ins.uIGamePlay.OpenTransitinImg();
        });
    }

    private void OnclickGoHome()
    {
        if (CanvaManager.Ins.isAnimRunning) return;
        CanvaManager.Ins.uIGamePlay.CloseTransitinImg();
        anim.CLoseUIPopup(() =>
        {
            CanvaManager.Ins.OpenUI(StaticData.HOME, new object[] { this });
            CanvaManager.Ins.isAnimRunning = false;
            Close();
        });
    }
}