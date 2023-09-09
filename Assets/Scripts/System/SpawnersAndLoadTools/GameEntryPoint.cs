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
    [SerializeField] private TMP_Text text;

    [SerializeField] private BallSpawner _ballSpawner;

    private Transform _figurePosition => FigurePosition;

    public void Awake()
    {
        text.text += "Awake. ";
        LoadScene();
    }

    public void LoadScene()
    {
        text.text += "LoasdScene Step1. ";
        SetGameState();
        text.text += "LoasdScene Step2. ";
        SpawnActiveFigure();
        text.text += "LoasdScene Step3. ";
        SpawnPlayerAndEnemy();
    }

    private void SetGameState()
    {
        ServiceLockator.instance.GetService<IGameStateService>().
            ChangeSceneState(new StateMenu());
        text.text += ServiceLockator.instance.GetService<IGameStateService>().currentGameState.ToString() + " ";
    }

    private void SpawnActiveFigure()
    {
        IFigureService figureRepository = ServiceLockator.instance.GetService<IFigureService>();
        text.text += figureRepository.selectedFigure.ToString() + " ";
        text.text += Instantiate(figureRepository.selectedFigure.figureObject, _figurePosition).ToString() + " ";
    }

    private void SpawnPlayerAndEnemy()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            _ballSpawner.SpawnEnemy();
            text.text += "Spawn enemy. ";
        }
        _ballSpawner.SpawnPlayer();
        text.text += "Spawn player. ";
    }
}
