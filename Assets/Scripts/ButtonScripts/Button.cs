using UnityEngine;
using ViewElements;

namespace ViewElements.Button 
{
    public abstract class Button : MonoBehaviour
    {
        private ButtonView _buttonVisual;

        public abstract void Click();

        private void Awake()
        {
            _buttonVisual = GetComponentInChildren<ButtonView>();
            if (_buttonVisual == null)
            {
                Debug.LogWarning("There is no view in button");
            }
        }

        public virtual void Show()
        {
            _buttonVisual.Show();
        }
        public virtual void Hide()
        {

            _buttonVisual.Hide();
        }
    }
}

