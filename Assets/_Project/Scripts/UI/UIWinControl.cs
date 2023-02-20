using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BASE.UI;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIWinControl : BaseUIControl
{
    [SerializeField]
    private Button btnClamX2;
    [SerializeField]
    private Button btnGoHome;
    [SerializeField]
    private Button btnNext;
    [SerializeField]
    private Text coinText;
    private int coinReward;
    private void Start()
    {
        btnClamX2.onClick.AddListener(OnclickClamX2);
        btnGoHome.onClick.AddListener(OnclickGoHome);
        btnNext.onClick.AddListener(OnclickNext);
    }
    public override void Init(object[] prametter)
    {
        coinText.text = "+ 0";
        coinReward = (int)prametter[0];
        btnClamX2.gameObject.SetActive(true);
        //then coi
        DynamicData.Ins.Coin += coinReward;
        anim.OpenUIPopup(() =>
        {
            CanvaManager.Ins.isAnimRunning = false;
            AnimCoin(0);

        });
    }

    private void OnclickGoHome()
    {
        if (CanvaManager.Ins.isAnimRunning) return;
        GameManager.Ins.audioListener.enabled = true;

        CanvaManager.Ins.uIGamePlay.CloseTransitinImg();
        anim.CLoseUIPopup(() =>
        {
            CanvaManager.Ins.OpenUI(StaticData.HOME, new object[] { this });
            CanvaManager.Ins.isAnimRunning = false;
            Close();
        });
    }

    private void OnclickNext()
    {
        if (CanvaManager.Ins.isAnimRunning) return;
        anim.CLoseUIPopup(() =>
        {
            CanvaManager.Ins.isAnimRunning = false;
            DynamicData.Ins.CurrentLevel += 1;
            CanvaManager.Ins.uIGamePlay.CloseTransitinImg();
            Close();
            GameManager.Ins.CreatControl(DynamicData.Ins.CurrentLevel);
            CanvaManager.Ins.uIGamePlay.OpenTransitinImg();
        });
    }
    private void OnclickClamX2()
    {
        if (CanvaManager.Ins.isAnimRunning) return;
        btnClamX2.gameObject.SetActive(false);
        //then coin
        DynamicData.Ins.Coin += coinReward;
        coinReward = coinReward * 2;
        AnimCoin(coinReward / 2);
    }
    private void AnimCoin(int value)
    {
        CanvaManager.Ins.isAnimRunning = true;
        DOVirtual.Int(value, coinReward, 2f, (v) =>
        {

            coinText.text = "+ " + v.ToString();
        }).OnComplete(() =>
        {
            CanvaManager.Ins.isAnimRunning = false;

        });
    }
}
