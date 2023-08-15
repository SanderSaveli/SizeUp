using Services.Economic;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ItemPlace : MonoBehaviour, IItemPlace
    {
        [SerializeField] private Transform _itemParent;
        [SerializeField] private SlotView _shopSlot;
        private List<IShopSlotView> _acktiveView = new();
        private Stack<IShopSlotView> _disabledView = new();
        public IReadOnlyList<IShopSlotView> PlaceItems(IReadOnlyDictionary<ISold, ItemStatus> items)
        {
            AckticateSlots(items.Count);
            int i = 0;
            foreach (KeyValuePair<ISold, ItemStatus> item in items)
            {
                _acktiveView[i++].SetNewItem(item.Key, item.Value);
            }
            return _acktiveView;
        }

        private void CreateMoreView(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _acktiveView.Add(Instantiate(_shopSlot, _itemParent));
            }
        }

        private void AckticateSlots(int count)
        {
            if (_acktiveView.Count > count)
            {
                for (int i = _acktiveView.Count - 1; i >= count; i--)
                {
                    IShopSlotView curr = _acktiveView[i];
                    curr.Disable();
                    _acktiveView.Remove(curr);
                    _disabledView.Push(curr);
                }
            }
            else if (_acktiveView.Count < count)
            {
                for (int i = _acktiveView.Count - 1; i < count; i++)
                {
                    if (_disabledView.TryPeek(out IShopSlotView shopSlotView))
                    {
                        shopSlotView.Enable();
                        _acktiveView.Add(shopSlotView);
                    }
                    else
                    {
                        CreateMoreView(count - _acktiveView.Count);
                        break;
                    }
                }
            }
        }
    }
}
