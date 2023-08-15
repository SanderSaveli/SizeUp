using UnityEngine;
using Services.Economic;

namespace ViewElements 
{
    [CreateAssetMenu(fileName = "Location Theme", menuName = "Themes/new Location Theme")]
    public sealed class Theme : ScriptableObject, ISold
    {
        [field: SerializeField] public int price { get; private set; }
        [field: SerializeField] public Sprite potrait { get; private set; }

        [SerializeField] private ButtonTheme _buttonThemePresets;
        [SerializeField] private EnemyTheme _enemyThemePresets;
        [SerializeField] private PlayerTheme _playerThemePresets;
        [SerializeField] private BackgroundTheme _backgroundThemePrisets;

        public ButtonTheme ButtonTheme => _buttonThemePresets;
        public EnemyTheme EnemyTheme => _enemyThemePresets;
        public PlayerTheme PlayerTheme => _playerThemePresets;
        public BackgroundTheme BackgroundTheme => _backgroundThemePrisets;
    }
}

