using Code.Common.Cameras;
using Code.Common.Random;
using UnityEngine;

namespace Code.Common
{
    public class SpawnHelper 
    {
        public static Vector2 RandomTopPosition(ICameraProvider cameraProvider)
        {
            float halfWidth = cameraProvider.WorldScreenWidth / 2f;
            float randomX = UnityEngine.Random.Range(-halfWidth, halfWidth);
            float spawnY = cameraProvider.WorldScreenHeight / 2f + 1f;
            return new Vector2(randomX, spawnY);
        }
    }
}