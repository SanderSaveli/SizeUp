public class StateGame : ISceneState
{
    private InputManager _inputManager;

    public void Enter()
    {
        //_inputManager.enabled = true;
        UnityEngine.Debug.Log("GameStaet");
    }

    public void Exit()
    {
        _inputManager.enabled = false;
    }
}
