using UnityEngine;

namespace Code.Gameplay.Features.Clouds.Configs
{
    [CreateAssetMenu(fileName = "CloudConfig", menuName = "Configs/CloudConfig")]
    public class CloudConfig : ScriptableObject
    {
        public float SpawnInterval = 1.5f;
        public float MinSpawnInterval = 0.5f;
        public float Speed = 2f;
        public float MinDistance = 2f;
    }
}