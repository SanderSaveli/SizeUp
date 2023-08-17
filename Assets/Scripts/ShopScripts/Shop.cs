using UnityEngine;

namespace Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ItemPlace _itemPlace;
        private FigureItemSeller _figureItemSeller;
        private ThemeItemSeller _themeItemSeller;


        public void Start()
        {
            _figureItemSeller = new FigureItemSeller(_itemPlace);
            _themeItemSeller = new ThemeItemSeller(_itemPlace);
            _themeItemSeller.Show();
        }

        public void ShowFigures()
        {
            _figureItemSeller.Show();
        }
        public void ShowThemes()
        {
            _themeItemSeller.Show();
        }
    }
}

