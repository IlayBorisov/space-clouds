using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Hud.Services;
using Entitas;

namespace Code.Gameplay.Features.UI.Systems.Score
{
    public class UpdateScoreSystem : IExecuteSystem
    {
        private readonly IHudService _hudService;
        private readonly IGroup<GameEntity> _heroes;

        public UpdateScoreSystem(GameContext gameContext, IHudService hudService)
        {
            _hudService = hudService;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.Score));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
                _hudService.UpdateScore(hero.Score);
        }
    }
}