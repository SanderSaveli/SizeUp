using UnityEngine;
using System;
using System.Collections.Generic;

namespace ViewElements.Button 
{
    public class SettingsButton : Button, IMainMenuButton
    {
        protected override Type _buttonTupe => typeof(SettingsButton);
        [SerializeField] private List<Button> buttonsToShow;
        [SerializeField] private SettingsButtonView _settingsView;
        private bool isMenuShowen = false;

        public override void Click()
        {
            base.Click();
            
            foreach(Button button in buttonsToShow) 
            {
                if (isMenuShowen)
                    button.Hide();
                else
                    button.Show();
            }
            isMenuShowen = !isMenuShowen;
            _settingsView.Click();
        }

        public override void Hide()
        {
            base.Hide();
            if (isMenuShowen) 
            {
                foreach (Button button in buttonsToShow)
                {
                    button.Hide();
                }
            }
        }
    }
}

