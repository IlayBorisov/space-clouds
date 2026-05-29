using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input.Service
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