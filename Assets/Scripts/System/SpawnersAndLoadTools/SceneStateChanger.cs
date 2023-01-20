using System;

public class SceneStateChanger
{
    public static SceneStateChanger instance {get; private set;}

    public SceneStateChanger() 
    {
        if(instance == null) 
        { 
            instance = this;
            return;
        }
        throw new Exception("You already have Scene State Changer in this scene");
    }
    private ISceneState _currentGameMode;

    public void ChangeSceneState(ISceneState newGameMode)
    {
        if(_currentGameMode != newGameMode) 
        {
            _currentGameMode?.Exit();
            newGameMode.Enter();
            _currentGameMode = newGameMode;
        }
    }
}
