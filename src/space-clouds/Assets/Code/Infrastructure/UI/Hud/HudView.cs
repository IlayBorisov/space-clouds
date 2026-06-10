using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Infrastructure.UI.Hud
{
    public class HudView : MonoBehaviour
    {
        public TextMeshProUGUI ScoreText;
        public Image[] Hearts;
        public RectTransform WindArrow;
        public GameObject UmbrellaBuffIcon;
        public TextMeshProUGUI UmbrellaTimerText;
        public GameObject TailwindBuffIcon;
        public TextMeshProUGUI TailwindTimerText;
    }
}