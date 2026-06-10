using Code.Common.Cameras;
using Entitas;

namespace Code.Gameplay.Features.Destroy.Systems
{
    public class DestroyBelowScreenSystem : IExecuteSystem
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _entities;

        public DestroyBelowScreenSystem(GameContext gameContext, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.DestroyedBelowScreen));
        }
        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.WorldPosition.y < _cameraProvider.WorldScreenBottom && !entity.hasDestroyRequest)
                    entity.AddDestroyRequest(true);
            }
        }
    }
}