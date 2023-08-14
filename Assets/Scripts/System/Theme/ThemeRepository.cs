using Services.StorageService;
using System;
using System.Collections.Generic;
using ViewElements;

namespace Services.Economic
{
    public class ThemeRepository : IThemeService
    {
        public event IThemeService.NewThemeSelected OnNewThemeSelected;

        public Theme selectedTheme { get => _selectedTheme;
            private set
            { 
                _selectedTheme = value;
                OnNewThemeSelected?.Invoke(value);
            }
        }
        private Theme _selectedTheme;

        public IReadOnlyDictionary<Theme, ThemeStatus> themes { get => _themes;}
        public Dictionary<Theme, ThemeStatus> _themes { get; private set; }

        private IStoregeService _storegeService;
        private const string _saveKey = "ThemeStatuses";

        public ThemeRepository(ThemeDatabase database)
        {
            _storegeService = ServiceLockator.instance.GetService<IStoregeService>();
            IniThemes(database);
        }

        private Theme findSelectedTheme() 
        {
            foreach (Theme theme in _themes.Keys)
            {
                if(_themes.TryGetValue(theme, out ThemeStatus status)) 
                {
                    if(status == ThemeStatus.Selected) 
                    {
                        return theme;
                    }
                }
            }
            throw new NotImplementedException("There is no seleckted theme!");
        }

        public void Initialize()
        {
            selectedTheme = findSelectedTheme();
        }

        public void Shutdown()
        {    }

        public bool OpenTheme(Theme theme)
        {
            if(_themes.ContainsKey(theme)) 
            {
                if (_themes[theme] == ThemeStatus.Close) 
                {
                    _themes[theme] = ThemeStatus.Open;
                    SaveCurrentStatuses();
                    return true;
                }
            }
            return false;
        }

        public bool SelectTheme(Theme theme)
        {
            if (_themes.ContainsKey(theme))
            {
                if (_themes[theme] == ThemeStatus.Open)
                {
                    _themes[selectedTheme] = ThemeStatus.Open;
                    selectedTheme = theme;
                    _themes[theme] = ThemeStatus.Selected;
                    SaveCurrentStatuses();
                    return true;
                }
            }
            return false;
        }

        private bool LoadThemeStatus(out List<ThemeStatus> themeStatuses) 
        {
            themeStatuses = _storegeService.Load<List<ThemeStatus>>(_saveKey);
            if(themeStatuses == null || themeStatuses.Count == 0) 
            {
                return false;
            }
            return true;
        }

        private void SaveCurrentStatuses() 
        {
            List<ThemeStatus> statuses = new();
            foreach(Theme theme in themes.Keys) 
            {
                statuses.Add(themes[theme]);
            }
            _storegeService.Save(_saveKey, statuses);
        }

        private void IniThemes(ThemeDatabase database) 
        {
            if (LoadThemeStatus(out List<ThemeStatus> themeStatuses) &&
                themeStatuses.Count == database.themes.Count)
            {
                DefaultThemeIni(database, themeStatuses);
            }
            else
            {
                CreateNewStatusesAndIni(database, themeStatuses);
            }
        }

        private void DefaultThemeIni(ThemeDatabase database, List<ThemeStatus> themeStatuses) 
        {
            _themes = new Dictionary<Theme, ThemeStatus>();
            int i = 0;
            foreach (Theme theme in database.themes)
            {
                _themes.Add(theme, themeStatuses[i++]);
            }
        }

        private void CreateNewStatusesAndIni(ThemeDatabase database, List<ThemeStatus> themeStatuses) 
        {
            _themes = new Dictionary<Theme, ThemeStatus>();
            foreach (Theme theme in database.themes)
            {
                _themes.Add(theme, ThemeStatus.Close);
            }
            _themes[database.themes[0]] = ThemeStatus.Selected;
            SaveCurrentStatuses();
        }
    }
}
