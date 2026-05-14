using UnityEngine;

namespace Code.Services.Input
{
    public class MoBileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}