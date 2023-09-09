using UnityEngine;

namespace ViewElements.Button
{
    public class SettingsButtonView : ButtonView
    {
        [SerializeField] private AnimationClip _clickOnAnimation;
        [SerializeField] private AnimationClip _clickOffAnimation;
        protected const string _clickOnName = "ClickOn";
        protected const string _clickOffName = "ClickOff";

        private bool _isOn;
        protected new void OnEnable()
        {
            base.OnEnable();
            _animation.AddClip(_clickOnAnimation, _clickOnName);
            _animation.AddClip(_clickOffAnimation, _clickOffName);
            _isOn = false;
            _animation.Play();
        }

        public void Click()
        {
            _isOn = !_isOn;
            _animation.Play(_isOn ? _clickOnName : _clickOffName);
        }
    }

}
