using Code.Infrastructure.Runner;
using Zenject;

namespace Code.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string MainScene = "Main";

        private readonly SceneLoader _sceneLoader;
        private IGameStateMachine _stateMachine;

        [Inject]
        public BootstrapState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Initialize(IGameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        public void Enter() =>
            _sceneLoader.Load(Initial, onLoader: EnterLoadLevel);

        public void Exit() { }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(MainScene);
        }
    }
}