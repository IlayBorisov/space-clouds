using Entitas;

namespace Code.Gameplay.Features.Clouds.Components
{
    [Game] public class Cloud : IComponent { }
    [Game] public class CloudSpawner : IComponent { }   
    [Game] public class SpawnInternal : IComponent { public float Value; }   
    [Game] public class SpawnTimer : IComponent { public float Value; }   
    [Game] public class DestroyedBelowScreen  : IComponent { }   
}
