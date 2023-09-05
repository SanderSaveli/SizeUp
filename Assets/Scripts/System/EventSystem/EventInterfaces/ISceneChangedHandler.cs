namespace EventBusSystem
{
    public interface ISceneChangedHandler : IGlobalSubscriber
    {
        public void SceneChanged(string sceneName);
    }
}

