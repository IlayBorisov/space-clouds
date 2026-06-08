using Code.Common.Cameras;
using Code.Common.Time;
using Code.Gameplay.Features.Wind.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Wind.Systems
{
    public class WindSystem : IExecuteSystem
    {
        private readonly IWindService _windService;
        private readonly ITimeService _timeService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _clouds;

        public WindSystem(GameContext gameContext, IWindService windService, ITimeService timeService, ICameraProvider cameraProvider)
        {
            _windService = windService;
            _timeService = timeService;
            _cameraProvider = cameraProvider;
            _clouds = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Cloud,
                    GameMatcher.Direction));
        }
        public void Execute()
        {
            _windService.Update(_timeService.DeltaTime);

            foreach (GameEntity cloud in _clouds)
            {
                float currentOffset = cloud.hasWindOffset ? cloud.WindOffset : 0f;
                float targetOffset = _windService.WindDirection.x * _windService.WindForce;
                float newOffset = Mathf.MoveTowards(currentOffset, targetOffset, 0.5f * _timeService.DeltaTime);
    
                cloud.ReplaceWindOffset(newOffset);
                cloud.ReplaceDirection(new Vector2(newOffset, -1f).normalized);
                cloud.ReplaceSpeed(_windService.BaseCloudSpeed * _windService.CloudSpeedMultiplier);
            }
        }
    }
}