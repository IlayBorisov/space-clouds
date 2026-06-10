using UnityEngine;

namespace Code.Gameplay.Features.Hearts.Service
{
    public interface IHeartsService
    {
        void SpawnHeart(Vector2 at);
    }
}