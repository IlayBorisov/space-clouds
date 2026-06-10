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
        private readonly IGroup<GameEntity> _clouds;

        public WindSystem(GameContext gameContext, IWindService windService, ITimeService timeService)
        {
            _windService = windService;
            _timeService = timeService;
            _clouds = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Cloud,
                    GameMatcher.Direction));
        }
        public void Execute()
        {
            foreach (GameEntity cloud in _clouds)
            {
                float currentOffset = cloud.hasWindOffset ? cloud.WindOffset : 0f;
                float targetOffset = _windService.GetWindDirection().x * _windService.GetWindForce();
                float newOffset = Mathf.MoveTowards(currentOffset, targetOffset, 0.5f * _timeService.DeltaTime);

                cloud.ReplaceWindOffset(newOffset);
                cloud.ReplaceDirection(new Vector2(newOffset, -1f).normalized);
                
                float targetSpeed = _windService.BaseCloudSpeed * _windService.GetSpeedMultiplier();
                float currentSpeed = cloud.Speed;
                float newSpeed = Mathf.Lerp(currentSpeed, targetSpeed, _timeService.DeltaTime * 2f);
                cloud.ReplaceSpeed(newSpeed);
            }
        }
    }
}