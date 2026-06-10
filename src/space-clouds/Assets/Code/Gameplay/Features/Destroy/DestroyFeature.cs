using Code.Common.Collisions;
using Code.Gameplay.Features.Destroy.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Destroy
{
    public class DestroyFeature : Feature
    {
        public DestroyFeature(ISystemsFactory system)
        {
            Add(system.Create<DestroyBelowScreenSystem>());
            Add(system.Create<DestroyEntitySystem>());
        }
    }
}
