using Code.Common.Cameras;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Runner;
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
        private readonly ICameraProvider _cameraProvider;

        [Inject]
        public LoadLevelState(SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory, ICameraProvider cameraProvider)
        {
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _cameraProvider = cameraProvider;
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
            RegisterCamera();

            _gameFactory.CreateAudioManager();
            _gameFactory.CreateHero(at: GameObject.FindWithTag(InitialPointTag));
            _gameFactory.CreateHud();
            _gameFactory.CreateCloudSpawner();
            _gameFactory.CreateStarSpawner();

            _stateMachine.Enter<GameLoopState>();
        }
        
        private void RegisterCamera()
        {
            _cameraProvider.SetMainCamera(Camera.main);
        }
    }
}