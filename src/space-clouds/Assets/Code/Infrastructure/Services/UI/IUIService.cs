namespace Code.Infrastructure.Services.UI
{
    public interface IUIService
    {
        void ShowHud();
        void HideHud();
        void UpdateScore(int score);
        void ShowMainMenu();
        void ShowDefeat();
        void ShowSettings();
        void HideSettings();
        void RestartGame();
    }
}