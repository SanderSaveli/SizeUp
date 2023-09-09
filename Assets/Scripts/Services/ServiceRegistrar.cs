using Services.StorageService;
using Services.GameState;
using UnityEngine;
using Services.SceneLoad;
using Services.Economic;
using ViewElements;
using Services.Audio;

namespace Services
{
    public class ServiceRegistrar : MonoBehaviour
    {
        [SerializeField] private ThemeDatabase _themeDatabase;
        [SerializeField] private FigureDatabase _figureDatabase;
        [SerializeField] private AudioDatabase audioDatabase;
        private void Awake()
        {
            ServiceLockator lockator = ServiceLockator.instance;

            lockator.RegisterService<IGameStateService>(new GameStateManager());
            lockator.RegisterService<IStoregeService>(new JSONToFileStorageService());
            lockator.RegisterService<ISceneLoadService>(new SceneLoader());
            lockator.RegisterService<IScoreService>(new GameScoreService());
            lockator.RegisterService<IBankService>(new Bank());
            lockator.RegisterService<IThemeService>(new ThemeRepository(_themeDatabase,
                lockator.GetService<IStoregeService>(), lockator.GetService<IBankService>()));
            lockator.RegisterService<IFigureService>(new FigureRepository(_figureDatabase,
                lockator.GetService<IStoregeService>(), lockator.GetService<IBankService>()));
            lockator.RegisterService<IAudioService>(new AudioService(audioDatabase,
                lockator.GetService<IStoregeService>()));

            lockator.GetService<ISceneLoadService>().LoadScene(SceneNames.Menu);
        }
    }
}

