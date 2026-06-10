using Code.Gameplay.Features.Stars.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Stars
{
    public class StarFeature : Feature
    {
        public StarFeature(ISystemsFactory systemsFactory)
        {
            Add(systemsFactory.Create<InitializeStarSpawnerSystem>());
            Add(systemsFactory.Create<StarSystem>());
            //Add(systemsFactory.Create<DestroyStarBelowScreenSystem>());
        }
    }
}