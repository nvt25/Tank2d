using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BASE.UI;
using DG.Tweening;
using System;

public class UIGamePlay : BaseUIControl
{
    [SerializeField]
    private Image sliderBar;
    [SerializeField]
    private Image imgMask;
    public Image barHP;
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private Button btnBack;
    private void Start()
    {
        btnBack.onClick.AddListener(BackOnclick);
    }

    private void BackOnclick()
    {
        if (CanvaManager.Ins.isAnimRunning) return;
        GameManager.Ins.audioListener.enabled = true;
        CloseTransitinImg();
        Debug.Log("haell");
        CanvaManager.Ins.OpenUI(StaticData.HOME, new object[] { this });
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        Close();
    }
    public override void Init(object[] prametter)
    {
        GameManager.Ins.player.img = barHP;

        imgMask.gameObject.SetActive(true);
        GameManager.Ins.getJoystick = joystick;
        CanvaManager.Ins.SlideBarHeaty = SetBarHearty;
        CanvaManager.Ins.uIGamePlay = this;
        GameManager.Ins.CreatControl(DynamicData.Ins.CurrentLevel);
        anim.OpenUIMenu(() =>
        {
            transform.localPosition = Vector3.zero;
            BaseUIControl pre = (BaseUIControl)prametter[0];
            OpenTransitinImg();
            CanvaManager.Ins.isAnimRunning = false;
            pre.Close();
        });
    }
    private void SetBarHearty(float percentHP)
    {
        sliderBar.fillAmount = percentHP;
    }
    public void OpenTransitinImg()
    {
        GameManager.Ins.player.gameObject.SetActive(true);
        GameManager.Ins.player.setBody(DynamicData.Ins.selectedId.CodeID);
        imgMask.DOFade(0f, 2f).OnComplete(() =>
        {
            imgMask.gameObject.SetActive(false);
        });
    }
    public void CloseTransitinImg()
    {
        GameManager.Ins.player.gameObject.SetActive(false);
        imgMask.gameObject.SetActive(true);
        imgMask.color = new Color(1, 1, 1, 1);

    }
}
