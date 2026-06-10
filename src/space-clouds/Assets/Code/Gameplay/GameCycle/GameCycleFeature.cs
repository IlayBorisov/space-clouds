using Code.Gameplay.GameCycle.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.GameCycle
{
    public class GameCycleFeature : Feature
    {
        public GameCycleFeature(ISystemsFactory system)
        {
            Add(system.Create<GamePauseSystem>());
            Add(system.Create<ClearCloudsOnRestartSystem>());
            Add(system.Create<ClearStarsOnRestartSystem>());
            Add(system.Create<ResetBuffsOnRestartSystem>());
            Add(system.Create<ResetHeroOnRestartSystem>());
        }
    }
}