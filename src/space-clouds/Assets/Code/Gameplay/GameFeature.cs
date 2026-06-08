using Code.Common.Cameras;
using Code.Common.Collisions;
using Code.Common.Time;
using Code.Gameplay.Features.Clouds;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.Collisions;
using Code.Gameplay.Features.Destroy;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Input;
using Code.Gameplay.Features.Input.Service;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Stars;
using Code.Gameplay.Features.Stars.Service;
using Code.Gameplay.Features.Wind;
using Code.Gameplay.Features.Wind.Service;
using Code.Infrastructure.Services.UI;

namespace Code.Gameplay
{
    public class GameFeature : Feature
    {
        public GameFeature(GameContext gameContext, ICloudSpawnService cloudSpawnService, ITimeService timeService,
            IInputService inputService, ICameraProvider cameraProvider, ICollisionRegistry collisionRegistry,
            IStarSpawnService starSpawnService, IUIService uiService, IWindService windService)
        {
            Add(new InputFeature(gameContext, inputService));
            Add(new HeroFeature(gameContext, cameraProvider));
            Add(new MovementFeature(gameContext, timeService));
            Add(new WindFeature(gameContext, windService, timeService, cameraProvider));
            Add(new CloudFeature(gameContext, cloudSpawnService, cameraProvider, windService));
            Add(new StarFeature(gameContext, starSpawnService, cameraProvider));
            Add(new CollisionFeature(gameContext, uiService));
            Add(new DestroyFeature(gameContext, collisionRegistry));
        }
    }
}
