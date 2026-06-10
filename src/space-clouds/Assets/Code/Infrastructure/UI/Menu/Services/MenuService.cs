using Code.Gameplay.Features.Hero.Config;
using Code.Gameplay.GameCycle.Services;
using Code.Infrastructure.UI.Audio;
using Code.Infrastructure.UI.Hud.Services;
using UnityEngine;

namespace Code.Infrastructure.UI.Menu.Services
{
    public class MenuService : IMenuService
    {
        private readonly MenuView _view;
        private readonly IAudioService _audioService;
        private readonly GameContext _gameContext;
        private readonly IHudService _hudService;

        private readonly IInitialPointService _initialPointService;
        private readonly HeroConfig _heroConfig;

        public MenuService(GameContext gameContext, MenuView view, IAudioService audioService, 
            IHudService hudService, HeroConfig heroConfig, IInitialPointService initialPointService)
        {
            _gameContext = gameContext;
            _view = view;
            _audioService = audioService;
            _hudService = hudService;
            _heroConfig = heroConfig;
            _initialPointService = initialPointService;

            _view.PlayButton.onClick.AddListener(OnPlayClicked);
            _view.SettingsButton.onClick.AddListener(OnSettingsClicked);
            _view.BackButton.onClick.AddListener(OnBackClicked);
            _view.TryAgainButton.onClick.AddListener(OnTryAgainClicked);
            _view.QuitButton.onClick.AddListener(OnQuitClicked);
            _view.VolumeSlider.onValueChanged.AddListener(OnVolumeChanged);
            _view.VolumeSlider.value = _audioService.Volume;

            _view.MainMenu.SetActive(true);
            _view.SettingsPanel.SetActive(false);
            _view.DefeatPanel.SetActive(false);
            _hudService.HideHud();

            Time.timeScale = 0f;
        }

        private void OnPlayClicked()
        {
            RestartGame();
            _hudService.ShowHud();
            _view.MainMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        private void OnTryAgainClicked()
        {
            RestartGame();
            _hudService.ShowHud();
            _view.DefeatPanel.SetActive(false);
            Time.timeScale = 1f;
        }

        private void OnQuitClicked()
        {
            RestartGame();
            _view.DefeatPanel.SetActive(false);
            ShowMainMenu();
        }

        private void OnSettingsClicked()
        {
            _view.MainMenu.SetActive(false);
            ShowSettings();
        }

        private void OnBackClicked()
        {
            HideSettings();
            _view.MainMenu.SetActive(true);
        }

        private void OnVolumeChanged(float value) =>
            _audioService.Volume = value;

        public void ShowMainMenu()
        {
            _hudService.HideHud();
            _view.MainMenu.SetActive(true);
            _view.DefeatPanel.SetActive(false);
            Time.timeScale = 0f;
        }

        public void ShowDefeat()
        {
            Debug.Log($"ShowDefeat called, DefeatPanel active: {_view.DefeatPanel.activeSelf}");
            if (_view.DefeatPanel.activeSelf)
                return;
            _view.DefeatPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void ShowSettings() =>
            _view.SettingsPanel.SetActive(true);

        public void HideSettings() =>
            _view.SettingsPanel.SetActive(false);

        private void RestartGame()
        {
            foreach (GameEntity cloud in _gameContext.GetGroup(GameMatcher.Cloud).GetEntities())
            {
                if (cloud.hasTransform)
                    Object.Destroy(cloud.Transform.gameObject);
                cloud.Destroy();
            }

            foreach (GameEntity star in _gameContext.GetGroup(GameMatcher.Star).GetEntities())
            {
                if (star.hasTransform)
                    Object.Destroy(star.Transform.gameObject);
                star.Destroy();
            }
            
            foreach (GameEntity umbrella in _gameContext.GetGroup(GameMatcher.UmbrellaPickup).GetEntities())
            {
                if (umbrella.hasTransform)
                    Object.Destroy(umbrella.Transform.gameObject);
                umbrella.Destroy();
            }

            foreach (GameEntity tailwind in _gameContext.GetGroup(GameMatcher.TailwindPickup).GetEntities())
            {
                if (tailwind.hasTransform)
                    Object.Destroy(tailwind.Transform.gameObject);
                tailwind.Destroy();
            }

            foreach (GameEntity hero in _gameContext.GetGroup(GameMatcher.Hero).GetEntities())
            {
                hero.ReplaceScore(0);
                hero.ReplaceHealth(_heroConfig.InitialHealth);
                hero.ReplaceWorldPosition(_initialPointService.GetInitialPoint());

                if (hero.isUmbrellaActive)
                {
                    hero.isUmbrellaActive = false;
                    if (hero.hasUmbrellaCircle)
                        hero.UmbrellaCircle.SetActive(false);
                    if (hero.hasUmbrellaBuffDuration)
                        hero.RemoveUmbrellaBuffDuration();
                }

                if (hero.isTailwindActive)
                {
                    hero.isTailwindActive = false;
                    if (hero.hasTailwindBuffDuration)
                        hero.RemoveTailwindBuffDuration();
                    hero.ReplaceSpeed(_heroConfig.InitialSpeed);
                }
            }

            _hudService.UpdateHealth(_heroConfig.InitialHealth);
            _hudService.HideUmbrellaBuff();
            _hudService.HideTailwindBuff();
        }
    }
}