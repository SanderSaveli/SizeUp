using Services.Economic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class SlotView : MonoBehaviour, IShopSlotView
    {
        public event IShopSlotView.ClickView OnClickView;

        [SerializeField] private Image _portrait;
        [SerializeField] private Image _status;
        [SerializeField] private TMP_Text _price;

        [SerializeField] private Sprite _selectStatusImage;
        [SerializeField] private Sprite _closeStatusImage;

        public void Click()
        {
            OnClickView?.Invoke();
        }

        public void SetNewItem(ISold item, ItemStatus status)
        {
            _price.text = item.price.ToString();
            _portrait.sprite = item.potrait;
            ChangeStatus(status);
        }

        public void ChangeStatus(ItemStatus status)
        {
            switch (status)
            {
                case ItemStatus.Close:
                    _status.color += new Color(0, 0, 0, 1);
                    _status.sprite = _closeStatusImage;
                    break;
                case ItemStatus.Open:
                    _status.color -= new Color(0, 0, 0, 1);
                    _status.sprite = null;
                    break;
                case ItemStatus.Selected:
                    _status.color -= new Color(0, 0, 0, 1);
                    _status.sprite = _selectStatusImage;
                    break;
            }
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
    }
}

