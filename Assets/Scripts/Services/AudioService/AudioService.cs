using UnityEngine;
using Services.StorageService;

namespace Services.Audio
{
    public class AudioService : IAudioService
    {
        private AudioSource _audioSource;
        private bool _playSounds;
        private bool _playAudio;
        private AudioDatabase _database;
        private AudioEventCatcher _eventCatcher;

        private IStoregeService _storegeService;
        private const string _soundKey = "soundKey";
        private const string _audioKey = "audioKey";

        public AudioService(AudioDatabase audioDatabase, IStoregeService storegeService) 
        { 
            _database = audioDatabase;
            _storegeService = storegeService;
        }
        public void Initialize()
        {
            GameObject audioObj = new GameObject("Audio");
            _audioSource = audioObj.AddComponent<AudioSource>();
            GameObject.DontDestroyOnLoad(audioObj);
            _eventCatcher = new AudioEventCatcher(this, _database);
            if (!_storegeService.HasKey(_audioKey)) 
            {
                _storegeService.Save(_audioKey, true);
                _storegeService.Save(_soundKey, true);
            }
            _playSounds = _storegeService.Load<bool>(_soundKey);
            _playAudio = _storegeService.Load<bool>(_audioKey);
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
