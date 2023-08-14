using Services;
using Services.GameState;
using UnityEngine;
using ViewElements;
using Services.Economic;

public class GameEntryPoint : MonoBehaviour
{
    private IThemeService _themeRepository;
    private FigureRepository _figureRepository;

    [SerializeField] private Transform FigurePosition;
    [SerializeField] private float EnemyCount;

    private BallSpawner _ballSpawner;

    private Transform _figurePosition => FigurePosition;

    public void Awake()
    {
        _themeRepository = ServiceLockator.instance.GetService<IThemeService>();
        _figureRepository = FindObjectOfType<FigureRepository>();
        _ballSpawner = FindObjectOfType<BallSpawner>();
        LoadScene();
    }

    public void LoadScene()
    {
        LoadDataToRepository();
        SetGameState();
        SpawnActiveFigure();
        SpawnPlayerAndEnemy();
    }

    private void SetGameState()
    {
        ServiceLockator.instance.GetService<IGameStateService>().
            ChangeSceneState(new StateMenu());
    }

    private void LoadDataToRepository()
    {
        _figureRepository.LoadData();
    }

    private void SpawnActiveFigure()
    {
        Instantiate(_figureRepository.GetActiveFigure(), _figurePosition);
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
