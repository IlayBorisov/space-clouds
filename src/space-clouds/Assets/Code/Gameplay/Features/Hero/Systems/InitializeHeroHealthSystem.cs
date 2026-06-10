using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Hud.Services;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class InitializeHeroHealthSystem : IInitializeSystem
    {
        private readonly IHudService _hudService;
        private readonly IGroup<GameEntity> _heroes;

        public InitializeHeroHealthSystem(GameContext gameContext, IHudService hudService)
        {
            _hudService = hudService;
            _heroes = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.Health));
        }

        public void Initialize()
        {
            foreach (GameEntity hero in _heroes)
                _hudService.UpdateHealth(hero.Health);
        }
    }
}