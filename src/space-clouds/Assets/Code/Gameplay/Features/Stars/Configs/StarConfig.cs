using UnityEngine;

namespace Code.Gameplay.Features.Stars.Configs
{
    [CreateAssetMenu(fileName = "StarConfig", menuName = "Configs/StarConfig")]
    public class StarConfig : ScriptableObject
    {
        public float SpawnInterval = 3f;
        public float Speed = 2f;
    }
}