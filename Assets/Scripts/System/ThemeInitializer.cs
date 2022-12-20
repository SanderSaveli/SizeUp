using UnityEngine;

public class ThemeInitializer : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private EnemyBall[] _enemyBalls;
    [SerializeField] private PlayerBall _playerBall;

    public void IniThemeOnObjects(Theme theme)
    {
        foreach (var button in _buttons)
        {
            button.IniTheme(theme.ButtonTheme);
        }
        foreach (var enemyBall in _enemyBalls)
        {
            enemyBall.IniTheme(theme.EnemyTheme);
        }
        _playerBall.IniTheme(theme.PlayerTheme);
    }
}
