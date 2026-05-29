using Code.Infrastructure.Runner;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameBootstrapper>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}