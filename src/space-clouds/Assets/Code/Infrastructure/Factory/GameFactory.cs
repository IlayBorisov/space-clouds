using Code.Common.Collisions;
using Code.Gameplay.Common.Entity;
using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Common.Identifiers.Service;
using Code.Gameplay.Features.Collisions;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private readonly IIdentifierService _identifiers;
        private readonly ICollisionRegistry _collisionRegistry;

        public GameFactory(IAssets assets, IIdentifierService identifiers, ICollisionRegistry collisionRegistry)
        {
            _assets = assets;
            _identifiers = identifiers;
            _collisionRegistry = collisionRegistry;
        }

        public void CreateHero(GameObject at)
        {
            GameObject hero = _assets.Instantiate(AssetPath.HeroPath, at.transform.position);
            Collider2D collider = hero.GetComponent<Collider2D>();

            int id = _identifiers.Next();

            GameEntity entity = CreateEntity.Empty()
                .AddId(id)
                .AddTransform(hero.transform)
                .AddWorldPosition(hero.transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(3f)
                .AddScore(0)
                .With(x => x.isHero = true)
                .With(x => x.isMoving = true);

            if (collider != null)
                _collisionRegistry.Register(collider.GetInstanceID(), entity);

            TriggerObserver observer = hero.GetComponent<TriggerObserver>();
            if (observer != null)
                observer.Construct(entity, _collisionRegistry);

        }

        public void CreateHud() =>
            _assets.Instantiate(AssetPath.HudPath);

        public void CreateCloudSpawner() =>
            CreateEntity.Empty()
                .With(x => x.isCloudSpawner = true)
                .AddSpawnInternal(1.5f)
                .AddSpawnTimer(0f);

        public void CreateAudioManager() => 
            _assets.Instantiate(AssetPath.AudioManagerPath);

        public void CreateStarSpawner() =>
            CreateEntity.Empty()
                .With(x => x.isStarSpawner = true)
                .AddSpawnInternal(3f)
                .AddSpawnTimer(0f);
        
        
    }
}