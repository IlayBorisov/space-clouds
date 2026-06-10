namespace Code.Infrastructure.UI.Hud.Services
{
    public interface IHudService
    {
        void UpdateScore(int score);
        void UpdateHealth(int health);
        void SetWindArrowRotation(float angle);
        void SetWindArrowScale(float scale);
        void ShowUmbrellaBuff(float duration);
        void HideUmbrellaBuff();
        void ShowTailwindBuff(float duration);
        void HideTailwindBuff();
        void ShowHud();
        void HideHud();
    }
}