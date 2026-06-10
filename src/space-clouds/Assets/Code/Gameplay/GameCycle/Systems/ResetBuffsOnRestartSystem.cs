using System.Collections.Generic;
using Code.Infrastructure.UI.Hud.Services;
using Entitas;

namespace Code.Gameplay.GameCycle.Systems
{
    public class ResetBuffsOnRestartSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IHudService _hudService;
        private readonly List<GameEntity> _buffer = new(1);

        public ResetBuffsOnRestartSystem(GameContext gameContext, IHudService hudService)
        {
            _hudService = hudService;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.RestartRequest));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes.GetEntities(_buffer))
            {
                if (hero.isUmbrellaActive)
                {
                    hero.isUmbrellaActive = false;
                    if (hero.hasUmbrellaCircle)
                        hero.UmbrellaCircle.SetActive(false);
                    if (hero.hasUmbrellaBuffDuration)
                        hero.RemoveUmbrellaBuffDuration();
                    _hudService.HideUmbrellaBuff();
                }

                if (hero.isTailwindActive)
                {
                    hero.isTailwindActive = false;
                    if (hero.hasTailwindBuffDuration)
                        hero.RemoveTailwindBuffDuration();
                    _hudService.HideTailwindBuff();
                }
            }
        }
    }
}