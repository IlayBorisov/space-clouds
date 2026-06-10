using Code.Gameplay.Features.Input.Service;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Runner;
using Code.Infrastructure.Systems;
using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Hud;
using Code.Infrastructure.UI.Hud.Services;
using Code.Infrastructure.UI.Menu;
using Code.Infrastructure.UI.Menu.Services;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
            BindEcsRunner();
            BindUI();
            BindSystems();
        }

        private void BindInput()
        {
#if UNITY_IOS || UNITY_ADNROID //UNITY_EDITOR UNITY_IOS
            Container.Bind<IInputService>().To<SwipeInputService>().AsSingle();
#else //UNITY_EDITOR
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
#endif
        }

        private void BindEcsRunner()
        {
            Container.Bind<EcsRunner>().FromComponentInHierarchy().AsSingle();
        }
        
        private void BindSystems()
        {
            Container.Bind<ISystemsFactory>().To<SystemsFactory>().AsSingle();
        }
        
        private void BindUI()
        {
            Container.Bind<HudView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<MenuView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IHudService>().To<HudService>().AsSingle();
            Container.Bind<IMenuService>().To<MenuService>().AsSingle();
        }
    }
}