using Code.Common.Cameras;
using Code.Common.Collisions;
using Code.Common.Time;
using Code.Gameplay;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.Input.Service;
using Code.Gameplay.Features.Stars.Service;
using Code.Gameplay.Features.Wind.Service;
using Code.Infrastructure.Services.UI;
using Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Runner
{
    public class EcsRunner : MonoBehaviour
    {
        private GameContext _gameContext;
        private GameFeature _gameFeature;
        
        private IInputService _inputService;
        private ITimeService _timeService;
        private ICloudSpawnService _cloudSpawnService;
        private ICameraProvider _cameraProvider;
        private ICollisionRegistry _collisionRegistry;
        private IStarSpawnService _starSpawnService;
        private IUIService _uiService;
        private IWindService _windService;

        [Inject]
        private void Construct(GameContext gameContext, 
            ICloudSpawnService cloudSpawnService,
            ITimeService timeService,
            IInputService inputService,
            ICameraProvider cameraProvider,
            ICollisionRegistry collisionRegistry, 
            IStarSpawnService starSpawnService, 
            IUIService uiService,
            IWindService windService)
        {
            _timeService = timeService;
            _gameContext = gameContext;
            _inputService = inputService;
            _cloudSpawnService = cloudSpawnService;
            _cameraProvider = cameraProvider;
            _collisionRegistry = collisionRegistry;
            _starSpawnService = starSpawnService;
            _uiService = uiService;
            _windService = windService;
        }

        private void Start()
        {
            _gameFeature = new GameFeature(_gameContext,
                _cloudSpawnService,
                _timeService,
                _inputService,
                _cameraProvider,
                _collisionRegistry,
                _starSpawnService, 
                _uiService,
                _windService);
            _gameFeature.Initialize();
        }

        private void Update()
        {
            _gameFeature?.Execute();
            _gameFeature?.Cleanup();
        }

        private void OnDestroy()
        {
            _gameFeature?.TearDown();
        }
    }
}