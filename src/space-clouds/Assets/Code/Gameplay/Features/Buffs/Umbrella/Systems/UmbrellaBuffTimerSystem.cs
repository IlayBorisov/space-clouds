using System.Collections.Generic;
using Code.Infrastructure.UI.Hud.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Umbrella.Systems
{
    public class UmbrellaBuffTimerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _buffedHeroes;
        private readonly List<GameEntity> _buffer = new(1);
        private IHudService _hudService;
        private readonly IGroup<GameEntity> _umbrellaHeroes;
        private readonly IGroup<GameEntity> _tailwindHeroes;

        public UmbrellaBuffTimerSystem(GameContext game, IHudService hudService)
        {
            _hudService = hudService;
            _umbrellaHeroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.UmbrellaActive, GameMatcher.UmbrellaBuffDuration));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _umbrellaHeroes.GetEntities(_buffer))
            {
                hero.ReplaceUmbrellaBuffDuration(hero.UmbrellaBuffDuration - Time.deltaTime);

                if (hero.UmbrellaBuffDuration <= 0)
                {
                    hero.RemoveUmbrellaBuffDuration();
                    hero.isUmbrellaActive = false;
                    _hudService.HideUmbrellaBuff();

                    if (hero.hasUmbrellaCircle)
                        hero.UmbrellaCircle.SetActive(false);
                }
            }
        }
    }
}