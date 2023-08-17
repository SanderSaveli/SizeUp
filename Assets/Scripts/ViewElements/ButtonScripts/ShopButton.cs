using Services;
using UnityEngine;
using Services.SceneLoad;

namespace ViewElements.Button 
{
    public class ShopButton : Button, IMainMenuButton
    {
        public override void Click()
        {
            ServiceLockator.instance.GetService<ISceneLoadService>().
                LoadScene(SceneNames.Shop);
        }
    }

}
