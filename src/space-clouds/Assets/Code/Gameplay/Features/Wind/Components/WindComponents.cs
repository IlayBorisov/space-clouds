using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Wind.Components
{
    [Game] public class WindTimer : IComponent { public float Value; }
    [Game] public class WindForce : IComponent { public float Value; }
    [Game] public class WindDirectionComponent : IComponent { public Vector2 Value; }
    [Game] public class WindSpeedMultiplier : IComponent { public float Value; }
    [Game] public class WindEntity : IComponent { }
}