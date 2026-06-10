using Code.Common.Collisions;
using Code.Gameplay.Common.Entity;
using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Common.Identifiers.Service;
using Code.Gameplay.Features.Stars.Configs;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Gameplay.Features.Stars.Factory
{
    public class StarFactory : IStarFactory
    {
        private readonly IAssets _assets;
        private readonly IIdentifierService _identifiers;
        private readonly ICollisionRegistry _collisionRegistry;
        private readonly StarConfig _config;

        public StarFactory(IAssets assets, IIdentifierService identifierService, ICollisionRegistry collisionRegistry, StarConfig config)
        {
            _config = config;
            _assets = assets;
            _identifiers = identifierService;
            _collisionRegistry = collisionRegistry;
        }

        public GameEntity CreateStar(Vector2 at)
        {
            GameObject star = _assets.Instantiate(AssetPath.StarPath, at);
            Collider2D collider = star.GetComponent<Collider2D>();

            int id = _identifiers.Next();

            GameEntity entity = CreateEntity.Empty()
                .AddId(id)
                .AddTransform(star.transform)
                .AddWorldPosition(at)
                .AddDirection(Vector2.down)
                .AddSpeed(_config.Speed)
                .With(x => x.isStar = true)
                .With(x => x.isMoving = true)
                .With(x => x.isCollectStar = true)
                .With(x => x.isDestroyedBelowScreen = true);

            if (collider != null)
                _collisionRegistry.Register(collider.GetInstanceID(), entity);
           
            return entity;
        }
    }
}