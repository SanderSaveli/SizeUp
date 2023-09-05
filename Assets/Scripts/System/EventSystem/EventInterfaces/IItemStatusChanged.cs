using Shop;

namespace EventBusSystem
{
    public interface IItemStatusChanged : IGlobalSubscriber
    {
        public void ItemBought(IShopSlot shopSlot);
        public void ItemSelected(IShopSlot shopSlot);
    }
}

