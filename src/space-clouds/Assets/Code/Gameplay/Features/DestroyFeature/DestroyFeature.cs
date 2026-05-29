using Code.Gameplay.Features.DestroyFeature.Systems;

namespace Code.Gameplay.Features.DestroyFeature
{
    public class DestroyFeature : Feature
    {
        public DestroyFeature(GameContext gameContext)
        {
            Add(new DestroyEntitySystem(gameContext));
        }
    }
}
