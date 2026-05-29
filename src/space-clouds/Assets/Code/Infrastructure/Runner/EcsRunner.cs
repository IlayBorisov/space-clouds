using Code.Common.Cameras;
using Code.Common.Time;
using Code.Gameplay;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.Input.Service;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Runner
{
    public class EcsRunner : MonoBehaviour
    {
        private GameContext _gameContext;
        private BattleFeature _battleFeature;
        
        private IInputService _inputService;
        private ITimeService _timeService;
        private ICloudSpawnService _cloudSpawnService;
        private ICameraProvider _cameraProvider;

        [Inject]
        private void Construct(GameContext gameContext, ICloudSpawnService cloudSpawnService, ITimeService timeService, IInputService inputService, ICameraProvider cameraProvider)
        {
            _timeService = timeService;
            _gameContext = gameContext;
            _inputService = inputService;
            _cloudSpawnService = cloudSpawnService;
            _cameraProvider = cameraProvider;
        }

        private void Start()
        {
            _battleFeature = new BattleFeature(_gameContext, _cloudSpawnService, _timeService, _inputService, _cameraProvider);
            _battleFeature.Initialize();
        }

        private void Update()
        {
            _battleFeature?.Execute();
            _battleFeature?.Cleanup();
        }

        private void OnDestroy()
        {
            _battleFeature?.TearDown();
        }
    }
}