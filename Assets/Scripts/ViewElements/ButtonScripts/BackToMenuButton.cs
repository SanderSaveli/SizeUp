using EventBusSystem;
namespace ViewElements.Button 
{
    public class BackToMenuButton : Button, IDeathMenuButton
    {
        public override void Click()
        {
            EventBus.RaiseEvent<IBackToMenuHandler>(it => it.BackToMenu());
        }
    }
}
