using Code.Gameplay.Input.Service;
using Code.Infrastructure.Runner;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
            BindEcsRunner();
        }

        private void BindInput()
        {
#if UNITY_EDITOR //UNITY_EDITOR UNITY_IOS
            Container.Bind<IInputService>().To<SwipeInputService>().AsSingle();
#else
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
#endif
        }

        private void BindEcsRunner()
        {
            Container.Bind<EcsRunner>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}