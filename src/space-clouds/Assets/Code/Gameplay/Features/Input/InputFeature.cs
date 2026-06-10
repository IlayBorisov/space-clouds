using Code.Gameplay.Features.Input.Service;
using Code.Gameplay.Features.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeInputSystem>());
            Add(systems.Create<EmitInputSystem>());
        }
    }
}