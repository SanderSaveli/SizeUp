using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ViewElements.Button
{
    public abstract class TongueButton : MonoBehaviour, ITongue, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        [field: SerializeField] public bool isAcktive { get; private set; }

        [Space]
        public Image background;
        public Color SwitchOnBGColor;
        public Color SwitchOffBGColor;

        [Space]
        public TMP_Text text;
        public Color SwitchOnTextColor;
        public Color SwitchOffTextColor;

        public event ITongue.Click OnClick;

        public void SwitchOff()
        {
            text.color = SwitchOffTextColor;
            background.color = SwitchOffBGColor;
            isAcktive = false;  
        }

        public void SwitchOn()
        {
            text.color = SwitchOnTextColor;
            background.color = SwitchOnBGColor;
            isAcktive = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick.Invoke(this);
        }

        protected abstract void Click(ITongue tongue);

        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnClick?.Invoke(this);
        }
    }
}
