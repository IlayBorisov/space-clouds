using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Input.Components
{
    [Game] public class Input : IComponent { }
    [Game] public class AxisInput : IComponent { public Vector2 Value; }
}