using Code.Common.Cameras;
using Code.Common.Time;
using Code.Gameplay.Features.Wind.Service;
using Code.Gameplay.Features.Wind.Systems;
using Code.Infrastructure.Systems;
using Unity.VisualScripting;

namespace Code.Gameplay.Features.Wind
{
    public class WindFeature : Feature
    {
        public WindFeature(ISystemsFactory system)
        {
            Add(system.Create<InitializeWindSystem>());
            Add(system.Create<WindSystem>());
            Add(system.Create<WindTimerSystem>());
        }
    }
}