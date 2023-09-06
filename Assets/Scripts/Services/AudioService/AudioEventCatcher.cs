using EventBusSystem;
using Services.SceneLoad;
using Shop;
using System;
using ViewElements.Button;
using ViewElements;
using Services.Economic;

namespace Services.Audio
{
    public class AudioEventCatcher : IGameEndHandler, IGameSartHandler, IBackToMenuHandler, IButtonClickHandler, ISceneChangedHandler, IItemStatusChanged
    {
        private MainMenuAudio _menuAudio;
        private ShopAudio _shopAudio;
        private IAudioService _audioService;

        public AudioEventCatcher(IAudioService audioService, AudioDatabase audioDatabase)
        {
            _audioService = audioService;
            _menuAudio = audioDatabase.menuAudio;
            _shopAudio = audioDatabase.shopAudio;
            EventBus.Subscribe(this);
        }

        public void BackToMenu()
        {
            _audioService.ChangeSoundtrack(_menuAudio.mainTheme);
        }

        public void ButtonClicked(Type butttonType)
        {
            if (butttonType == typeof(PlayButton) || butttonType == typeof(RestartButton))
            { }
            else if (butttonType == typeof(ShopButton))
                _audioService.PlaySound(_shopAudio.shopOpen);
            else if (butttonType == typeof(TongueButton))
                _audioService.PlaySound(_shopAudio.changeTongue);
            else
                _audioService.PlaySound(_menuAudio.buttonClick);
        }

        public void GameEnd()
        {
            _audioService.PlaySound(_menuAudio.gameEnd);
            _audioService.ChangeSoundtrack(null);
        }

        public void GameStart()
        {
            _audioService.PlaySound(_menuAudio.gameStart);
            _audioService.ChangeSoundtrack(_menuAudio.mainTheme);
        }

        public void ItemBought(IShopSlot shopSlot)
        {
            _audioService.PlaySound(_shopAudio.buy);
        }

        public void ItemSelected(IShopSlot shopSlot)
        {
            _audioService.PlaySound(_shopAudio.selection);
        }

        public void SceneChanged(string sceneName)
        {
            if (sceneName == SceneNames.Menu) 
            {
                _menuAudio = ServiceLockator.instance.GetService<IThemeService>().selectedTheme.audio; 
                _audioService.ChangeSoundtrack(_menuAudio.mainTheme);
            }
            else if (sceneName == SceneNames.Shop)
                _audioService.ChangeSoundtrack(_shopAudio.mainShopTheme);
        }
    }
}

