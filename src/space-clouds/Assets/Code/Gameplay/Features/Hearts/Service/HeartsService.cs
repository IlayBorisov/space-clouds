using Code.Common.Collisions;
using Code.Gameplay.Common.Entity;
using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Common.Identifiers.Service;
using Code.Infrastructure.AssetManagement;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hearts.Service
{
    public class HeartsService : IHeartsService
    {
        private readonly IAssets _assets;
        private readonly IIdentifierService _identifiers;
        private readonly ICollisionRegistry _collisionRegistry;

        public HeartsService(IAssets assets, IIdentifierService identifiers, ICollisionRegistry collisionRegistry)
        {
            _assets = assets;
            _identifiers = identifiers;
            _collisionRegistry = collisionRegistry;
        }

        public void SpawnHeart(Vector2 at)
        {
            GameObject heart = _assets.Instantiate(AssetPath.HeartPath, at);
            Collider2D collider = heart.GetComponent<Collider2D>();

            int id = _identifiers.Next();

            GameEntity entity = CreateEntity.Empty()
                .AddId(id)
                .AddTransform(heart.transform)
                .AddWorldPosition(at)
                .AddDirection(Vector2.down)
                .AddSpeed(2f)
                .With(x => x.isHeart = true)
                .With(x => x.isMoving = true)
                .With(x => x.isCollectHeart = true)
                .With(x => x.isDestroyedBelowScreen = true);

            if (collider != null)
                _collisionRegistry.Register(collider.GetInstanceID(), entity);
        }
    }
}