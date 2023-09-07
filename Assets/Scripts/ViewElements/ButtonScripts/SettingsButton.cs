using UnityEngine;
using System;
using System.Collections.Generic;

namespace ViewElements.Button 
{
    public class SettingsButton : Button, IMainMenuButton
    {
        protected override Type _buttonTupe => typeof(SettingsButton);
        [SerializeField] private List<Button> buttonsToShow;
        private bool isMenuShowen = false;

        public override void Click()
        {
            base.Click();
            
            foreach(Button button in buttonsToShow) 
            {
                Debug.Log(button);
                if (isMenuShowen)
                    button.Hide();
                else
                    button.Show();
            }
            isMenuShowen = !isMenuShowen;
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

