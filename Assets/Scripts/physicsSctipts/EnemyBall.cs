using UnityEngine;

public class EnemyBall : Ball
{
    protected override void OnEnable()
    {
        base.OnEnable();
        EnemyTheme theme =
            GameObject.FindObjectOfType<ThemeRepository>().GetActiveEnemyTheme();
        IniTheme(theme);
    }
    public void IniTheme(EnemyTheme presets)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = presets.EnemyBall;
    }
}
