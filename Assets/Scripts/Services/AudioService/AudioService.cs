using UnityEngine;

namespace Services.Audio
{
    public class AudioService : IAudioService
    {
        private AudioSource _audioSource;
        private bool _playSounds;
        private bool _playAudio;
        private AudioDatabase _database;
        private AudioEventCatcher _eventCatcher;

        public AudioService(AudioDatabase audioDatabase) 
        { 
            _database = audioDatabase;
        }
        public void Initialize()
        {
            GameObject audioObj = new GameObject("Audio");
            _audioSource = audioObj.AddComponent<AudioSource>();
            GameObject.DontDestroyOnLoad(audioObj);
            _eventCatcher = new AudioEventCatcher(this, _database);
            _playSounds = true;
            _playAudio = true;
        }

        public void Shutdown()
        {
            GameObject.Destroy(_audioSource);
            _eventCatcher = null;
            _playSounds = false;
            _playAudio = false;
        }

        ~AudioService()
        {
            Shutdown();
        }

        public void ChangeSoundtrack(AudioClip audio)
        {
            _audioSource.clip = audio;
            if(_playAudio)
                _audioSource.Play();
        }

        public void ChangeVolume(float volume)
        {
            _audioSource.volume = volume;
        }

        public void PlaySound(AudioClip sound)
        {
            if (_playSounds) 
            {
                _audioSource.PlayOneShot(sound);
            }
        }

        public void TurnOnSounds(bool isPlay)
        {
            _playAudio = isPlay;
        }

        public void TurnOnAudio(bool isPlay)
        {
            _playSounds = isPlay;
            if (isPlay)
                _audioSource.Play();
            else 
                _audioSource.Stop();
        }
    }

}
