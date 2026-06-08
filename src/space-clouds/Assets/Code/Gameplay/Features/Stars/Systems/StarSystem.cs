using Code.Common;
using Code.Common.Cameras;
using Code.Gameplay.Features.Stars.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Stars.Systems
{
    public class StarSystem : IExecuteSystem
    {
        private readonly IStarSpawnService _starSpawnService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _spawners;

        public StarSystem(GameContext game, IStarSpawnService starSpawnService, ICameraProvider cameraProvider)
        {
            _starSpawnService = starSpawnService;
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
                    _starSpawnService.SpawnStar(SpawnHelper.RandomTopPosition(_cameraProvider));
                    spawner.ReplaceSpawnTimer(spawner.SpawnInternal);
                }
            }
        }
    }
}