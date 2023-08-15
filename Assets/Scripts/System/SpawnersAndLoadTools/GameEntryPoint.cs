using Services;
using Services.GameState;
using UnityEngine;
using ViewElements;
using Services.Economic;

public class GameEntryPoint : MonoBehaviour
{

    [SerializeField] private Transform FigurePosition;
    [SerializeField] private float EnemyCount;

    private BallSpawner _ballSpawner;

    private Transform _figurePosition => FigurePosition;

    public void Awake()
    {
        _ballSpawner = FindObjectOfType<BallSpawner>();
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
        ServiceLockator.instance.GetService<IGameStateService>().
            ChangeSceneState(new StateMenu());
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
