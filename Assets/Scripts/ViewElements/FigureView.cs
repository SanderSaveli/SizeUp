using UnityEngine;
using UnityEngine.UI;

namespace ViewElements
{
    public class FigureView : ThemeChanged
    {
        [SerializeField] private SpriteRenderer _image;
        public override void ChangeTheme(Theme theme)
        {
            _image.color = theme.BackgroundTheme.FigureColor;
        }
    }
}

