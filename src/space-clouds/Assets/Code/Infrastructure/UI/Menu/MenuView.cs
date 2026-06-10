using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Infrastructure.UI.Menu
{
    public class MenuView : MonoBehaviour
    {
        public GameObject MainMenu;
        public GameObject SettingsPanel;
        public GameObject DefeatPanel;
        public Button PlayButton;
        public Button SettingsButton;
        public Button BackButton;
        public Button TryAgainButton;
        public Button QuitButton;
        public Slider VolumeSlider;
        public TextMeshProUGUI DefeatScoreText;
    }
}