using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.GameCycle.Systems
{
    public class ClearStarsOnRestartSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _stars;
        private readonly List<GameEntity> _buffer = new(1);

        public ClearStarsOnRestartSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.RestartRequest));
            _stars = gameContext.GetGroup(GameMatcher.Star);
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes.GetEntities(_buffer))
            {
                foreach (GameEntity star in _stars.GetEntities())
                {
                    if (star.hasTransform)
                        Object.Destroy(star.Transform.gameObject);
                    star.Destroy();
                }
            }
        }
    }
}