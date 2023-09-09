using Services;
using Services.SceneLoad;
using System;

namespace ViewElements.Button
{
    public class ShopButton : Button, IMainMenuButton
    {
        protected override Type _buttonTupe => typeof(ShopButton);
        public override void Click()
        {
            base.Click();
            ServiceLockator.instance.GetService<ISceneLoadService>().
                LoadScene(SceneNames.Shop);
        }
    }

}
