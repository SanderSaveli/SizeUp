using EventBusSystem;
using System;
namespace ViewElements.Button 
{
    public class BackToMenuButton : Button, IDeathMenuButton
    {
        protected override Type _buttonTupe { get => typeof(BackToMenuButton); }
        public override void Click()
        {
            base.Click();
            EventBus.RaiseEvent<IBackToMenuHandler>(it => it.BackToMenu());
        }
    }
}

