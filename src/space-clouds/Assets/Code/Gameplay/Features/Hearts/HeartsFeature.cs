using Code.Gameplay.Features.Hearts.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hearts
{
    public class HeartsFeature : Feature
    {
        public HeartsFeature(ISystemsFactory system)
        {
            Add(system.Create<HeartSystem>());
        }
    }
}