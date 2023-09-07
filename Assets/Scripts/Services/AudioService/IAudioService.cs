using UnityEngine;

namespace Services.Audio
{
    public interface IAudioService : IService
    {
        public bool isSoundOn { get; set; }
        public bool isAudioOn { get; set; }
        public void ChangeVolume(float volume);
        public void PlaySound(AudioClip sound);
        public void ChangeSoundtrack(AudioClip audio);
    }
}
