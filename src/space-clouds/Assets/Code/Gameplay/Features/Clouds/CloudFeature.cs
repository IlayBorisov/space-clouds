using Code.Common.Cameras;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.Clouds.Systems;
using Code.Infrastructure.Factory;

namespace Code.Gameplay.Features.Clouds
{
    public class CloudFeature : Feature
    {
        public CloudFeature(GameContext gameContext, ICloudSpawnService cloudSpawnService, ICameraProvider cameraProvider)
        {
            Add(new SpawnCloudSystem(gameContext, cloudSpawnService, cameraProvider));
            Add(new DestroyCloudBelowScreenSystem(gameContext, cameraProvider));
        }
    }
}