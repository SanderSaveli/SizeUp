using Services.Economic;
namespace Shop
{
    public interface IShopSlotView
    {
        public delegate void ClickView();
        public event ClickView OnClickView;

        public void SetNewItem(ISold item, ItemStatus status);
        public void ChangeStatus(ItemStatus status);
        public void Disable();
        public void Enable();
    }
}

