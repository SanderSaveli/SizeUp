using UnityEngine;
using ViewElements;
using Services.StorageService;
using Services;

public class SceneLoader: MonoBehaviour 
{
    private ThemeRepository _themeRepository;
    private FigureRepository _figureRepository;

    [SerializeField] private Transform FigurePosition;
    [SerializeField] private float EnemyCount;

    private IStoregeService _storageService;
    private ThemeInitializer _themeInitializer;
    private BallSpawner _ballSpawner;

    private Transform _figurePosition => FigurePosition;

    public void Awake()
    {
        _themeRepository = FindObjectOfType<ThemeRepository>();
        _figureRepository = FindObjectOfType<FigureRepository>();
        _ballSpawner = FindObjectOfType<BallSpawner>();
        _storageService = ServiceLockator.instance.GetService<IStoregeService>();
        _themeInitializer = new ThemeInitializer();
        LoadScene();
    }

    public void LoadScene()
    {
        LoadDataToRepository();
        SpawnActiveFigure();
        SpawnPlayerAndEnemy();
        PaintAllToThemeColor();
    }

    private void LoadDataToRepository()
    {
        _themeRepository.LoadData();
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
    private void PaintAllToThemeColor()
    {
        _themeInitializer.IniThemeOnAllObjects(
            _themeRepository.GetActiveTheme()
            );
    }
}
