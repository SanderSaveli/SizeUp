using UnityEngine.UI;

namespace ViewElements
{

    public class BackgroundView : ThemeChanged
    {
        public override void ChangeTheme(Theme theme)
        {
            gameObject.GetComponent<Image>().sprite = theme.BackgroundTheme.Background;
        }
    }
}
