using System.Collections.Generic;
using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Hud.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Systems
{
    public class TailwindBuffTimerSystem : IExecuteSystem
    {
        private readonly IHudService _hudService;
        private readonly IGroup<GameEntity> _tailwindHeroes;
        private readonly IGroup<GameEntity> _buffedHeroes;
        private readonly List<GameEntity> _buffer = new(1);

        public TailwindBuffTimerSystem(GameContext game, IHudService hudService)
        {
            _hudService = hudService;
            _tailwindHeroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.TailwindActive, GameMatcher.TailwindBuffDuration));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _tailwindHeroes.GetEntities(_buffer))
            {
                hero.ReplaceTailwindBuffDuration(hero.TailwindBuffDuration - Time.deltaTime);

                if (hero.TailwindBuffDuration <= 0)
                {
                    hero.RemoveTailwindBuffDuration();
                    hero.isTailwindActive = false;
                    hero.ReplaceSpeed(3f);
                    _hudService.HideTailwindBuff();
                }
            }
        }
    }
}