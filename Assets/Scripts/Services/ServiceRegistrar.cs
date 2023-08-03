using Services.StorageService;
using Services.GameState;
using UnityEngine;
using Services.SceneLoad;

namespace Services
{
    public class ServiceRegistrar : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLockator lockator = ServiceLockator.instance;
            lockator.RegisterService<IGameStateService>(new GameStateManager());
            lockator.RegisterService<IStoregeService>(new JSONToFileStorageService());
            lockator.RegisterService<ISceneLoadService>(new SceneLoader());
        }
    }
}

