using Code.Common;
using Code.Common.Cameras;
using Code.Gameplay.Features.Buffs.Tailwind.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Tailwind.Systems
{
    public class TailwindSpawnSystem : IExecuteSystem
    {
        private readonly ITailwindFactory _tailwindFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _spawners;

        public TailwindSpawnSystem(GameContext gameContext, ITailwindFactory tailwindFactory, ICameraProvider cameraProvider)
        {
            _tailwindFactory = tailwindFactory;
            _cameraProvider = cameraProvider;
            _spawners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TailwindSpawner,
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
                    _tailwindFactory.CreateTailwind(SpawnHelper.RandomTopPosition(_cameraProvider));
                    spawner.ReplaceSpawnTimer(spawner.SpawnInternal);
                }
            }
        }
    }
}