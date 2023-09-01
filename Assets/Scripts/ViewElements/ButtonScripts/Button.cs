using UnityEngine;

namespace ViewElements.Button
{
    public abstract class Button : MonoBehaviour
    {
        [SerializeField] private ButtonView _buttonVisual;

        public abstract void Click();

        public virtual void Show()
        {
            if (_buttonVisual != null)
            {
                _buttonVisual.Show();
            }
        }
        public virtual void Hide()
        {
            if (_buttonVisual != null)
            {
                _buttonVisual.Hide();
            }
        }
    }
}

