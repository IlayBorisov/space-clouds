using Code.Gameplay.Features.Buffs.Systems;
using Code.Gameplay.Features.Buffs.Tailwind.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Buffs.Tailwind
{
    public class TailwindFeature : Feature
    {
        public TailwindFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeTailwindSpawnerSystem>());
            Add(systems.Create<TailwindSpeedSystem>());
            Add(systems.Create<TailwindDriftSystem>());
            Add(systems.Create<TailwindSpawnSystem>());
            Add(systems.Create<TailwindBuffTimerSystem>());
        }
    }
}