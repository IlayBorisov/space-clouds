using Entitas;
using Zenject;

namespace Code.Infrastructure.Systems
{
    public class SystemsFactory : ISystemsFactory
    {
        private readonly DiContainer _container;

        public SystemsFactory(DiContainer container)
        {
            _container = container;
        }

        public TSystem Create<TSystem>() where TSystem : ISystem =>
            _container.Instantiate<TSystem>();

        public TSystem Create<TSystem>(params object[] args) where TSystem : ISystem =>
            _container.Instantiate<TSystem>(args);
    }
}