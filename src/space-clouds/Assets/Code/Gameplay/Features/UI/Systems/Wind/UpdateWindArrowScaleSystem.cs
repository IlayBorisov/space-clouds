using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Hud.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.UI.Systems.Wind
{
    public class UpdateWindArrowScaleSystem : IExecuteSystem
    {
        private readonly IHudService _hudService;
        private readonly IGroup<GameEntity> _winds;
        private float _currentScale = 1f;

        public UpdateWindArrowScaleSystem(GameContext gameContext, IHudService hudService)
        {
            _hudService = hudService;
            _winds = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.WindEntity, GameMatcher.WindForce));
        }

        public void Execute()
        {
            foreach (GameEntity wind in _winds)
            {
                float targetScale = Mathf.Lerp(0.5f, 1.0f, wind.WindForce / 2f);
                _currentScale = Mathf.Lerp(_currentScale, targetScale, Time.deltaTime * 3f);
                _hudService.SetWindArrowScale(_currentScale);
            }
        }
    }
}