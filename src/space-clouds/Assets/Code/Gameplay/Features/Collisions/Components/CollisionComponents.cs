using Entitas;

namespace Code.Gameplay.Features.Collisions.Components
{
    
    [Game] public class CollectStar : IComponent { }  
    [Game] public class Obstacle : IComponent { }      
    
    [Game] public class CollidedWith : IComponent { public int Value; } 
}