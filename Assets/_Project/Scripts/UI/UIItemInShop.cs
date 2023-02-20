using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BASE.UI
{
    public class UIItemInShop : BaseUIControl
    {
        [SerializeField]
        private Text nameProduct;
        [SerializeField]
        private Text priceProduct;
        [SerializeField]
        private Image imgProduct;
        [SerializeField]
        private RectTransform imgStatusProduct;
        [SerializeField]
        private Button btnItem;
        [SerializeField]
        private UIShopControl shopControl;
        public PlayerMode item;
        private void Start()
        {
            btnItem.onClick.AddListener(onclickItem);

        }
        public override void Init(object[] prametter)
        {
            item = (PlayerMode)prametter[0];
            shopControl = (UIShopControl)prametter[1];
            nameProduct.text = item.NameModel;
            priceProduct.text = item.PriceCoint.ToString();
            imgProduct.sprite = item.Sprite;
            imgStatusProduct.gameObject.SetActive(item.Status == 0);
        }
        private void onclickItem()
        {
            if (CanvaManager.Ins.isAnimRunning) return;

            shopControl.SelectItem(item);
        }
    }
}
