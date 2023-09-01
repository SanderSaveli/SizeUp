using System.Collections.Generic;
using UnityEngine;
using ViewElements.Button;

namespace ViewElements
{
    public class TongleSwitcher : MonoBehaviour
    {
        [SerializeField] private List<TongueButton> _tongues = new();
        private ITongue _selecktedTongue = null;

        private void OnEnable()
        {
            foreach(ITongue tongue in _tongues) 
            {
                tongue.OnClick += CheckTongue;
                if(tongue.isAcktive == true) 
                { 
                    _selecktedTongue=tongue;
                }
            }
        }

        private void CheckTongue(TongueButton tongue)
        {
            if (_tongues.Contains(tongue))
            {
                _selecktedTongue?.SwitchOff();
                _selecktedTongue = tongue;
                tongue.SwitchOn();
            }
        }
    }
}

