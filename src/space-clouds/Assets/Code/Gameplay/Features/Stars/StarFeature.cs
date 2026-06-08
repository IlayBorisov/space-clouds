using Code.Common.Cameras;
using Code.Gameplay.Features.Stars.Service;
using Code.Gameplay.Features.Stars.Systems;

namespace Code.Gameplay.Features.Stars
{
    public class StarFeature : Feature
    {
        public StarFeature(GameContext gameContext, IStarSpawnService starSpawnService, ICameraProvider cameraProvider)
        {
            Add(new StarSystem(gameContext, starSpawnService, cameraProvider));
            Add(new DestroyStarBelowScreenSystem(gameContext, cameraProvider));
        }
    }
}