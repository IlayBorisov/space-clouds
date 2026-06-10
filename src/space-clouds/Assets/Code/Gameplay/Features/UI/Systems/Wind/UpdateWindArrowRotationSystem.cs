using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Hud.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.UI.Systems.Wind
{
    public class UpdateWindArrowRotationSystem : IExecuteSystem
    {
        private readonly IHudService _hudService;
        private readonly IGroup<GameEntity> _winds;
        private float _currentAngle;

        public UpdateWindArrowRotationSystem(GameContext gameContext, IHudService hudService)
        {
            _hudService = hudService;
            _winds = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.WindEntity, GameMatcher.WindDirection));
        }

        public void Execute()
        {
            foreach (GameEntity wind in _winds)
            {
                Vector2 cloudDirection = new Vector2(
                    -wind.WindDirection.x * wind.WindForce * 0.5f,
                    -1f
                ).normalized;
                
                float targetAngle = Mathf.Atan2(cloudDirection.x, cloudDirection.y) * Mathf.Rad2Deg;
                float wobble = Mathf.Sin(Time.time * 2f) * 3f;
                _currentAngle = Mathf.LerpAngle(_currentAngle, targetAngle, Time.deltaTime * 3f);
                _hudService.SetWindArrowRotation(_currentAngle + wobble);
            }
        }
    }
}