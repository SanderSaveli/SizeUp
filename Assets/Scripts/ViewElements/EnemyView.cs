using UnityEngine;
namespace ViewElements
{
    public class EnemyView : ThemeChanged
    {
        public override void ChangeTheme(Theme theme)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = theme.EnemyTheme.EnemyBall;
        }
    }
}

