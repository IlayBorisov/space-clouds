
using Code.Common.Cameras;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class HeroBoundsSystem : IExecuteSystem
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _heroes;

        public HeroBoundsSystem(GameContext gameContext, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));
        }
        public void Execute()
        {
            float halfWidth = _cameraProvider.WorldScreenWidth / 2f;
            float bottom = _cameraProvider.WorldScreenBottom;
            foreach (GameEntity hero in _heroes)
            {
                Vector2 pos = hero.WorldPosition;

                // перебрасываем по горизонтали
                if (pos.x > halfWidth)
                    pos.x = -halfWidth;
                else if (pos.x < -halfWidth)
                    pos.x = halfWidth;

                // ограничиваем по вертикали
                float topLimit = bottom + _cameraProvider.WorldScreenHeight - 0.5f;
                float bottomLimit = bottom + 0.5f;
                pos.y = Mathf.Clamp(pos.y, bottomLimit, topLimit);

                hero.ReplaceWorldPosition(pos);
            }
        }
    }
}