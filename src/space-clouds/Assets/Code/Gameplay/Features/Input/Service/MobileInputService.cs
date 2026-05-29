using UnityEngine;

namespace Code.Gameplay.Features.Input.Service
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}