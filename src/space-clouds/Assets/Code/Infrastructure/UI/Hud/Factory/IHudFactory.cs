using Code.Infrastructure.UI.Menu;

namespace Code.Infrastructure.UI.Hud.Factory
{
    public interface IHudFactory
    {
        HudView CreateHud();
        MenuView CreateMenu();
    }
}