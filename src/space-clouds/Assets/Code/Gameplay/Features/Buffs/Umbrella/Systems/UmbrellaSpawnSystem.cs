using Code.Common;
using Code.Common.Cameras;
using Code.Gameplay.Features.Buffs.Umbrella.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Umbrella.Systems
{
    public class UmbrellaSpawnSystem : IExecuteSystem
    {
        private readonly IUmbrellaSpawnService _umbrellaSpawnService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _spawners;

        public UmbrellaSpawnSystem(GameContext gameContext, IUmbrellaSpawnService umbrellaSpawnService, ICameraProvider cameraProvider)
        {
            _umbrellaSpawnService = umbrellaSpawnService;
            _cameraProvider = cameraProvider;
            _spawners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.UmbrellaSpawner,
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
                    _umbrellaSpawnService.SpawnUmbrella(SpawnHelper.RandomTopPosition(_cameraProvider));
                    spawner.ReplaceSpawnTimer(spawner.SpawnInternal);
                }
            }
        }
    }
}