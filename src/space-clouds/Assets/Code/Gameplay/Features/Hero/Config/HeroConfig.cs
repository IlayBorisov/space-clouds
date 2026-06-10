using UnityEngine;

namespace Code.Gameplay.Features.Hero.Config
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Configs/HeroConfig")]
    public class HeroConfig : ScriptableObject
    {
        public int InitialHealth = 3;
        public float InitialSpeed = 3f;
        public int InitialScore = 0;
    }
}