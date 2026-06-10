using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Features.Buffs.Umbrella.Config;
using Entitas;

namespace Code.Gameplay.Features.Buffs.Umbrella.Systems
{
    public class InitializeUmbrellaSpawnerSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly UmbrellaConfig _config;

        public InitializeUmbrellaSpawnerSystem(GameContext gameContext, UmbrellaConfig config)
        {
            _gameContext = gameContext;
            _config = config;
        }

        public void Initialize()
        {
            _gameContext.CreateEntity()
                .With(x => x.isUmbrellaSpawner = true)
                .AddSpawnInternal(_config.SpawnInterval)
                .AddSpawnTimer(_config.SpawnInterval);
        }
    }
}