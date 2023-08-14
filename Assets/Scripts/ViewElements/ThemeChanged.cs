using UnityEngine;
using Services.Economic;
using Services;

namespace ViewElements
{
    public abstract class ThemeChanged : MonoBehaviour
    {
        private IThemeService _themeService; 
        private void OnEnable()
        {
            _themeService = ServiceLockator.instance.GetService<IThemeService>();
            _themeService.OnNewThemeSelected += ChangeTheme;
        }

        private void OnDisable()
        {
            if(_themeService != null) 
            {
                _themeService.OnNewThemeSelected -= ChangeTheme;
            }
        }

        private void Start()
        {
            if(_themeService == null) 
            {
                _themeService = ServiceLockator.instance.GetService<IThemeService>();
            }
            ChangeTheme(_themeService.selectedTheme);
        }

        public abstract void ChangeTheme(Theme theme);
    }
}

