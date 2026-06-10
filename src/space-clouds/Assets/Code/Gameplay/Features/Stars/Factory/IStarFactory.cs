using UnityEngine;

namespace Code.Gameplay.Features.Stars.Factory
{
    public interface IStarFactory
    {
        GameEntity CreateStar(Vector2 at);
    }
}