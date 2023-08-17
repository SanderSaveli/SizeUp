using Services;
using Services.Economic;
using UnityEngine;
using ViewElements;

namespace Shop
{
    public class ThemeItemSeller : ShopItemSeller<Theme>
    {
        private IThemeService _themeService;
        public ThemeItemSeller(IItemPlace itemPlace) :
            base(ServiceLockator.instance.GetService<IThemeService>().themes, itemPlace)
        {
            _themeService = ServiceLockator.instance.GetService<IThemeService>();
        }

        protected override void ClickOnSlot(ShopSlot<Theme> slot)
        {
            switch (slot.itemStatus)
            {
                case ItemStatus.Close:
                    if (_themeService.OpenTheme(slot._item))
                    {
                        Open(slot);
                        Debug.Log(slot.itemStatus);
                    }
                    break;
                case ItemStatus.Open:
                    if (_themeService.SelectTheme(slot._item))
                    {
                        Select(slot);
                        Debug.Log(slot.itemStatus);
                    }
                    break;
                case ItemStatus.Selected:
                    Debug.Log(slot.itemStatus);
                    break;
            }
        }
    }
}

