using Code.Infrastructure.Services.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Infrastructure.Services.UI
{
    public class UIService : MonoBehaviour, IUIService
    {
        [SerializeField] private GameObject _hud;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _defeatPanel;
        
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _tryAgainButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private Slider _volumeSlider;
        private IAudioService _audioService;
        private GameContext _gameContext;


        [Inject]
        private void Construct(GameContext gameContext, IAudioService audioService)
        {
            _audioService = audioService;
            _gameContext = gameContext;
        }
        private void OnVolumeChanged(float value) => _audioService.Volume = value;
        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayClicked);
            _settingsButton.onClick.AddListener(OnSettingsClicked);
            _backButton.onClick.AddListener(OnBackClicked);
            _tryAgainButton.onClick.AddListener(OnTryAgainClicked);
            _quitButton.onClick.AddListener(OnQuitClicked);
            _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
            _volumeSlider.value = _audioService.Volume;
            
            _mainMenu.SetActive(true);
            _hud.SetActive(false);
            _settingsPanel.SetActive(false);
            _defeatPanel.SetActive(false);
            
            Time.timeScale = 0f;
        }

        private void OnPlayClicked()
        {
            RestartGame();
            _mainMenu.SetActive(false);
            _hud.SetActive(true);
            Time.timeScale = 1f;
        }

        private void OnTryAgainClicked()
        {
            RestartGame();
            _defeatPanel.SetActive(false);
            _hud.SetActive(true);
            Time.timeScale = 1f;
        }

        private void OnQuitClicked()
        {
            RestartGame();
            _defeatPanel.SetActive(false);
            ShowMainMenu();
        }

        private void OnSettingsClicked()
        {
            _mainMenu.SetActive(false);
            ShowSettings();
        }

        private void OnBackClicked()
        {
            HideSettings();
            _mainMenu.SetActive(true);
        }

        public void ShowHud() => _hud.SetActive(true);
        public void HideHud() => _hud.SetActive(false);
        public void UpdateScore(int score) => _scoreText.text = $"SCORE: {score}";

        public void ShowMainMenu()
        {
            _mainMenu.SetActive(true);
            _hud.SetActive(false);
            _defeatPanel.SetActive(false);
            Time.timeScale = 0f;
        }

        public void ShowDefeat()
        {
            _defeatPanel.SetActive(true);
            _hud.SetActive(false);
            Time.timeScale = 0f;
        }

        public void ShowSettings() => _settingsPanel.SetActive(true);
        public void HideSettings() => _settingsPanel.SetActive(false);
        public void RestartGame()
        {
            foreach (GameEntity cloud in _gameContext.GetGroup(GameMatcher.Cloud).GetEntities())
            {
                if (cloud.hasTransform)
                    Destroy(cloud.Transform.gameObject);
                cloud.Destroy();
            }

            foreach (GameEntity star in _gameContext.GetGroup(GameMatcher.Star).GetEntities())
            {
                if (star.hasTransform)
                    Destroy(star.Transform.gameObject);
                star.Destroy();
            }

            foreach (GameEntity hero in _gameContext.GetGroup(GameMatcher.Hero).GetEntities())
            {
                hero.ReplaceScore(0);
                hero.ReplaceWorldPosition(GetInitialPoint());
                _scoreText.text = "SCORE: 0";
            }
        }
        private Vector3 GetInitialPoint()
        {
            GameObject initialPoint = GameObject.FindWithTag("InitialPoint");
            return initialPoint != null ? initialPoint.transform.position : Vector3.zero;
        }
    }
}