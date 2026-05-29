using Code.Infrastructure.Factory;
using Code.Infrastructure.Runner;
using Code.Logic;
using Code.Logic.Curtain;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private IGameStateMachine _stateMachine;

        [Inject]
        public LoadLevelState(SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory)
        {
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
        }

        public void Initialize(IGameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _curtain.Hide();

        private void OnLoaded()
        {
            _gameFactory.CreateHero(at: GameObject.FindWithTag(InitialPointTag));
            _gameFactory.CreateHud();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}