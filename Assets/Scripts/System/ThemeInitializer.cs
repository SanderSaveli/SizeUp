using UnityEngine;

namespace ViewElements 
{
    public class ThemeInitializer
    {
        private Button[] _buttons;
        private EnemyBall[] _enemyBalls;
        private PlayerBall _playerBall;
        private Background _background;

        public void IniThemeOnAllObjects(Theme theme)
        {
            IniThemeOnButtons(theme.ButtonTheme);
            IniThemeOnBackground(theme.BackgroundTheme);
            IniThemeOnPlayer(theme.PlayerTheme);
            IniThemeOnEnemy(theme.EnemyTheme);
        }

        public void IniThemeOnButtons(ButtonTheme theme) 
        {   }

        public void IniThemeOnBackground(BackgroundTheme theme) 
        {
            _background = GameObject.FindObjectOfType<Background>();
            _background.IniTheme(theme);
        }

        public void IniThemeOnPlayer(PlayerTheme theme) 
        {
            _playerBall = GameObject.FindObjectOfType<PlayerBall>();
            _playerBall.IniTheme(theme);
        }

        public void IniThemeOnEnemy(EnemyTheme theme) 
        {
            _enemyBalls = GameObject.FindObjectsOfType<EnemyBall>();
            foreach (var enemyBall in _enemyBalls)
            {
                enemyBall.IniTheme(theme);
            }
        }
    }
}


