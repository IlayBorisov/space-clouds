using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemsFactory system)
        {
            Add(system.Create<DirectionalDeltaMoveSystem>());
            Add(system.Create<UpdateTransformPositionSystem>());
        }
    }
}