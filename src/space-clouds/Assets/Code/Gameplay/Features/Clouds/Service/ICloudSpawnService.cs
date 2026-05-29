using UnityEngine;

namespace Code.Gameplay.Features.Clouds.Service
{
    public interface ICloudSpawnService
    {
        void SpawnCloud(Vector2 at);
    }
}