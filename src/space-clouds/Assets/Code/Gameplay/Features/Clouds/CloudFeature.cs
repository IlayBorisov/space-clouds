using Code.Common.Cameras;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.Clouds.Systems;
using Code.Gameplay.Features.Wind.Service;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Clouds
{
    public class CloudFeature : Feature
    {
        public CloudFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeCloudSpawnerSystem>());
            Add(systems.Create<CloudSpawnSystem>());
        }
    }
}