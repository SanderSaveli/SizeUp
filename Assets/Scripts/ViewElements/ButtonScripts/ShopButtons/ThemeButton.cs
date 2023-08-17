using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ViewElements.Button
{
    public class ThemeButton : MonoBehaviour, ITongue, IPointerClickHandler
    {
        public TongleSwitcher tongleSwitcher;

        [Space]
        public Image background;
        public Color SwitchOnBGColor;
        public Color SwitchOffBGColor;

        [Space]
        public TMP_Text text;
        public Color SwitchOnTextColor;
        public Color SwitchOffTextColor;
        public event ITongue.Click OnClick;

        private void OnEnable()
        {
            tongleSwitcher.AddTongle(this);
        }
        public void SwitchOff()
        {
            text.color = SwitchOffTextColor;
            background.color = SwitchOffBGColor;
        }

        public void SwitchOn()
        {
            text.color = SwitchOnTextColor;
            background.color = SwitchOnBGColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(this);
        }
    }
}
