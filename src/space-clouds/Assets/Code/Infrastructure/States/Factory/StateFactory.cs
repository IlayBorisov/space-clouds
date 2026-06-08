using Zenject;

namespace Code.Infrastructure.States.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container)
        {
            _container = container;
        }

        public TState GetState<TState>() where TState : IState => _container.Resolve<TState>();
    }
}