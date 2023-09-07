using Services;
using Services.Audio;
using UnityEngine;

namespace ViewElements.Button
{
    public class SoundButtonView : ButtonView
    {
        [SerializeField] private Sprite onIcon;
        [SerializeField] private Sprite offIcon;
        private new void OnEnable()
        {
            base.OnEnable();
            SoundButton button = transform.parent.GetComponent<SoundButton>();
            button.OnSoundSettingsChanged += ChangeIcon;
            ChangeIcon(ServiceLockator.instance.GetService<IAudioService>().isSoundOn);
        }

        private void ChangeIcon(bool isOn)
        {
            _icon.sprite = isOn ? onIcon : offIcon;
        }
    }
}

