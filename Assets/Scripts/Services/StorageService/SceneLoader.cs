using UnityEngine.SceneManagement;

namespace Services.StorageService
{
    public class SceneLoader : DontDestroyOnLoadSingletone<SceneLoader>
    {
        public ISceneData currentSceneData { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void LoadScene(string sceneName, ISceneData sceneData = null)
        {
            currentSceneData = sceneData;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}

