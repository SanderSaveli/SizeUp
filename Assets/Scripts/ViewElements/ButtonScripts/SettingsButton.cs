using UnityEngine;
using System;

namespace ViewElements.Button 
{
    public class SettingsButton : Button, IMainMenuButton
    {
        protected override Type _buttonTupe => typeof(SettingsButton);

        public override void Click()
        {
            base.Click();
            Debug.Log("Settings");
        }
    }
}

