using System;
using UnityEngine;
using EventBusSystem;

namespace ViewElements.Button
{
    public abstract class Button : MonoBehaviour
    {
        [SerializeField] private ButtonView _buttonVisual;
        protected abstract Type _buttonTupe {get;} 

        public virtual void Click() 
        {
            EventBus.RaiseEvent<IButtonClickHandler>(it => it.ButtonClicked(_buttonTupe));
        }

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

