using Code.Gameplay.Features.Input.Service;
using Code.Infrastructure.Runner;
using Code.Infrastructure.Services.UI;
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
        }

        private void BindInput()
        {
#if UNITY_EDITOR //UNITY_EDITOR UNITY_IOS
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
#else
            Container.Bind<IInputService>().To<SwipeInputService>().AsSingle();
#endif
        }

        private void BindEcsRunner()
        {
            Container.Bind<EcsRunner>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
        
        private void BindUI()
        {
            Container.Bind<IUIService>()
                .To<UIService>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}