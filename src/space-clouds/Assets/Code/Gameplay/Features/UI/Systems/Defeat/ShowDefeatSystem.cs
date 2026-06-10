using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Menu.Services;
using Entitas;

namespace Code.Gameplay.Features.UI.Systems.Defeat
{
    public class ShowDefeatSystem : IExecuteSystem
    {
        private readonly IMenuService _menuService;
        private readonly IGroup<GameEntity> _heroes;

        public ShowDefeatSystem(GameContext gameContext, IMenuService menuService)
        {
            _menuService = menuService;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.Health));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                if (hero.Health <= 0)
                {
                    _menuService.ShowDefeat();
                }
            }
        }
    }
}