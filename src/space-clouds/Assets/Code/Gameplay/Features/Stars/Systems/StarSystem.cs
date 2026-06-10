using Code.Common;
using Code.Common.Cameras;
using Code.Gameplay.Features.Stars.Configs;
using Code.Gameplay.Features.Stars.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Stars.Systems
{
    public class StarSystem : IExecuteSystem
    {
        private readonly IStarFactory _starFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _spawners;
        private readonly StarConfig _config;

        public StarSystem(GameContext game, IStarFactory starFactory, ICameraProvider cameraProvider, StarConfig config)
        {
            _config = config;
            _starFactory = starFactory;
            _cameraProvider = cameraProvider;
            _spawners = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.StarSpawner,
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
                    _starFactory.CreateStar(SpawnHelper.RandomTopPosition(_cameraProvider));
                    spawner.ReplaceSpawnTimer(_config.SpawnInterval);
                }
            }
        }
    }
}