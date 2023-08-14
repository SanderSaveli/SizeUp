using System.Collections.Generic;
using ViewElements;

namespace Services.Economic
{
    public interface IThemeService : IService
    {
        public delegate void NewThemeSelected(Theme theme);
        public event NewThemeSelected OnNewThemeSelected;
        public Theme selectedTheme { get; }
        public IReadOnlyDictionary<Theme, ThemeStatus> themes { get; }

        public bool OpenTheme(Theme theme);
        public bool SelectTheme(Theme theme);
    }
}

