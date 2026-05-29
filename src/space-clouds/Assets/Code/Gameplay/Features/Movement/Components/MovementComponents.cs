using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Components
{
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class Direction : IComponent { public Vector2 Value; }
    [Game] public class Moving : IComponent { }
}