using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Tailwind.Factory
{
    public interface ITailwindFactory
    {
        void CreateTailwind(Vector2 at);
    }
}