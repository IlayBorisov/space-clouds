using Code.Gameplay.Features.Buffs.Tailwind.Config;
using Code.Gameplay.Features.Wind.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Tailwind.Systems
{
    public class TailwindDriftSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly TailwindConfig _config;
        private readonly IWindService _windService;

        public TailwindDriftSystem(GameContext gameContext, TailwindConfig config, IWindService windService)
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
                Vector3 currentPosition = hero.WorldPosition;
                Vector3 newPosition = currentPosition + new Vector3(windDir.x * _config.DriftSpeed * Time.deltaTime, 0, 0);
                hero.ReplaceWorldPosition(newPosition);
            }
        }
    }
}