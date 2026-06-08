using UnityEngine;

namespace Code.Gameplay.Features.Stars.Service
{
    public interface IStarSpawnService
    {
        void SpawnStar(Vector2 at);
    }
}