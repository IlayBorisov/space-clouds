using Code.Gameplay.Features.Buffs.Tailwind;
using Code.Gameplay.Features.Buffs.Umbrella;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Buffs
{
    public class BuffFeature : Feature
    {
        public BuffFeature(ISystemsFactory systems)
        {
            Add(systems.Create<UmbrellaFeature>());
            Add(systems.Create<TailwindFeature>());
        }
    }
}