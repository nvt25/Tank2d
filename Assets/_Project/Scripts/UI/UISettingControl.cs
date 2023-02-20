using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BASE.UI;
using System;

public class UISettingControl : BaseUIControl
{
    [SerializeField]
    private Button btnClose;
    [SerializeField]
    private Button btnGoHome;
    [SerializeField]
    private Button btnMusic;
    [SerializeField]
    private Button btnVibrate;
    [SerializeField]
    private Button btnRate;
    //
    [SerializeField]
    private Image iconMusic;
    [SerializeField]
    private Image iconTurnMusic;
    [SerializeField]
    private Image iconVibrate;
    [SerializeField]
    private Image iconTurnVibrate;
    //
    [SerializeField]
    private List<Sprite> iconOnOffs;
    [SerializeField]
    private List<Sprite> iconTurnVibrates;
    [SerializeField]
    private List<Sprite> iconTurnMusics;
    private bool isVibrate;
    private bool isMusic;
    private void Start()
    {
        btnClose.onClick.AddListener(OnclickClose);
        btnGoHome.onClick.AddListener(OnclickGoHome);
        btnMusic.onClick.AddListener(OnclickMusic);
        btnVibrate.onClick.AddListener(OnclickVibrate);
        btnRate.onClick.AddListener(OnclickRate);
    }
    public override void Init(object[] prametter)
    {
        anim.OpenUIPopup(() =>
        {
            CanvaManager.Ins.isAnimRunning = false;
        });
        isMusic = DynamicData.Ins.Music;
        isVibrate = DynamicData.Ins.Vibrate;
        ShowStatusMusic();
        ShowStatusVibrate();
    }

    private void OnclickRate()
    {
        if (CanvaManager.Ins.isAnimRunning) return;

        Application.OpenURL("https://play.google.com/store/apps/developer?id=EraN+Tuyen+Van+Nguyen");
    }

    private void OnclickVibrate()
    {

        if (CanvaManager.Ins.isAnimRunning) return;

        isVibrate = !isVibrate;
        DynamicData.Ins.Vibrate = isVibrate;
        ShowStatusVibrate();
    }

    private void OnclickMusic()
    {
        if (CanvaManager.Ins.isAnimRunning) return;

        isMusic = !isMusic;
        DynamicData.Ins.Music = isMusic;
        ShowStatusMusic();
        if (isMusic)
            GameManager.Ins.bgMusic.Play();
        else
            GameManager.Ins.bgMusic.Stop();
    }

    private void OnclickGoHome()
    {
        if (CanvaManager.Ins.isAnimRunning) return;

        anim.CLoseUIPopup(() =>
        {
            CanvaManager.Ins.isAnimRunning = false;

            Close();
        });
    }

    private void OnclickClose()
    {
        if (CanvaManager.Ins.isAnimRunning) return;

        anim.CLoseUIPopup(() =>
        {
            CanvaManager.Ins.isAnimRunning = false;

            Close();
        });
    }

    public override void Close()
    {
        base.Close();
    }
    private void ShowStatusMusic()
    {
        if (isMusic)
        {
            iconMusic.sprite = iconTurnMusics[1];
            iconTurnMusic.sprite = iconOnOffs[1];
        }
        else
        {
            iconMusic.sprite = iconTurnMusics[0];
            iconTurnMusic.sprite = iconOnOffs[0];
        }
    }
    private void ShowStatusVibrate()
    {
        if (isVibrate)
        {
            iconVibrate.sprite = iconTurnVibrates[1];
            iconTurnVibrate.sprite = iconOnOffs[1];
        }
        else
        {
            iconVibrate.sprite = iconTurnVibrates[0];
            iconTurnVibrate.sprite = iconOnOffs[0];
        }
    }
}
