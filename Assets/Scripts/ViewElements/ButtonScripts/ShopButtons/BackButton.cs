using Services;
using Services.SceneLoad;
using System;

namespace ViewElements.Button
{
    public class BackButton : Button
    {
        protected override Type _buttonTupe => typeof(BackButton);
        public override void Click()
        {
            base.Click();
            ServiceLockator.instance.GetService<ISceneLoadService>().LoadScene(SceneNames.Menu);
        }
    }
}

