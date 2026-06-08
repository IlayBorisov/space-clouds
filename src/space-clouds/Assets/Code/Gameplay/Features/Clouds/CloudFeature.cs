using Code.Common.Cameras;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.Clouds.Systems;
using Code.Gameplay.Features.Wind.Service;
using Code.Infrastructure.Factory;

namespace Code.Gameplay.Features.Clouds
{
    public class CloudFeature : Feature
    {
        public CloudFeature(GameContext gameContext, ICloudSpawnService cloudSpawnService, ICameraProvider cameraProvider,IWindService windService)
        {
            Add(new CloudSpawnSystem(gameContext, cloudSpawnService, cameraProvider, windService));
            Add(new DestroyCloudBelowScreenSystem(gameContext, cameraProvider));
        }
    }
}