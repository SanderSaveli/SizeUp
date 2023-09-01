using Services;
using Services.SceneLoad;

namespace ViewElements.Button
{
    public class BackButton : Button
    {
        public override void Click()
        {
            ServiceLockator.instance.GetService<ISceneLoadService>().LoadScene(SceneNames.Menu);
        }
    }
}

