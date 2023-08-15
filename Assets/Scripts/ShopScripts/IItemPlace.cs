using Services.Economic;
using System.Collections.Generic;

namespace Shop
{
    public interface IItemPlace
    {
        public IReadOnlyList<IShopSlotView> PlaceItems(IReadOnlyDictionary<ISold, ItemStatus> items);
    }
}

