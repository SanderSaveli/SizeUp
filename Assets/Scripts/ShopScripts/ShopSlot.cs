using Services.Economic;

public class ShopSlot<T> where T : ISold
{
    public delegate void SlotClicked(T item);
    public event SlotClicked OnSlotClicked;
    public T item { get; private set; }
    public ItemStatus itemStatus { get; private set; }

    public void Activate(T item, ItemStatus itemStatus) 
    {
        
    }

}
