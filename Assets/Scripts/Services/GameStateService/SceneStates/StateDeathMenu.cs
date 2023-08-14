using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ViewElements.Button;

namespace Services.GameState 
{
    public class StateDeathMenu : ISceneState
    {
        private List<Button> _deathMenuButton = new List<Button>();
        public void Enter()
        {
            Button[] buttonsToEnable =
    GameObject.FindObjectsOfType<Button>()
    .Where(it => it.GetComponent<IDeathMenuButton>() != null).ToArray();

            foreach (Button button in buttonsToEnable)
            {
                button.Show();
                _deathMenuButton.Add(button);
            }
        }

        public void Exit()
        {
            foreach (Button button in _deathMenuButton)
            {
                button.Hide();
            }

            BallSpawner ballSpawner = GameObject.FindObjectOfType<BallSpawner>();
            ballSpawner.SpawnPlayer();
        }
    }
}

