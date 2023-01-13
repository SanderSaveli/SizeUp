using UnityEngine;

public class GameStateManager : MonoBehaviour, IGameSartHandler, IGameEndHandler, IBackToMenuHandler
{
    private SceneStateChanger _sceneStateChanger;

    private void OnEnable()
    {
        LoadStartPreferences();
        EventBus.Subscribe(this);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    private void LoadStartPreferences()
    {
        _sceneStateChanger = new SceneStateChanger();
        SetNewSceneState(new StateMenu());
    }

    private void SetNewSceneState(ISceneState newSceneState)
    {
        _sceneStateChanger.ChangeSceneState(newSceneState);
    }

    void IGameSartHandler.GameStart()
    {
        SetNewSceneState(new StateGame());
    }

    void IGameEndHandler.GameEnd()
    {
        SetNewSceneState(new StateDeathMenu());
    }

    void IBackToMenuHandler.BackToMenu()
    {
        SetNewSceneState(new StateMenu());
    }
}
