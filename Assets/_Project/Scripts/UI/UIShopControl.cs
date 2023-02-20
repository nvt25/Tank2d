using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BASE.UI;
using DG.Tweening;
public class UIShopControl : BaseUIControl
{
    [SerializeField]
    private Button btnBack;
    [SerializeField]
    private Button btnBuy;
    [SerializeField]
    private Button btnUse;
    [SerializeField]
    private UIItemInShop itemShopPrefab;
    [SerializeField]
    private RectTransform boxShowItem;
    [SerializeField]
    private Text coinText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Animator animMode;
    private PlayerMode selectItem;
    private void Start()
    {
        btnBack.onClick.AddListener(OnclickBack);
        btnBuy.onClick.AddListener(OnclickBuy);
        btnUse.onClick.AddListener(OnclickUse);
    }
    public override void Init(object[] prametter)
    {
        BaseUIControl pre = (BaseUIControl)prametter[0];
        selectItem = DynamicData.Ins.selectedId;
        animMode.gameObject.SetActive(true);
        animMode.SetFloat("IdTank", (selectItem.CodeID - 1) * 0.125f);
        LoadItem();
        LoadStatus();
        anim.OpenUIMenu(() =>
        {
            AnimRotate();
            CanvaManager.Ins.isAnimRunning = false;

            pre.Close();
        });
    }

    private void OnclickUse()
    {

        foreach (PlayerMode mode in DynamicData.Ins.listModelPlayer)
        {
            if (mode.Status == 2)
            {
                DynamicData.Ins.SetStatusMode(mode.NameModel + mode.CodeID, 1);
                mode.Status = 1;
            }
        }
        DynamicData.Ins.SetStatusMode(selectItem.NameModel + selectItem.CodeID, 2);
        selectItem.Status = 2;
        DynamicData.Ins.selectedId = selectItem;
        LoadStatus();

    }

    private void OnclickBuy()
    {

        if (DynamicData.Ins.Coin >= selectItem.PriceCoint)
        {
            foreach (PlayerMode mode in DynamicData.Ins.listModelPlayer)
            {
                if (mode.Status == 2)
                {
                    DynamicData.Ins.SetStatusMode(mode.NameModel + mode.CodeID, 1);
                    mode.Status = 1;
                }
            }
            DynamicData.Ins.SetStatusMode(selectItem.NameModel + selectItem.CodeID, 2);
            selectItem.Status = 2;
            DynamicData.Ins.selectedId = selectItem;
            DynamicData.Ins.Coin -= selectItem.PriceCoint;
            LoadItem();
            LoadStatus();
        }
    }

    public void SelectItem(PlayerMode item)
    {
        selectItem = item;
        animMode.SetFloat("IdTank", (selectItem.CodeID - 1) * 0.125f);
        LoadStatus();
    }
    private void OnclickBack()
    {
        if (CanvaManager.Ins.isAnimRunning) return;

        CanvaManager.Ins.OpenUI(StaticData.HOME, new object[] { this });
        animMode.gameObject.SetActive(false);

    }
    public override void Close()
    {
        base.Close();
    }
    public void LoadStatus()
    {
        nameText.text = selectItem.NameModel;

        switch (selectItem.Status)
        {
            case 0:
                btnBuy.gameObject.SetActive(true);
                btnUse.gameObject.SetActive(false);
                if (DynamicData.Ins.Coin >= selectItem.PriceCoint)
                {
                    btnBuy.interactable = true;
                }
                else
                {
                    btnBuy.interactable = false;
                }
                break;
            case 1:
                btnBuy.gameObject.SetActive(false);
                btnUse.gameObject.SetActive(true);
                break;
            case 2:
                btnBuy.gameObject.SetActive(false);
                btnUse.gameObject.SetActive(false);
                break;
        }
    }
    public void LoadItem()
    {
        coinText.text = DynamicData.Ins.Coin.ToString();
        var childs = boxShowItem.GetComponentsInChildren<Transform>();
        if (childs.Length > 0)
        {
            foreach (var child in childs)
            {
                if (child.gameObject.CompareTag("ItemShop"))
                {
                    Destroy(child.gameObject);
                }
            }
        }
        foreach (PlayerMode mode in DynamicData.Ins.listModelPlayer)
        {
            UIItemInShop temp = Instantiate(itemShopPrefab, boxShowItem);
            temp.Init(new object[] { mode, this });
        }
    }
    //Anim
    public void AnimRotate()
    {
        Vector3 tempVT = new Vector3(0f, 0f, Random.Range(0, 360));
        animMode.transform.DOLocalRotate(tempVT, 5f).SetDelay(3f).OnComplete(() =>
        {
            DOTween.Kill(gameObject);
            AnimRotate();
        });
    }
}
