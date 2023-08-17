using Services.Economic;
using System.Collections.Generic;
using UnityEngine;
namespace Shop
{
    public abstract class ShopItemSeller<T> where T: ISold
    {
        protected IItemPlace _itemPlace;

        protected List<ShopSlot<T>> _items = new();
        protected ShopSlot<T> _selectedSlot;

        public ShopItemSeller(IReadOnlyDictionary<T, ItemStatus> itemsToSell, IItemPlace itemPlace)
        {
            _itemPlace = itemPlace;
            foreach(KeyValuePair<T, ItemStatus> item in itemsToSell) 
            {
                ShopSlot<T> newSlot = new ShopSlot<T>(item.Key, item.Value);
                newSlot.OnSlotClicked += ClickOnSlot;
                _items.Add(newSlot);
                if (newSlot.itemStatus == ItemStatus.Selected) 
                {
                    _selectedSlot = newSlot;
                }
            }
        }

        protected abstract void ClickOnSlot(ShopSlot<T> slot);

        public void Show() 
        {
            _itemPlace.PlaceItems(_items);
        }

        protected void Select(ShopSlot<T> slot) 
        {
            if (_items.Contains(slot)) 
            {
                _selectedSlot.ChangeStatus(ItemStatus.Open);
                slot.ChangeStatus(ItemStatus.Selected);
            }
        }

        protected void Open(ShopSlot<T> slot) 
        {
            if (_items.Contains(slot))
            {
                slot.ChangeStatus(ItemStatus.Open);
            }
        }
    }
}
