using Code.Gameplay.Common.Entity;
using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
    public class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .isInput = true;
        }
    }
}