using EventBusSystem;
using UnityEngine.SceneManagement;

namespace Services.SceneLoad
{
    public class SceneLoader : ISceneLoadService
    {
        public ISceneData currentSceneData { get; private set; }

        public void Initialize()
        { }

        public void LoadScene(string sceneName, ISceneData sceneData = null)
        {
            currentSceneData = sceneData;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            EventBusSystem.EventBus.RaiseEvent<ISceneChangedHandler>(it => it.SceneChanged(sceneName));
        }

        public void Shutdown()
        { }
    }
}


