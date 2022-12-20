using UnityEngine;

[CreateAssetMenu(fileName = "LocationTheme", menuName = "Scriptable Objects/Location Theme", order = 1)]
public sealed class Theme : ScriptableObject
{
    [SerializeField] private int _cost;

    [SerializeField] private ButtonThemePresets _buttonThemePresets;
    [SerializeField] private EnemyThemePresets _enemyThemePresets;
    [SerializeField] private PlayerThemePresets _playerThemePresets;
    [SerializeField] private BackgroundThemePrisets _backgroundThemePrisets;


    public int Cost => _cost;
    public ButtonThemePresets ButtonTheme => _buttonThemePresets;
    public EnemyThemePresets EnemyTheme => _enemyThemePresets;
    public PlayerThemePresets PlayerTheme => _playerThemePresets;
    public BackgroundThemePrisets BackgroundTheme => _backgroundThemePrisets;
}
