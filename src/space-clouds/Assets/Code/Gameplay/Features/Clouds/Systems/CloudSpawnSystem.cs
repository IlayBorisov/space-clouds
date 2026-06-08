using Code.Common;
using Code.Common.Cameras;
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

        public CloudSpawnSystem(GameContext gameContext, ICloudSpawnService cloudSpawnService, ICameraProvider cameraProvider, IWindService windService)
        {
            _cloudSpawnService = cloudSpawnService;
            _cameraProvider = cameraProvider;
            _windService = windService;
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
                    float interval = Mathf.Max(0.5f, spawner.SpawnInternal / _windService.CloudSpeedMultiplier);
                    spawner.ReplaceSpawnTimer(interval);
                }
            }
        }
        
        private bool CanSpawnCloud()
        {
            float spawnY = _cameraProvider.WorldScreenHeight / 2f + 1f;
            float minDistance = 2f;

            foreach (GameEntity cloud in _clouds)
            {
                if (Mathf.Abs(cloud.WorldPosition.y - spawnY) < minDistance)
                    return false;
            }
            return true;
        }
    }
}