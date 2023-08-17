using Services.Economic;
using System.Collections.Generic;

namespace Shop
{
    public interface IItemPlace
    {
        public IReadOnlyList<IShopSlotView> PlaceItems<T>(List<ShopSlot<T>> items) where T:ISold;
    }
}

