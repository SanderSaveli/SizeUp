using System;

namespace EventBusSystem 
{
    public interface IButtonClickHandler : IGlobalSubscriber
    {
        public void ButtonClicked(Type butttonType);
    }
}

