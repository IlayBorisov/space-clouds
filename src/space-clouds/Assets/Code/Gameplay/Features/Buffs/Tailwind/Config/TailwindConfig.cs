using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Tailwind.Config
{
    [CreateAssetMenu(fileName = "TailwindConfig", menuName = "Configs/TailwindConfig")]
    public class TailwindConfig : ScriptableObject
    {
        public float Duration = 10f;
        public float SpeedMultiplier = 2f;
        public float SpawnInterval = 20f;
        public float DriftSpeed = 0.05f;
    }
}