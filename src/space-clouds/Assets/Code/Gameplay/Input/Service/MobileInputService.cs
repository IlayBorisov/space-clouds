using UnityEngine;

namespace Code.Gameplay.Input.Service
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}