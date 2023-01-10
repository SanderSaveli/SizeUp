using UnityEngine;

public class ThemeInitializer : MonoBehaviour
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
        _buttons = FindObjectsOfType<Button>();
        _enemyBalls = FindObjectsOfType<EnemyBall>();
        _playerBall = FindObjectOfType<PlayerBall>();
        _background = FindObjectOfType<Background>();
    }
}
