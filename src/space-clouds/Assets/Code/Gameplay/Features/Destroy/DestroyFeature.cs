using Code.Common.Collisions;
using Code.Gameplay.Features.Destroy.Systems;

namespace Code.Gameplay.Features.Destroy
{
    public class DestroyFeature : Feature
    {
        public DestroyFeature(GameContext gameContext, ICollisionRegistry collisionRegistry)
        {
            Add(new DestroyEntitySystem(gameContext, collisionRegistry));
        }
    }
}
