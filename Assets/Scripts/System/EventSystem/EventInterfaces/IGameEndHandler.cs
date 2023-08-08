namespace EventBusSystem 
{
    public interface IGameEndHandler : IGlobalSubscriber
    {
        public void GameEnd();
    }
}

