using Code.Common.Collisions;
using Code.Gameplay.Common.Entity;
using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Common.Identifiers.Service;
using Code.Gameplay.Features.Collisions;
using Code.Gameplay.Features.Hero.Config;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private readonly IIdentifierService _identifiers;
        private readonly ICollisionRegistry _collisionRegistry;
        private readonly HeroConfig _heroConfig;
        private string _umbrellacircle = "UmbrellaCircle";

        public GameFactory(IAssets assets, IIdentifierService identifiers, ICollisionRegistry collisionRegistry, HeroConfig config)
        {
            _assets = assets;
            _identifiers = identifiers;
            _collisionRegistry = collisionRegistry;
            _heroConfig = config;
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
                .AddSpeed(_heroConfig.InitialSpeed)
                .AddScore(_heroConfig.InitialScore)
                .AddHealth(_heroConfig.InitialHealth)
                .With(x => x.isHero = true)
                .With(x => x.isMoving = true);
            
            if (collider != null)
                _collisionRegistry.Register(collider.GetInstanceID(), entity);

            TriggerObserver observer = hero.GetComponent<TriggerObserver>();
            if (observer != null)
                observer.Construct(entity, _collisionRegistry);
            
            Transform umbrellaCircle = hero.transform.Find(_umbrellacircle);
            if (umbrellaCircle != null)
            {
                umbrellaCircle.gameObject.SetActive(false);
                entity.AddUmbrellaCircle(umbrellaCircle.gameObject);
            }
        }

        public void CreateHud() =>
            _assets.Instantiate(AssetPath.HudPath);

        public void CreateAudioManager() => 
            _assets.Instantiate(AssetPath.AudioManagerPath);
        
    }
}