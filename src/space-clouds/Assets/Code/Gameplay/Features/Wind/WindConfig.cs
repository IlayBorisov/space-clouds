using UnityEngine;

namespace Code.Gameplay.Features.Wind
{
    [CreateAssetMenu(fileName = "WindConfig", menuName = "Configs/WindConfig")]
    public class WindConfig : ScriptableObject
    {
        public float MinWindForce = 0.3f;
        public float MaxWindForce = 2f;
        public float MinWindDuration = 3f;
        public float MaxWindDuration = 8f;
        public float BaseCloudSpeed = 2f;
        public float MinCloudSpeedMultiplier = 0.8f;  // замедление
        public float MaxCloudSpeedMultiplier = 2f; // ускорение
    }
}