using EventBusSystem;
using System;

namespace ViewElements.Button 
{
    public class RestartButton : Button, IDeathMenuButton
    {
        protected override Type _buttonTupe => typeof(RestartButton);
        public override void Click()
        {
            base.Click();
            EventBus.RaiseEvent<IGameSartHandler>(it => it.GameStart());
        }
    }
}

