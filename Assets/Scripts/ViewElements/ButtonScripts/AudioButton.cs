using Services;
using Services.Audio;
using System;

namespace ViewElements.Button
{
    public class AudioButton : Button, ISettingsMenuButton
    {
        public delegate void AudioSettingsChanged(bool newSettings);
        public event AudioSettingsChanged OnAudioSettingsChanged;
        protected override Type _buttonTupe => typeof(SoundButton);

        private IAudioService _audioService;
        private void OnEnable()
        {
            _audioService = ServiceLockator.instance.GetService<IAudioService>();
        }

        public override void Click()
        {
            base.Click();
            _audioService.isAudioOn = !_audioService.isAudioOn;
            OnAudioSettingsChanged?.Invoke(_audioService.isAudioOn);
        }
    }
}

