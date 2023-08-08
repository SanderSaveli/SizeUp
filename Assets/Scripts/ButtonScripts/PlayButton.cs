using EventBusSystem;
public class PlayButton : Button, IMainMenuButton
{
    public override void Click()
    {
        EventBus.RaiseEvent<IGameSartHandler>(it => it.GameStart());
    }
}
