using UnityEngine;

public class SceneLoader: MonoBehaviour 
{
    private ThemeRepository _themeRepository;
    private FigureRepository _figureRepository;

    [SerializeField] private Transform FigurePosition;
    [SerializeField] private float EnemyCount;

    private SaveLoadSystem _loadSystem;
    private ThemeInitializer _themeInitializer;
    private BallSpawner _ballSpawner;

    private Transform _figurePosition => FigurePosition;

    public void Awake()
    {
        _themeRepository = FindObjectOfType<ThemeRepository>();
        _figureRepository = FindObjectOfType<FigureRepository>();
        _ballSpawner = FindObjectOfType<BallSpawner>();
        _loadSystem = new SaveLoadSystem();
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
        _loadSystem.LoadGame();
        Save save = _loadSystem.GetCurrentSave();
        _themeRepository.loadData(save.GetThemeRepositoryData());
        _figureRepository.LoadData(save.GetFigureRepositoryData());
    }

    private void SpawnActiveFigure()
    {
        Instantiate(_figureRepository.GetActiveFigure(), _figurePosition);
    }

    private void SpawnPlayerAndEnemy()
    {
        for (int i = 0; i < EnemyCount; i++) 
        {
            _ballSpawner.SpawnEnemy(FigurePosition.position);
        }
        _ballSpawner.SpawnPlayer(FigurePosition.position);
    }
    private void PaintAllToThemeColor()
    {
        _themeInitializer.IniThemeOnAllObjects(
            _themeRepository.GetActiveTheme()
            );
    }
}
