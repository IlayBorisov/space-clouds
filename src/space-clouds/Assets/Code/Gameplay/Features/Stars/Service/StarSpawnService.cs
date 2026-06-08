using Code.Common.Collisions;
using Code.Gameplay.Common.Entity;
using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Common.Identifiers.Service;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Gameplay.Features.Stars.Service
{
    public class StarSpawnService : IStarSpawnService
    {
        private readonly IAssets _assets;
        private readonly IIdentifierService _identifiers;
        private readonly ICollisionRegistry _collisionRegistry;

        public StarSpawnService(IAssets assets, IIdentifierService identifiers, ICollisionRegistry collisionRegistry)
        {
            _assets = assets;
            _identifiers = identifiers;
            _collisionRegistry = collisionRegistry;
        }

        public void SpawnStar(Vector2 at)
        {
            GameObject star = _assets.Instantiate(AssetPath.StarPath, at);
            Collider2D collider = star.GetComponent<Collider2D>();

            int id = _identifiers.Next();

            GameEntity entity = CreateEntity.Empty()
                .AddId(id)
                .AddTransform(star.transform)
                .AddWorldPosition(at)
                .AddDirection(Vector2.down)
                .AddSpeed(2f)
                .With(x => x.isStar = true)
                .With(x => x.isMoving = true)
                .With(x => x.isCollectStar = true)
                .With(x => x.isDestroyedBelowScreen = true);

            if (collider != null)
                _collisionRegistry.Register(collider.GetInstanceID(), entity);
        }
    }
}