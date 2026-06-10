using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Features.Buffs.Tailwind.Config;
using Entitas;

namespace Code.Gameplay.Features.Buffs.Tailwind.Systems
{
    public class InitializeTailwindSpawnerSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly TailwindConfig _config;

        public InitializeTailwindSpawnerSystem(GameContext gameContext, TailwindConfig config)
        {
            _gameContext = gameContext;
            _config = config;
        }
        public void Initialize()
        {
            _gameContext.CreateEntity()
                .With(x => x.isTailwindSpawner = true)
                .AddSpawnInternal(_config.SpawnInterval)
                .AddSpawnTimer(_config.SpawnInterval);
        }
    }
}