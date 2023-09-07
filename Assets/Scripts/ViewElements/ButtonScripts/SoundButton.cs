using Services;
using Services.Audio;
using System;

namespace ViewElements.Button
{
    public class SoundButton : Button, ISettingsMenuButton
    {
        public delegate void SoundSettingsChanged(bool newSettings);
        public event SoundSettingsChanged OnSoundSettingsChanged;
        protected override Type _buttonTupe => typeof(SoundButton);

        private IAudioService _audioService;
        private void OnEnable()
        {
            _audioService = ServiceLockator.instance.GetService<IAudioService>();
        }

        public override void Click()
        {
            base.Click();
            _audioService.isSoundOn = !_audioService.isSoundOn;
            OnSoundSettingsChanged?.Invoke(_audioService.isSoundOn);
        }
    }
}
