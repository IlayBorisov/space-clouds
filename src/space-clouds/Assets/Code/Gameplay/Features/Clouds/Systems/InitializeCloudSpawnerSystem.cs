using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Features.Clouds.Configs;
using Entitas;

namespace Code.Gameplay.Features.Clouds.Systems
{
    public class InitializeCloudSpawnerSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly CloudConfig _config;

        public InitializeCloudSpawnerSystem(GameContext gameContext, CloudConfig config)
        {
            _gameContext = gameContext;
            _config = config;
        }

        public void Initialize()
        {
            _gameContext.CreateEntity()
                .With(x => x.isCloudSpawner = true)
                .AddSpawnInternal(_config.SpawnInterval)
                .AddSpawnTimer(0f);
        }
    }
}