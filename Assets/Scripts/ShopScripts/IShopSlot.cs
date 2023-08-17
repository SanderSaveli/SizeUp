using Services.Economic;

namespace Shop
{
    public interface IShopSlot
    {
        public delegate void StatusChanged(ItemStatus newStatus);
        public event StatusChanged OnStatusChanged;
        public ISold item { get; }
        public ItemStatus itemStatus { get; }
        public void ClickOnSlot();

        public void ChangeStatus(ItemStatus status);
    }
}

