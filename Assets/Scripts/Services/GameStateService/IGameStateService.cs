namespace Services.GameState
{
    public interface IGameStateService : IService
    {
        public ISceneState currentGameState { get; }
        public void ChangeSceneState(ISceneState newGameMode);
    }
}

