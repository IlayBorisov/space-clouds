using Code.Common.Collisions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Destroy.Systems
{
    public class DestroyEntitySystem : IExecuteSystem
    {
        private readonly ICollisionRegistry _collisionRegistry;
        private readonly IGroup<GameEntity> _entitiesForDestroy;

        public DestroyEntitySystem(GameContext gameContext, ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
            _entitiesForDestroy = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DestroyRequest));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entitiesForDestroy.GetEntities())
            {
                if (entity.destroyRequest.withView && entity.hasTransform)
                {
                    Collider2D collider = entity.Transform.GetComponent<Collider2D>();
                    if (collider != null)
                        _collisionRegistry.Unregister(collider.GetInstanceID());

                    GameObject.Destroy(entity.Transform.gameObject);
                }

                entity.Destroy();
            }
        }
    }
}
