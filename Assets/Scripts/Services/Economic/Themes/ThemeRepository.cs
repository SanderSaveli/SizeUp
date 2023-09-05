using Services.StorageService;
using System.Collections.Generic;
using ViewElements;

namespace Services.Economic
{
    public class ThemeRepository : IThemeService
    {
        public event IThemeService.NewThemeSelected OnNewThemeSelected;

        public Theme selectedTheme
        {
            get => _selectedTheme;
            private set
            {
                _selectedTheme = value;
                OnNewThemeSelected?.Invoke(value);
            }
        }
        private Theme _selectedTheme;

        public IReadOnlyDictionary<Theme, ItemStatus> themes { get => _themeSeller.allItems; }

        private Seller<Theme> _themeSeller;
        private const string _saveKey = "ThemeStatuses";

        public ThemeRepository(ThemeDatabase database, IStoregeService storegeService, IBankService bankService)
        {
            _themeSeller = new Seller<Theme>(database.themes, storegeService, bankService, _saveKey);
            _themeSeller.OnNewItemSelected += SelectNewTheme;
        }

        public void Initialize()
        {
            selectedTheme = _themeSeller.selectedItem;
        }

        public void Shutdown()
        { }

        public bool OpenTheme(Theme theme)
        {
            return _themeSeller.OpenItem(theme);
        }

        public bool SelectTheme(Theme theme)
        {
            return _themeSeller.SelectItem(theme);
        }

        private void SelectNewTheme(Theme theme)
        {
            selectedTheme = theme;
        }
    }
}
