using Code.Common.Collisions;
using Code.Gameplay.Common.Entity;
using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Common.Identifiers.Service;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Gameplay.Features.Clouds.Service
{
    public class CloudSpawnService : ICloudSpawnService
    {
        private readonly IAssets _assets;
        private readonly IIdentifierService _identifiers;
        private readonly ICollisionRegistry _collisionRegistry;

        public CloudSpawnService(IAssets assets, IIdentifierService identifiers, ICollisionRegistry collisionRegistry)
        {
            _assets = assets;
            _identifiers = identifiers;
            _collisionRegistry = collisionRegistry;
        }

        public void SpawnCloud(Vector2 at)
        {
            GameObject cloud = _assets.Instantiate(AssetPath.CloudPath, at);
            Collider2D collider = cloud.GetComponent<Collider2D>();
            
            int id = _identifiers.Next();

            GameEntity entity = CreateEntity.Empty()
                .AddId(id)
                .AddTransform(cloud.transform)
                .AddWorldPosition(at)
                .AddDirection(Vector2.down)
                .AddSpeed(2f)
                .With(x => x.isCloud = true)
                .With(x => x.isMoving = true)
                .With(x => x.isDestroyedBelowScreen = true)
                .With(x => x.isObstacle = true);
            
            if (collider != null)
                _collisionRegistry.Register(collider.GetInstanceID(), entity);
        }
    }
}