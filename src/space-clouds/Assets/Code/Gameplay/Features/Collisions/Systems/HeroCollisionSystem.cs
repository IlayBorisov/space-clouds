using System.Collections.Generic;
using Code.Gameplay.Features.Buffs;
using Code.Gameplay.Features.Buffs.Tailwind.Config;
using Code.Gameplay.Features.Buffs.Umbrella.Config;
using Entitas;

namespace Code.Gameplay.Features.Collisions.Systems
{
    public class HeroCollisionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(1);
        private UmbrellaConfig _umbrellaConfig;
        private TailwindConfig _tailwindConfig;

        public HeroCollisionSystem(GameContext game, UmbrellaConfig umbrellaConfig, TailwindConfig tailwindConfig)
        {
            _game = game;
            _umbrellaConfig = umbrellaConfig;
            _tailwindConfig = tailwindConfig;
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
                    other.AddDestroyRequest(true);
                }
                else if (other.isUmbrellaPickup)
                {
                    hero.isUmbrellaActive = true;
                    hero.ReplaceUmbrellaBuffDuration(_umbrellaConfig.Duration);

                    if (hero.hasUmbrellaCircle)
                        hero.UmbrellaCircle.SetActive(true);
                    
                    other.AddDestroyRequest(true);
                }
                else if (other.isTailwindPickup)
                {
                    hero.isTailwindActive = true;
                    hero.ReplaceTailwindBuffDuration(_tailwindConfig.Duration);
                    other.AddDestroyRequest(true);
                }
                else if (other.isCollectHeart)
                {
                    if (hero.Health < 3) 
                        hero.ReplaceHealth(hero.Health + 1);
                    other.AddDestroyRequest(true);
                }
                else if (other.isObstacle)
                {
                    hero.ReplaceHealth(hero.Health - 1);
                }
            }
        }
    }
}