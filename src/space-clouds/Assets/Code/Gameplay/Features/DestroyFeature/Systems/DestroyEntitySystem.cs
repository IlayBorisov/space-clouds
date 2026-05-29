using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.DestroyFeature.Systems
{
    public class DestroyEntitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entitiesForDestroy;

        public DestroyEntitySystem(GameContext gameContext)
        {
            _entitiesForDestroy = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DestroyRequest));
        }

        public void Execute()
        {
            GameEntity[] deleteEntities = _entitiesForDestroy.GetEntities();
            foreach (GameEntity entity in deleteEntities)
            {
                if (entity.destroyRequest.withView && entity.hasTransform)
                {
                    GameObject.Destroy(entity.Transform.gameObject);
                }

                entity.Destroy();
            }
        }
    }
}
