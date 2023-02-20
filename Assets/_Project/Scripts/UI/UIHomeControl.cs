using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BASE.UI;
using UnityEngine.UI;
using System;

public class UIHomeControl : BaseUIControl
{
    [SerializeField]
    private Button btnSetting;
    [SerializeField]
    private Button btnLevel;
    [SerializeField]
    private Button btnShop;
    [SerializeField]
    private Button btnPlay;

    [SerializeField]
    private Text coinText;
    [SerializeField]
    private Text levelText;
    private void Start()
    {
        btnSetting.onClick.AddListener(OnclickSetting);
        btnLevel.onClick.AddListener(OnclickLevel);
        btnShop.onClick.AddListener(OnclickShop);
        btnPlay.onClick.AddListener(OnclickPlay);
    }
    public override void Init(object[] prametter)
    {
        GameManager.Ins.audioListener.enabled = true;
        coinText.text = DynamicData.Ins.Coin.ToString();
        levelText.text = DynamicData.Ins.OpenLevel.ToString();
        anim.OpenUIMenu(() =>
        {
            BaseUIControl pre = (BaseUIControl)prametter[0];
            CanvaManager.Ins.isAnimRunning = false;
            pre.Close();
        });
        if (DynamicData.Ins.Music)
            GameManager.Ins.bgMusic.Play();
        else
            GameManager.Ins.bgMusic.Stop();
    }

    private void OnclickLevel()
    {
        if (CanvaManager.Ins.isAnimRunning) return;

        Debug.Log("Level" + btnLevel.gameObject.name);
    }

    private void OnclickShop()
    {
        if (CanvaManager.Ins.isAnimRunning) return;

        CanvaManager.Ins.OpenUI(StaticData.SHOP, new object[] { this });
    }

    private void OnclickPlay()
    {
        if (CanvaManager.Ins.isAnimRunning) return;

        CanvaManager.Ins.OpenUI(StaticData.PLAY, new object[] { this });
    }

    private void OnclickSetting()
    {
        if (CanvaManager.Ins.isAnimRunning) return;
        CanvaManager.Ins.OpenUI(StaticData.SETTING, new object[] { });
    }
}
