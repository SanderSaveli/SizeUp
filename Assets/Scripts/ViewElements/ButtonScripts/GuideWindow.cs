using UnityEngine;
using UnityEngine.EventSystems;

namespace ViewElements
{
    public class GuideWindow : MonoBehaviour, IPointerClickHandler
    {
        public delegate void PointerClick();
        public event PointerClick OnPointerClick;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            OnPointerClick?.Invoke();
        }
    }

}