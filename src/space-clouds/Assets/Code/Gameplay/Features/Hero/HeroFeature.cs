using Code.Gameplay.Features.Hero.Systems;

namespace Code.Gameplay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(GameContext gameContext)
        {
            Add(new SetHeroDirectionByInputSystem(gameContext));
        }
    }
}