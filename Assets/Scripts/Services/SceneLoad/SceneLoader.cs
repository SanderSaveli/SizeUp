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
        }

        public void Shutdown()
        { }
    }
}


