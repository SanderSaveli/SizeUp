using Services.StorageService;
using Services.GameState;
using UnityEngine;
using Services.SceneLoad;
using Services.Economic;
using ViewElements;

namespace Services
{
    public class ServiceRegistrar : MonoBehaviour
    {
        [SerializeField] private ThemeDatabase _themeDatabase;
        private void Awake()
        {
            ServiceLockator lockator = ServiceLockator.instance;
            lockator.RegisterService<IGameStateService>(new GameStateManager());
            lockator.RegisterService<IStoregeService>(new JSONToFileStorageService());
            lockator.RegisterService<ISceneLoadService>(new SceneLoader());
            lockator.RegisterService<IScoreService>(new GameScoreService());
            lockator.RegisterService<IBankService>(new Bank());
            lockator.RegisterService<IThemeService>(new ThemeRepository(_themeDatabase));
        }
    }
}

