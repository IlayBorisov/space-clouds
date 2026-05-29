using Code.Common.Cameras;
using Code.Gameplay.Features.Clouds.Components;
using Code.Gameplay.Features.Clouds.Service;
using Code.Infrastructure.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Clouds.Systems
{
    public class SpawnCloudSystem : IExecuteSystem
    {
        private readonly IGameFactory _gameFactory;
        private readonly IGroup<GameEntity> _spawners;
        private readonly ICameraProvider _cameraProvider;
        private readonly ICloudSpawnService _cloudSpawnService;

        public SpawnCloudSystem(GameContext gameContext, ICloudSpawnService cloudSpawnService, ICameraProvider cameraProvider)
        {
            _cloudSpawnService = cloudSpawnService;
            _cameraProvider = cameraProvider;
            _spawners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CloudSpawner,
                    GameMatcher.SpawnInternal,
                    GameMatcher.SpawnTimer));
        }

        public void Execute()
        {
            foreach (GameEntity spawner in _spawners)
            {
                spawner.ReplaceSpawnTimer(spawner.SpawnTimer - Time.deltaTime);

                if (spawner.SpawnTimer <= 0)
                {
                    SpawnCloud();
                    spawner.ReplaceSpawnTimer(spawner.SpawnInternal);
                }
            }
        }
        
        private void SpawnCloud()
        {
            float halfWidth = _cameraProvider.WorldScreenWidth / 2f;
            float randomX = Random.Range(-halfWidth, halfWidth);
            float spawnY = _cameraProvider.WorldScreenHeight / 2f + 1f;

            _cloudSpawnService.SpawnCloud(new Vector2(randomX, spawnY));
        }
    }
}