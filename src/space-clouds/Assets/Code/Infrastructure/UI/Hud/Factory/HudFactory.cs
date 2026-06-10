using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.UI.Menu;

namespace Code.Infrastructure.UI.Hud.Factory
{
    public class HudFactory : IHudFactory
    {
        private readonly IAssets _assets;

        public HudFactory(IAssets assets)
        {
            _assets = assets;
        }

        public HudView CreateHud()
        {
            var hud = _assets.Instantiate(AssetPath.HudPath);
            return hud.GetComponent<HudView>();
        }

        public MenuView CreateMenu()
        {
            var menu = _assets.Instantiate(AssetPath.HudPath);
            return menu.GetComponent<MenuView>();
        }
    }
}