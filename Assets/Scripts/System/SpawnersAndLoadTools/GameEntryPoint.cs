using Services;
using Services.GameState;
using UnityEngine;
using ViewElements;
using Services.Economic;
using TMPro;

public class GameEntryPoint : MonoBehaviour
{

    [SerializeField] private Transform FigurePosition;
    [SerializeField] private float EnemyCount;

    [SerializeField] private BallSpawner _ballSpawner;

    private Transform _figurePosition => FigurePosition;

    public void Awake()
    {
        LoadScene();
    }

    public void LoadScene()
    {
        SetGameState();
        SpawnActiveFigure();
        SpawnPlayerAndEnemy();
    }

    private void SetGameState()
    {
        IGameStateService gameStateService = ServiceLockator.instance.GetService<IGameStateService>();
        StateMenu sm = new StateMenu();

        gameStateService.ChangeSceneState(sm);
    }

    private void SpawnActiveFigure()
    {
        IFigureService figureRepository = ServiceLockator.instance.GetService<IFigureService>();
        Instantiate(figureRepository.selectedFigure.figureObject, _figurePosition);
    }

    private void SpawnPlayerAndEnemy()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            _ballSpawner.SpawnEnemy();
        }
        _ballSpawner.SpawnPlayer();
    }
}
