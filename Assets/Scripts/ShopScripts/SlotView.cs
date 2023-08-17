using Services.Economic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Shop
{
    public class SlotView : MonoBehaviour, IShopSlotView, IPointerClickHandler
    {
        [SerializeField] private Image _portrait;
        [SerializeField] private Image _status;
        [SerializeField] private TMP_Text _price;

        [SerializeField] private Sprite _selectStatusImage;
        [SerializeField] private Sprite _closeStatusImage;

        private IShopSlot _slot;
        private bool _isActive = true;

         public void SetNewItem(IShopSlot slot)
        {
            _slot = slot;
            _portrait.sprite = slot.item.potrait;
            ChangeStatus(slot.itemStatus);
            slot.OnStatusChanged += ChangeStatus;

            if(slot.itemStatus == ItemStatus.Close) 
            {
                ShowPrice();
            }
            else 
            { 
                HidePrice();
            }
        }

        private void ChangeStatus(ItemStatus status)
        {
            switch (status)
            {
                case ItemStatus.Close:
                    _status.color += Color.white;
                    _status.sprite = _closeStatusImage;
                    ShowPrice();
                    break;
                case ItemStatus.Open:
                    _status.color = new Color(1, 1, 1, 0);
                    _status.sprite = null;
                    HidePrice();
                    break;
                case ItemStatus.Selected:
                    _status.color = Color.white;
                    _status.sprite = _selectStatusImage;
                    HidePrice();
                    break;
            }
        }

        public void Disable()
        {
            _isActive = false;
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            _isActive = true;
            gameObject.SetActive(true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isActive)
            {
                _slot.ClickOnSlot();
                Debug.Log("Click");
            }
        }

        private void ShowPrice() 
        {
            _price.text = _slot.item.price.ToString();
        }
        private void HidePrice() 
        {
            _price.text = "";
        }
    }
}

