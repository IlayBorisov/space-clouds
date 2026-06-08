using Code.Common.Cameras;
using Code.Gameplay.Features.Hero.Systems;

namespace Code.Gameplay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(GameContext gameContext, ICameraProvider cameraProvider)
        {
            Add(new SetHeroDirectionByInputSystem(gameContext));
            Add(new HeroBoundsSystem(gameContext, cameraProvider));
        }
    }
}