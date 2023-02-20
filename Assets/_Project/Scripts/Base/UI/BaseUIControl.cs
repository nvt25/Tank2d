using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BASE.UI
{
    public abstract class BaseUIControl : MonoBehaviour
    {
        [SerializeField]
        private UILayer uILayer;
        [SerializeField]
        protected AnimControl anim;
        public UILayer UILayer { get => uILayer;}

        public abstract void Init(object[] prametter);
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
        protected virtual void OnBackClick()
        {

        }
    }
    public enum UILayer
    {
        Menu,
        Popup
    }
}
