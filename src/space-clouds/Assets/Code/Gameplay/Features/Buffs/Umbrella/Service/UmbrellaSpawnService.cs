using Code.Common.Collisions;
using Code.Gameplay.Common.Entity;
using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Common.Identifiers.Service;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Umbrella.Service
{
    public class UmbrellaSpawnService : IUmbrellaSpawnService
    {
        private readonly IAssets _assets;
        private readonly IIdentifierService _identifiers;
        private readonly ICollisionRegistry _collisionRegistry;

        public UmbrellaSpawnService(IAssets assets, IIdentifierService identifiers, ICollisionRegistry collisionRegistry)
        {
            _assets = assets;
            _identifiers = identifiers;
            _collisionRegistry = collisionRegistry;
        }

        public void SpawnUmbrella(Vector2 at)
        {
            GameObject umbrella = _assets.Instantiate(AssetPath.UmbrellaPath, at);
            Collider2D collider = umbrella.GetComponent<Collider2D>();
            int id = _identifiers.Next();

            GameEntity entity = CreateEntity.Empty()
                .AddId(id)
                .AddTransform(umbrella.transform)
                .AddWorldPosition(at)
                .AddDirection(Vector2.down)
                .AddSpeed(2f)
                .With(x => x.isUmbrellaPickup = true)
                .With(x => x.isMoving = true)
                .With(x => x.isDestroyedBelowScreen = true);

            if (collider != null)
                _collisionRegistry.Register(collider.GetInstanceID(), entity);
        }
    }
}