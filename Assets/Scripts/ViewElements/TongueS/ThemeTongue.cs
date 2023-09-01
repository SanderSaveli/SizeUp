using System;
using UnityEngine;

namespace ViewElements.Button
{
    public class ThemeTongue : TongueButton
    {
        [SerializeField] private Shop.Shop _shop;

        private void OnEnable()
        {
            OnClick += Click;
        }
        protected override void Click(ITongue tongue)
        {
            _shop.ShowThemes();
        }
    }
}


