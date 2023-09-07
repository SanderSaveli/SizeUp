using Services;
using Services.Audio;
using UnityEngine;

namespace ViewElements.Button
{
    public class AudioButtonView : ButtonView
    {
        [SerializeField] private Sprite onIcon;
        [SerializeField] private Sprite offIcon;
        protected new void OnEnable()
        {
            base.OnEnable();
            AudioButton button = transform.parent.GetComponent<AudioButton>();
            ChangeIcon(ServiceLockator.instance.GetService<IAudioService>().isAudioOn);
            button.OnAudioSettingsChanged += ChangeIcon;
        }

        private void ChangeIcon(bool isOn)
        {
            _icon.sprite = isOn? onIcon: offIcon;  
        }
    }
}
