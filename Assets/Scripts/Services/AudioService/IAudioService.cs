using UnityEngine;

namespace Services.Audio
{
    public interface IAudioService : IService
    {
        public void ChangeVolume(float volume);
        public void PlaySound(AudioClip sound);
        public void ChangeSoundtrack(AudioClip audio);

        public void TurnOnSounds(bool isPlay);
        public void TurnOnAudio(bool isPlay);

    }
}
