using Code.Common.Collisions;
using Code.Gameplay.Features.Collisions.Systems;
using Code.Infrastructure.Services.UI;

namespace Code.Gameplay.Features.Collisions
{
    public class CollisionFeature : Feature
    {
        public CollisionFeature(GameContext gameContext, IUIService uiService)
        {
            Add(new HeroCollisionSystem(gameContext, uiService));
        }
    }
}