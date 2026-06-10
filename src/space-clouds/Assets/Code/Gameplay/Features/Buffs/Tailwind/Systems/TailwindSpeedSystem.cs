using Code.Gameplay.Features.Buffs.Tailwind.Config;
using Code.Gameplay.Features.Wind.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Tailwind.Systems
{
    public class TailwindSpeedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly TailwindConfig _config;
        private readonly IWindService _windService;
        private readonly float _baseSpeed = 3f;

        public TailwindSpeedSystem(GameContext gameContext, TailwindConfig config, IWindService windService)
        {
            _config = config;
            _windService = windService;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.TailwindActive, GameMatcher.Direction));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                Vector2 windDir = _windService.GetWindDirection();
                float dot = Vector2.Dot(hero.Direction, windDir);

                float speed = dot > 0
                    ? _baseSpeed * _config.SpeedMultiplier
                    : _baseSpeed;

                hero.ReplaceSpeed(speed);
            }
        }
    }
}