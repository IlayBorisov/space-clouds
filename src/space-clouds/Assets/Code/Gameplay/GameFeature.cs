using Code.Gameplay.Features.Buffs;
using Code.Gameplay.Features.Clouds;
using Code.Gameplay.Features.Collisions;
using Code.Gameplay.Features.Destroy;
using Code.Gameplay.Features.Hearts;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Input;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Stars;
using Code.Gameplay.Features.UI;
using Code.Gameplay.Features.Wind;
using Code.Gameplay.GameCycle;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
    public class GameFeature : Feature
    {
        public GameFeature(ISystemsFactory systems)
        {
            Add(new InputFeature(systems));
            Add(new HeroFeature(systems));
            Add(new MovementFeature(systems));
            Add(new WindFeature(systems));
            Add(new CloudFeature(systems));
            Add(new StarFeature(systems));
            Add(new CollisionFeature(systems));
            Add(new BuffFeature(systems));
            Add(new HeartsFeature(systems));
            Add(new UIFeature(systems));
            Add(new DestroyFeature(systems));
        }
    }
}
