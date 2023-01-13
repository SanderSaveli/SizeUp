using UnityEngine;

public class ThemeInitializer
{
    private Button[] _buttons;
    private EnemyBall[] _enemyBalls;
    private PlayerBall _playerBall;
    private Background _background;

    public void IniThemeOnObjects(Theme theme)
    {
        FindAllObjectsVaryingFromTheme();

        foreach (var button in _buttons)
        {
            button.IniTheme(theme.ButtonTheme);
        }

        foreach (var enemyBall in _enemyBalls)
        {
            enemyBall.IniTheme(theme.EnemyTheme);
        }

        _playerBall.IniTheme(theme.PlayerTheme);

        _background.IniTheme(theme.BackgroundTheme);
    }

    public void FindAllObjectsVaryingFromTheme()
    {
        _buttons = GameObject.FindObjectsOfType<Button>();
        _enemyBalls = GameObject.FindObjectsOfType<EnemyBall>();
        _playerBall = GameObject.FindObjectOfType<PlayerBall>();
        _background = GameObject.FindObjectOfType<Background>();
    }
}
