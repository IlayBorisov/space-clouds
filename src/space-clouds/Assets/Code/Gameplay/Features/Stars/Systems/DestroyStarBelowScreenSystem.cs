using Code.Common.Cameras;
using Entitas;

namespace Code.Gameplay.Features.Stars.Systems
{
    public class DestroyStarBelowScreenSystem : IExecuteSystem
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _stars;

        public DestroyStarBelowScreenSystem(GameContext gameContext, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _stars = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Star,
                    GameMatcher.WorldPosition,
                    GameMatcher.DestroyedBelowScreen));
        }

        public void Execute()
        {
            foreach (GameEntity star in _stars)
            {
                if (star.WorldPosition.y < _cameraProvider.WorldScreenBottom && !star.hasDestroyRequest)
                    star.AddDestroyRequest(true);
            }
        }
    }
}