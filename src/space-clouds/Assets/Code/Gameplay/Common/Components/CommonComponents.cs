using Entitas;
using UnityEngine;

namespace Code.Gameplay.Common.Components
{
    [Game] public class Id : IComponent { public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class TransformComponent : IComponent { public Transform Value; }
} 