using Code.Common.Cameras;
using Entitas;

namespace Code.Gameplay.Features.Clouds.Systems
{
    public class DestroyCloudBelowScreenSystem : IExecuteSystem
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _clouds;

        public DestroyCloudBelowScreenSystem(GameContext gameContext, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _clouds = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Cloud,
                    GameMatcher.WorldPosition,
                    GameMatcher.DestroyedBelowScreen));
        }

        public void Execute()
        {
            foreach (GameEntity cloud in _clouds)
            {
                if (cloud.WorldPosition.y < _cameraProvider.WorldScreenBottom && !cloud.hasDestroyRequest)
                {
                    cloud.AddDestroyRequest(true);
                }
            }
        }
    }
}
