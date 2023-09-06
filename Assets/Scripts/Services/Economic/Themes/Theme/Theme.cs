using UnityEngine;
using Services.Economic;

namespace ViewElements 
{
    [CreateAssetMenu(fileName = "Theme", menuName = "Themes/new Theme")]
    public sealed class Theme : ScriptableObject, ISold
    {
        [field: SerializeField] public int price { get; private set; }
        [field: SerializeField] public Sprite potrait { get; private set; }

        [SerializeField] private ButtonTheme _buttonThemePresets;
        [SerializeField] private EnemyTheme _enemyThemePresets;
        [SerializeField] private PlayerTheme _playerThemePresets;
        [SerializeField] private BackgroundTheme _backgroundThemePrisets;
        [SerializeField] private MainMenuAudio _audio;

        public ButtonTheme ButtonTheme => _buttonThemePresets;
        public EnemyTheme EnemyTheme => _enemyThemePresets;
        public PlayerTheme PlayerTheme => _playerThemePresets;
        public BackgroundTheme BackgroundTheme => _backgroundThemePrisets;
        public MainMenuAudio audio => _audio;
    }
}

