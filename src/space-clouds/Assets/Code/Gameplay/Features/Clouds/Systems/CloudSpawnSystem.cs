using Code.Common;
using Code.Common.Cameras;
using Code.Gameplay.Features.Clouds.Configs;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.Wind.Service;
using Code.Infrastructure.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Clouds.Systems
{
    public class CloudSpawnSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spawners;
        private readonly IGroup<GameEntity> _clouds;
        private readonly ICameraProvider _cameraProvider;
        private readonly IWindService _windService;
        private readonly ICloudSpawnService _cloudSpawnService;
        private readonly CloudConfig _config;

        public CloudSpawnSystem(GameContext gameContext, ICloudSpawnService cloudSpawnService, ICameraProvider cameraProvider, IWindService windService, CloudConfig config)
        {
            _cloudSpawnService = cloudSpawnService;
            _cameraProvider = cameraProvider;
            _windService = windService;
            _config = config;
            
            _spawners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CloudSpawner,
                    GameMatcher.SpawnInternal,
                    GameMatcher.SpawnTimer));
            
            _clouds =  gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Cloud));
        }

        public void Execute()
        {
            foreach (GameEntity spawner in _spawners)
            {
                spawner.ReplaceSpawnTimer(spawner.SpawnTimer - Time.deltaTime);

                if (spawner.SpawnTimer <= 0)
                {
                    if(CanSpawnCloud())
                        _cloudSpawnService.SpawnCloud(SpawnHelper.RandomTopPosition(_cameraProvider));
                    float interval = Mathf.Max(_config.MinSpawnInterval, spawner.SpawnInternal / _windService.GetSpeedMultiplier());
                    spawner.ReplaceSpawnTimer(interval);
                }
            }
        }
        
        private bool CanSpawnCloud()
        {
            float spawnY = _cameraProvider.WorldScreenHeight / 2f + 1f;

            foreach (GameEntity cloud in _clouds)
            {
                if (Mathf.Abs(cloud.WorldPosition.y - spawnY) <  _config.MinDistance)
                    return false;
            }
            return true;
        }
    }
}