using Code.Gameplay.Features.UI.Systems;
using Code.Gameplay.Features.UI.Systems.Buffs;
using Code.Gameplay.Features.UI.Systems.Buffs.Tailwind;
using Code.Gameplay.Features.UI.Systems.Buffs.Umbrella;
using Code.Gameplay.Features.UI.Systems.Defeat;
using Code.Gameplay.Features.UI.Systems.Health;
using Code.Gameplay.Features.UI.Systems.Score;
using Code.Gameplay.Features.UI.Systems.Wind;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.UI
{
    public class UIFeature : Feature
    {
        public UIFeature(ISystemsFactory systems)
        {
            Add(systems.Create<UpdateScoreSystem>());
            Add(systems.Create<UpdateHealthSystem>());
            Add(systems.Create<ShowDefeatSystem>());
            Add(systems.Create<UpdateWindArrowRotationSystem>());
            Add(systems.Create<UpdateWindArrowScaleSystem>());
            Add(systems.Create<UpdateUmbrellaBuffIconSystem>());
            Add(systems.Create<UpdateTailwindBuffIconSystem>());
        }
    }
}