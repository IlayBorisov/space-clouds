using Code.Common.Cameras;
using Code.Common.Time;
using Code.Gameplay.Features.Wind.Service;
using Code.Gameplay.Features.Wind.Systems;
using Unity.VisualScripting;

namespace Code.Gameplay.Features.Wind
{
    public class WindFeature : Feature
    {
        public WindFeature(GameContext gameContext, IWindService windService, ITimeService timeService, ICameraProvider cameraProvider)
        {
            Add(new WindSystem(gameContext, windService, timeService, cameraProvider));
        }
    }
}