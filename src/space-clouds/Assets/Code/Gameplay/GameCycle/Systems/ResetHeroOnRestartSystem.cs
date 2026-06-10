using System.Collections.Generic;
using Code.Gameplay.Features.Hero.Config;
using Code.Gameplay.GameCycle.Services;
using Entitas;

namespace Code.Gameplay.GameCycle.Systems
{
    public class ResetHeroOnRestartSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IInitialPointService _initialPointService;
        private readonly HeroConfig _heroConfig;
        private readonly List<GameEntity> _buffer = new(1);

        public ResetHeroOnRestartSystem(GameContext gameContext, IInitialPointService initialPointService, HeroConfig heroConfig)
        {
            _initialPointService = initialPointService;
            _heroConfig = heroConfig;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.RestartRequest));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes.GetEntities(_buffer))
            {
                hero.ReplaceScore(_heroConfig.InitialScore);
                hero.ReplaceHealth(_heroConfig.InitialHealth);
                hero.ReplaceWorldPosition(_initialPointService.GetInitialPoint());
                hero.isRestartRequest = false;
            }
        }
    }
}