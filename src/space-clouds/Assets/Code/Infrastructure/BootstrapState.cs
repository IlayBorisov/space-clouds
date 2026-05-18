using Code.Services.Input;
using Unity.Android.Gradle.Manifest;
using Application = UnityEngine.Application;

namespace Code.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        public void Enter()
        {
            _sceneLoader.Load(Initial, onLoader: EnterLoadLevel);
        }
        
        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadLevelState, string>("Main");
        
        public void Exit()
        {
        }
    }
}