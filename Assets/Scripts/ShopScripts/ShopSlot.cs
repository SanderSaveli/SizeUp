using Services.Economic;
using Shop;
using System;
using UnityEngine;

public class ShopSlot<T> : IShopSlot where T: ISold
{
    public delegate void SlotClicked(ShopSlot<T> slot);
    public event SlotClicked OnSlotClicked;
    public event IShopSlot.StatusChanged OnStatusChanged;

    public T _item { get; private set; }
    public ItemStatus itemStatus { get; private set; }

    ISold IShopSlot.item => _item;

    public ShopSlot(T item, ItemStatus itemStatus)
    {
        _item = item;
        this.itemStatus = itemStatus;
    }

    public void ClickOnSlot()
    {
        OnSlotClicked?.Invoke(this);
    }

    public void ChangeStatus(ItemStatus status)
    {
        itemStatus = status;
        OnStatusChanged?.Invoke(itemStatus);
    }
}
