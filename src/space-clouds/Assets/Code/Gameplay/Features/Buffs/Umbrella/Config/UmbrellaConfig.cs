using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Umbrella.Config
{
    [CreateAssetMenu(fileName = "UmbrellaConfig", menuName = "Configs/UmbrellaConfig")]
    public class UmbrellaConfig : ScriptableObject
    {
        public float Duration = 10f;
        public float RepelRadius = 2f;
        public float RepelForce = 3f;
        public float SpawnInterval = 15f;
    }
}