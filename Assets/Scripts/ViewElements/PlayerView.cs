using UnityEngine;

namespace ViewElements
{
    public class PlayerView : ThemeChanged
    {
        public override void ChangeTheme(Theme theme)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = theme.PlayerTheme.PlayerBall;
        }
    }
}

