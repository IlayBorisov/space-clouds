using Code.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Runner
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private IGameStateMachine  _stateMachine;

        [Inject]
        private void Construct(IGameStateMachine  stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Start()
        {
            _stateMachine.Enter<BootstrapState>();
        }
    }
}
