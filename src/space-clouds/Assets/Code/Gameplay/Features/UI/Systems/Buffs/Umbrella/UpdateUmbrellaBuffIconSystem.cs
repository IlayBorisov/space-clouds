using Code.Infrastructure.UI.Hud.Services;
using Entitas;

namespace Code.Gameplay.Features.UI.Systems.Buffs.Umbrella
{
    public class UpdateUmbrellaBuffIconSystem : IExecuteSystem
    {
        private readonly IHudService _hudService;
        private readonly IGroup<GameEntity> _heroes;

        public UpdateUmbrellaBuffIconSystem(GameContext gameContext, IHudService hudService)
        {
            _hudService = hudService;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.UmbrellaActive, GameMatcher.UmbrellaBuffDuration));
        }
        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                _hudService.ShowUmbrellaBuff(hero.UmbrellaBuffDuration);
            }
        }
    }
}