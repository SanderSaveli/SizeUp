public class BackToMenuButton : Button
{
    public override void Click()
    {
        EventBus.RaiseEvent<IBackToMenuHandler>(it => it.BackToMenu());
    }
}
