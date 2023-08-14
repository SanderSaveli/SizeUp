using UnityEngine;

namespace ViewElements.Button 
{
    public class SettingsButton : Button, IMainMenuButton
    {
        public override void Click()
        {
            Debug.Log("Settings");
        }
    }
}

