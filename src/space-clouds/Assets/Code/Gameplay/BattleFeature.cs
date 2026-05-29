using Code.Common.Cameras;
using Code.Common.Time;
using Code.Gameplay.Features.Clouds;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.DestroyFeature;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Input;
using Code.Gameplay.Features.Input.Service;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Physics;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(GameContext gameContext, ICloudSpawnService cloudSpawnService, ITimeService timeService, IInputService inputService, ICameraProvider cameraProvider)
        {
            Add(new InputFeature(gameContext, inputService));
            Add(new HeroFeature(gameContext));
            Add(new MovementFeature(gameContext, timeService));
            Add(new CloudFeature(gameContext, cloudSpawnService, cameraProvider));
            Add(new PhysicsFeature(gameContext));
            Add(new DestroyFeature(gameContext));
        }
    }
}
