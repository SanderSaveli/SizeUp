using EventBusSystem;
using System;

namespace ViewElements.Button 
{
    public class PlayButton : Button, IMainMenuButton
    {
        protected override Type _buttonTupe { get => typeof(PlayButton); }

        public override void Click()
        {
            base.Click();
            EventBus.RaiseEvent<IGameSartHandler>(it => it.GameStart());
        }
    }
}

