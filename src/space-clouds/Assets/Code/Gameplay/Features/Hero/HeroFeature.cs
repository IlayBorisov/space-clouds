using Code.Common.Cameras;
using Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(ISystemsFactory system)
        {
            Add(system.Create<InitializeHeroHealthSystem>());
            Add(system.Create<SetHeroDirectionByInputSystem>());
            Add(system.Create<HeroBoundsSystem>());
        }
    }
}