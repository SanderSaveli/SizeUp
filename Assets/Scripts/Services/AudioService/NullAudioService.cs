using UnityEngine;
namespace Services.Audio
{
    public class NullAudioService : IAudioService
    {
        public void ChangeSoundtrack()
        { }

        public void ChangeSoundtrack(AudioClip audio)
        { }

        public void ChangeVolume(float volume)
        { }

        public void Initialize()
        { }

        public void PlaySound(AudioClip sound)
        { }

        public void Shutdown()
        { }

        public void TurnOnAudio(bool isPlay)
        { }

        public void TurnOnSounds(bool isPlay)
        { }
    }
}
