using UnityEngine;

public class SceneLoader : MonoBehaviour, IGameSartHandler, IGameEndHandler
{
    public Transform FigurePosition;

    private SaveLoadSystem _loadSystem;

    private ThemeRepository _themeRepository;
    private FigureRepository _figureRepository;

    private ThemeInitializer _themeInitializer;

    private SceneStateChanger _sceneStateChanger;

    private void Awake()
    {
        Initialize();
        LoadScene(new SateMenu());
    }

    private void OnEnable()
    {
        EventBus.Subscribe(this);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    public void LoadScene(ISceneState state)
    {
        LoadDataToRepository();
        SpawnActiveFigure();
        PaintAllToThemeColor();
        SetNewSceneState(state);
    }

    private void Initialize()
    {
        _loadSystem = new SaveLoadSystem();
        _sceneStateChanger = new SceneStateChanger();
        _themeRepository = FindObjectOfType<ThemeRepository>();
        _figureRepository = FindObjectOfType<FigureRepository>();
        _themeInitializer = FindObjectOfType<ThemeInitializer>();
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
        Instantiate(_figureRepository.GetActiveFigure(), FigurePosition);
    }

    private void PaintAllToThemeColor()
    {
        _themeInitializer.IniThemeOnObjects(
            _themeRepository.GetActiveTheme()
            );
    }

    private void SetNewSceneState(ISceneState newSceneState) 
    {
        _sceneStateChanger.ChangeSceneState(newSceneState);
    }

    void IGameSartHandler.GameStart()
    {
        _sceneStateChanger.ChangeSceneState(new StateGame());
    }

    void IGameEndHandler.GameEnd()
    {
        _sceneStateChanger.ChangeSceneState(new StateDeathMenu());
    }
}
