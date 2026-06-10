using Code.Gameplay.Features.Buffs.Systems;
using Code.Gameplay.Features.Buffs.Umbrella.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Buffs.Umbrella
{
    public class UmbrellaFeature : Feature
    {
        public UmbrellaFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeUmbrellaSpawnerSystem>());
            Add(systems.Create<UmbrellaSpawnSystem>());
            Add(systems.Create<UmbrellaRepelSystem>());
            Add(systems.Create<UmbrellaBuffTimerSystem>());
        }
    }
}