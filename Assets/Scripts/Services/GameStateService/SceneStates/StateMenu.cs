using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.GameState 
{
    public class StateMenu : ISceneState
    {
        private List<Button> _menuButton = new List<Button>();
        public void Enter()
        {
            Button[] buttonsToEnable =
                GameObject.FindObjectsOfType<Button>()
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

