using Code.Gameplay.Features.Buffs.Umbrella.Config;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Umbrella.Systems
{
    public class UmbrellaRepelSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _clouds;
        private readonly UmbrellaConfig _config;

        public UmbrellaRepelSystem(GameContext gameContext, UmbrellaConfig config)
        {
            _config = config;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.UmbrellaActive, GameMatcher.WorldPosition));
            _clouds = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Cloud, GameMatcher.WorldPosition, GameMatcher.Direction));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                foreach (GameEntity cloud in _clouds)
                {
                    Vector2 diff = cloud.WorldPosition - hero.WorldPosition;

                    if (diff.magnitude < _config.RepelRadius)
                    {
                        Vector2 repelDirection = diff.normalized;
                        cloud.ReplaceDirection(repelDirection);
                    }
                }
            }
        }
    }
}