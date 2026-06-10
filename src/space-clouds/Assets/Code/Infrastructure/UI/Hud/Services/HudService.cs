using UnityEngine;

namespace Code.Infrastructure.UI.Hud.Services
{
    public class HudService : IHudService
    {
        private readonly HudView _view;

        public HudService(HudView view)
        {
            _view = view;
        }

        public void UpdateScore(int score) =>
            _view.ScoreText.text = $"SCORE: {score}";

        public void UpdateHealth(int health)
        {
            for (int i = 0; i < _view.Hearts.Length; i++)
                _view.Hearts[i].gameObject.SetActive(i < health);
        }

        public void SetWindArrowRotation(float angle) =>
            _view.WindArrow.rotation = Quaternion.Euler(0, 0, angle);

        public void SetWindArrowScale(float scale) =>
            _view.WindArrow.localScale = new Vector3(scale, scale, 1f);

        public void ShowUmbrellaBuff(float duration)
        {
            _view.UmbrellaBuffIcon.SetActive(true);
            _view.UmbrellaTimerText.text = $"{Mathf.CeilToInt(duration)}s";
        }

        public void HideUmbrellaBuff() =>
            _view.UmbrellaBuffIcon.SetActive(false);

        public void ShowTailwindBuff(float duration)
        {
            _view.TailwindBuffIcon.SetActive(true);
            _view.TailwindTimerText.text = $"{Mathf.CeilToInt(duration)}s";
        }

        public void HideTailwindBuff() =>
            _view.TailwindBuffIcon.SetActive(false);

        public void ShowHud() =>
            _view.gameObject.SetActive(true);

        public void HideHud() =>
            _view.gameObject.SetActive(false);
    }
}