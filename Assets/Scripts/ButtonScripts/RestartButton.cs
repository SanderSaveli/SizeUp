public class RestartButton : Button, IDeathMenuButton
{
    public override void Click()
    {
        EventBus.RaiseEvent<IGameSartHandler>(it => it.GameStart());
    }
}
