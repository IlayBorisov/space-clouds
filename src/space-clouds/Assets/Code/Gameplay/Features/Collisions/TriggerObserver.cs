using Code.Common.Collisions;
using UnityEngine;

namespace Code.Gameplay.Features.Collisions
{
    public class TriggerObserver : MonoBehaviour
    {
        public GameEntity Entity;
        private ICollisionRegistry _collisionRegistry;
        
        public void Construct(GameEntity entity, ICollisionRegistry collisionRegistry)
        {
            Entity = entity;
            _collisionRegistry = collisionRegistry;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            int otherId = other.GetInstanceID();
            GameEntity otherEntity = _collisionRegistry.Get<GameEntity>(otherId);

            if (otherEntity != null && Entity != null)
                Entity.ReplaceCollidedWith(otherEntity.Id);
        }
    }
}