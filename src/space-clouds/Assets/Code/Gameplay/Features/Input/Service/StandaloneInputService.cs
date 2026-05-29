using UnityEngine;

namespace Code.Gameplay.Features.Input.Service
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = SimpleInputAxis();
                if (axis == Vector2.zero)
                   axis = UnityAxis(); 
                return axis;
           }
        }

    }
}