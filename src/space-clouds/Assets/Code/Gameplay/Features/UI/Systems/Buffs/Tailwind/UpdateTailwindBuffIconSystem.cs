using Code.Infrastructure.UI.Hud.Services;
using Entitas;

namespace Code.Gameplay.Features.UI.Systems.Buffs.Tailwind
{
    public class UpdateTailwindBuffIconSystem : IExecuteSystem
    {
        private readonly IHudService _hudService;
        private readonly IGroup<GameEntity> _heroes;

        public UpdateTailwindBuffIconSystem(GameContext gameContext, IHudService hudService)
        {
            _hudService = hudService;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.TailwindActive, GameMatcher.TailwindBuffDuration));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
                _hudService.ShowTailwindBuff(hero.TailwindBuffDuration);
        }
    }
}