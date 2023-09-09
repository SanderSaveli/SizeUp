using System;
using UnityEngine;

namespace ViewElements.Button
{
    public class GuideButton : Button, ISettingsMenuButton
    {
        [SerializeField] private GuideWindow guideWindow;
        protected override Type _buttonTupe => typeof(GuideButton);

        private void OnEnable()
        {
            guideWindow.OnPointerClick += HideWindow;
        }
        public override void Click()
        {
            base.Click();
            guideWindow.gameObject.SetActive(true);
        }

        public void HideWindow()
        {
            guideWindow.gameObject.SetActive(false);
        }

        public override void Hide()
        {
            base.Hide();
            HideWindow();
        }
    }
}
