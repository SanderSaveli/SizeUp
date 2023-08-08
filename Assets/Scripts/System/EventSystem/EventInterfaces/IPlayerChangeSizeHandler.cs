namespace EventBusSystem
{
    public interface IPlayerChangeSizeHandler : IGlobalSubscriber
    {
        public void OnPlayerStartIncrease();
        public void OnPlayerEndIncrease();
    }
}
