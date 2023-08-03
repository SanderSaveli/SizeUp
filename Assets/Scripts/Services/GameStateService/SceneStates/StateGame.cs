using UnityEngine;

namespace Services.GameState 
{
    public class StateGame : ISceneState
    {
        private InputManager _inputManager;

        public void Enter()
        {
            _inputManager = GameObject.FindObjectOfType<InputManager>();
            _inputManager.enabled = true;
        }

        public void Exit()
        {
            _inputManager.enabled = false;
        }
    }
}

