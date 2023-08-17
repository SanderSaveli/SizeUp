using System.Collections.Generic;
using UnityEngine;

namespace ViewElements
{
    public class TongleSwitcher : MonoBehaviour
    {
        private List<ITongue> _tongues = new();
        private ITongue _selecktedTongue = null;

        public void AddTongle(ITongue tongue)
        {
            _tongues.Add(tongue);
            tongue.OnClick += CheckTongue;
        }

        private void CheckTongue(ITongue tongue)
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

