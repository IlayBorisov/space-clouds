using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Umbrella
{
    [Game] public class UmbrellaActive : IComponent { }
    [Game] public class UmbrellaPickup : IComponent { }
    [Game] public class UmbrellaCircle : IComponent { public GameObject Value; }
    [Game] public class UmbrellaSpawner : IComponent { }
    [Game] public class UmbrellaBuffDuration : IComponent { public float Value; }
}