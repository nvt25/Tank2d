using System;
using System.Collections.Generic;
using UnityEngine;

namespace BASE.UI
{
    public class CanvaManager : Singleton<CanvaManager>
    {
        public bool isAnimRunning;
        public Action<float> SlideBarHeaty;
        private List<Transform> listUIParent = new List<Transform>();
        private Dictionary<string, BaseUIControl> loadedUI = new Dictionary<string, BaseUIControl>();
        private string UIPath;
        public UIGamePlay uIGamePlay;

        protected override  void Awake()
        {
            base.Awake();
            LoadLayerUI();
        }

        private void LoadLayerUI()
        {
            string[] layers = Enum.GetNames(typeof(UILayer));//get all name enum of uilayer

            //GameObject uiLayer = new GameObject("UI",typeof(GameObject));
            //uiLayer.transform.SetParent(transform);
            //uiLayer.AddComponent<RectTransform>();
            //SetValueRect(uiLayer.GetComponent<RectTransform>());
            //========
            RectTransform uiLayer = new GameObject("UI", typeof(RectTransform)).GetComponent<RectTransform>();
            uiLayer.SetParent(transform);
            SetValueRect(uiLayer);
            for (int i = 0; i < layers.Length; i++)
            {
                //creat gameObject Ui
                RectTransform layer = new GameObject(layers[i], typeof(RectTransform)).GetComponent<RectTransform>();
                layer.SetParent(uiLayer);
                SetValueRect(layer);
                listUIParent.Add(layer);
            }
        }

        private void SetValueRect(RectTransform rect)
        {
            rect.transform.localScale = Vector3.one;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            //screen Space - Camera

            rect.localPosition = Vector3.zero;
        }

        public void OpenUI(string nameUI, object[] prametter, string UIPath = "UI/")
        {
            this.UIPath = UIPath;
            BaseUIControl ui;

            if (loadedUI.ContainsKey(nameUI))
            {
                ui = loadedUI[nameUI];
                ui.gameObject.SetActive(true);
            }
            else
            {
                BaseUIControl UIPrefab = Resources.Load<BaseUIControl>(UIPath + nameUI);
                ui = Instantiate(UIPrefab, listUIParent[(int)UIPrefab.UILayer]);
                ui.gameObject.SetActive(true);
                loadedUI.Add(nameUI, ui);
            }
            ui.transform.SetAsLastSibling();
            ui.Init(prametter);
        }
    }
}