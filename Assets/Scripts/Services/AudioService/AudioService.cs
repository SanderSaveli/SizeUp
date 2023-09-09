using UnityEngine;
using Services.StorageService;

namespace Services.Audio
{
    public class AudioService : IAudioService
    {
        public bool isSoundOn { get => _isSoundOn; set => TurnOnSounds(value); }
        public bool isAudioOn { get => _isAudioOn; set => TurnOnAudio(value); }

        private bool _isSoundOn;
        private bool _isAudioOn;

        private AudioClip _mainTheme;

        private AudioSource _audioSource;
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
            _audioSource.loop = true;
            GameObject.DontDestroyOnLoad(audioObj);
            _eventCatcher = new AudioEventCatcher(this, _database);
            if (!_storegeService.HasKey(_audioKey)) 
            {
                _storegeService.Save(_audioKey, true);
                _storegeService.Save(_soundKey, true);
            }
            TurnOnSounds(_storegeService.Load<bool>(_soundKey));
            TurnOnAudio(_storegeService.Load<bool>(_audioKey));
        }

        public void Shutdown()
        {
            GameObject.Destroy(_audioSource);
            _eventCatcher = null;
            _isSoundOn = false;
            _isAudioOn = false;
        }

        ~AudioService()
        {
            Shutdown();
        }

        public void ChangeSoundtrack(AudioClip audio)
        {
            _mainTheme = audio;
            if (_isAudioOn) 
            { 
                _audioSource.clip = audio;
                _audioSource.Play();
            }
        }

        public void ChangeVolume(float volume)
        {
            _audioSource.volume = volume;
        }

        public void PlaySound(AudioClip sound)
        {
            if (_isSoundOn) 
            {
                _audioSource.PlayOneShot(sound);
            }
        }

        private void TurnOnSounds(bool isPlay)
        {
            _isSoundOn = isPlay;
            _storegeService.Save(_soundKey, isPlay);
        }

        private void TurnOnAudio(bool isPlay)
        {
            _isAudioOn = isPlay;
            if (isPlay) 
            {
                _audioSource.clip = _mainTheme;
                _audioSource.Play();
            } 
            else 
            {
                _audioSource.Pause();
                _audioSource.clip = null;
            }
            _storegeService.Save(_audioKey, isPlay);
        }
    }

}
