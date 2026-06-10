using Entitas;

namespace Code.Gameplay.Features.Buffs.Tailwind
{
    [Game] public class TailwindActive : IComponent { }
    [Game] public class TailwindPickup : IComponent { }
    [Game] public class TailwindSpawner : IComponent { }
    [Game] public class TailwindBuffDuration : IComponent { public float Value; }
    
}