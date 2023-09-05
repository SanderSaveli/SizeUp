using EventBusSystem;
using Services.SceneLoad;
using Shop;
using System;
using ViewElements.Button;

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
                _audioService.PlaySound(_menuAudio.ButtonClick);
        }

        public void GameEnd()
        {
            _audioService.PlaySound(_menuAudio.GameEnd);
        }

        public void GameStart()
        {
            _audioService.PlaySound(_menuAudio.GameStart);
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
                _audioService.ChangeSoundtrack(_menuAudio.mainTheme);
            else if (sceneName == SceneNames.Shop)
                _audioService.ChangeSoundtrack(_shopAudio.mainShopTheme);
        }
    }
}

