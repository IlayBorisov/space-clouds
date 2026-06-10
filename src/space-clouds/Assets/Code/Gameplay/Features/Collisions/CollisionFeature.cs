using Code.Common.Collisions;
using Code.Gameplay.Features.Collisions.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Collisions
{
    public class CollisionFeature : Feature
    {
        public CollisionFeature(ISystemsFactory systems)
        {
            Add(systems.Create<HeroCollisionSystem>());
        }
    }
}