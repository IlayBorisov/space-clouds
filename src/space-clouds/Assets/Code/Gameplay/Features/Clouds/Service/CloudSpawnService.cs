using Code.Gameplay.Common.Entity;
using Code.Gameplay.Common.Extensions;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Gameplay.Features.Clouds.Service
{
    public class CloudSpawnService : ICloudSpawnService
    {
        private readonly IAssets _assets;

        public CloudSpawnService(IAssets assets)
        {
            _assets = assets;
        }

        public void SpawnCloud(Vector2 at)
        {
            GameObject cloud = _assets.Instantiate(AssetPath.CloudPath, at);
            
            CreateEntity.Empty()
                .AddTransform(cloud.transform)
                .AddWorldPosition(at)
                .AddDirection(Vector2.down)
                .AddSpeed(2f)
                .With(x => x.isCloud = true)
                .With(x => x.isMoving = true)
                .With(x => x.isDestroyedBelowScreen = true);
        }
    }
}