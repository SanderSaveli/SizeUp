namespace Shop
{
    public interface IShopSlotView
    {
        public void SetNewItem(IShopSlot slot);
        public void Disable();
        public void Enable();
    }
}

