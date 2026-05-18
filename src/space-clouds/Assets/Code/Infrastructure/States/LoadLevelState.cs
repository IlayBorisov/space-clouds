using Code.Infrastructure.Factory;
using Code.Logic;
using UnityEngine;

namespace Code.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Exit() => 
            _curtain.Hide();

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            _gameFactory.CreateHero(at: GameObject.FindWithTag(InitialPointTag));
            _gameFactory.CreateHud();
            
            _stateMachine.Enter<GameLoopState>();
        }
    }
}