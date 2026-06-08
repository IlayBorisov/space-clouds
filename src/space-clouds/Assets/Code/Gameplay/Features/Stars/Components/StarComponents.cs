using Entitas;

namespace Code.Gameplay.Features.Stars.Components
{
    [Game] public class Star : IComponent { }
    [Game] public class StarSpawner  : IComponent { }
    [Game] public class Score  : IComponent { public int Value; }

}