using UnityEngine;

public class SceneLoader: MonoBehaviour 
{
    private ThemeRepository _themeRepository;
    private FigureRepository _figureRepository;

    [SerializeField] private Transform FigurePosition;

    private SaveLoadSystem _loadSystem;
    private ThemeInitializer _themeInitializer;

    private Transform _figurePosition;

    public void Awake()
    {
        _themeRepository = FindObjectOfType<ThemeRepository>();
        _figureRepository = FindObjectOfType<FigureRepository>();
        _figurePosition = FigurePosition;
        _themeInitializer = new ThemeInitializer();
        _loadSystem = new SaveLoadSystem();
        LoadScene();
    }

    public void LoadScene()
    {
        LoadDataToRepository();
        SpawnActiveFigure();
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

    private void PaintAllToThemeColor()
    {
        _themeInitializer.IniThemeOnObjects(
            _themeRepository.GetActiveTheme()
            );
    }
}
