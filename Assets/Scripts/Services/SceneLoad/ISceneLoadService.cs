namespace Services.SceneLoad
{
    public interface ISceneLoadService : IService
    {
        public ISceneData currentSceneData { get; }

        public void LoadScene(string sceneName, ISceneData sceneData = null);
    }
}

