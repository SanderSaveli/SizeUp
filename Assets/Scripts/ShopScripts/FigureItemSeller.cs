using Services;
using Services.Economic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewElements;

namespace Shop 
{
    public class FigureItemSeller : ShopItemSeller<Figure>
    {
        private IFigureService _figureService;
        public FigureItemSeller(IItemPlace itemPlace) : base(ServiceLockator.instance.GetService<IFigureService>().figures, itemPlace)
        {
            _figureService = ServiceLockator.instance.GetService<IFigureService>();
        }

        protected override void ClickOnSlot(ShopSlot<Figure> slot)
        {
            switch (slot.itemStatus)
            {
                case ItemStatus.Close:
                    if (_figureService.OpenFigure(slot._item))
                    {
                        Open(slot);
                    }
                    break;
                case ItemStatus.Open:
                    if (_figureService.SelectFigure(slot._item))
                    {
                        Select(slot);
                    }
                    break;
                case ItemStatus.Selected:
                    break;
            }
        }
    }

}
