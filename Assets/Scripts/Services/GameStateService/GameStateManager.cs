using EventBusSystem;
namespace Services.GameState
{
    public class GameStateManager : IGameStateService, IGameSartHandler, IGameEndHandler, IBackToMenuHandler
    {
        public ISceneState currentGameState { get; private set; }

        public void ChangeSceneState(ISceneState newGameMode)
        {
            if (currentGameState != newGameMode)
            {
                currentGameState?.Exit();
                newGameMode.Enter();
                currentGameState = newGameMode;
            }
        }

        void IGameSartHandler.GameStart()
        {
            ChangeSceneState(new StateGame());
        }

        void IGameEndHandler.GameEnd()
        {
            ChangeSceneState(new StateDeathMenu());
        }

        void IBackToMenuHandler.BackToMenu()
        {
            ChangeSceneState(new StateMenu());
        }

        public void Initialize()
        {
            EventBus.Subscribe(this);
        }

        public void Shutdown()
        {
            EventBus.Unsubscribe(this);
        }
    }

}
