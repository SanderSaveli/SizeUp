using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ViewElements.Button;

namespace Services.GameState 
{
    public class StateMenu : ISceneState
    {
        private List<Button> _menuButton = new List<Button>();
        public void Enter()
        {
            Button[] b = GameObject.FindObjectsOfType<Button>();
            Button[] buttonsToEnable =
                b
                .Where(it => it.GetComponent<IMainMenuButton>()!= null).ToArray();
            foreach (Button button in buttonsToEnable)
            {
                button.Show();
                _menuButton.Add(button);
            }
        }

        public void Exit()
        {
            foreach (Button button in _menuButton)
            {
                button.Hide();
            }
        }
    }
}

