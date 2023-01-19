using UnityEngine;

[CreateAssetMenu(fileName = "LocationTheme", menuName = "Scriptable Objects/Location Theme", order = 1)]
public sealed class Theme : ScriptableObject
{
    [SerializeField] private int _cost;

    [SerializeField] private ButtonTheme _buttonThemePresets;
    [SerializeField] private EnemyTheme _enemyThemePresets;
    [SerializeField] private PlayerTheme _playerThemePresets;
    [SerializeField] private BackgroundTheme _backgroundThemePrisets;


    public int Cost => _cost;
    public ButtonTheme ButtonTheme => _buttonThemePresets;
    public EnemyTheme EnemyTheme => _enemyThemePresets;
    public PlayerTheme PlayerTheme => _playerThemePresets;
    public BackgroundTheme BackgroundTheme => _backgroundThemePrisets;
}
