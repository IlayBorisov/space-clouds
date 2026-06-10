using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Hud.Services;
using Entitas;

namespace Code.Gameplay.Features.UI.Systems.Health
{
    public class UpdateHealthSystem : IExecuteSystem
    {
        private readonly IHudService _hudService;
        private readonly IGroup<GameEntity> _heroes;

        public UpdateHealthSystem(GameContext gameContext, IHudService hudService)
        {
            _hudService = hudService;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.Health));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
                _hudService.UpdateHealth(hero.Health);
        }
    }
}