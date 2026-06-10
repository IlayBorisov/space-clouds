using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Features.Stars.Configs;
using Entitas;

namespace Code.Gameplay.Features.Stars.Systems
{
    public class InitializeStarSpawnerSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly StarConfig _config;

        public InitializeStarSpawnerSystem(GameContext gameContext, StarConfig config)
        {
            _gameContext = gameContext;
            _config = config;
        }
        public void Initialize()
        {
            _gameContext.CreateEntity()
                .With(x => x.isStarSpawner = true)
                .AddSpawnInternal(_config.SpawnInterval)
                .AddSpawnTimer(0f);
        }
    }
}