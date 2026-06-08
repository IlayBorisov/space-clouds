using System.Collections.Generic;
using Code.Infrastructure.Services.UI;
using Entitas;

namespace Code.Gameplay.Features.Collisions.Systems
{
    public class HeroCollisionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IUIService _uiService;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(1);

        public HeroCollisionSystem(GameContext game, IUIService uiService)
        {
            _game = game;
            _uiService = uiService;
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.CollidedWith));
        }
        public void Execute()
        {
            foreach (GameEntity hero in _heroes.GetEntities(_buffer))
            {
                int otherId = hero.CollidedWith;
                GameEntity other = _game.GetEntityWithId(otherId);

                hero.RemoveCollidedWith();

                if (other == null)
                    continue;

                if (other.isCollectStar)
                {
                    hero.ReplaceScore(hero.Score + 1);
                    _uiService.UpdateScore(hero.Score);
                    other.AddDestroyRequest(true);
                }
                else if (other.isObstacle)
                {
                    _uiService.ShowDefeat();
                }
            }
        }
    }
}