using UnityEngine;

namespace Code.Gameplay.Features.Input.Service
{
    public class SwipeInputService : InputService
    {
        private Vector2 _startPosition;
        private Vector2 _axis;
        private bool _isHolding;

        private const float DeadZone = 10f; // пиксели, минимальное смещение

        public override Vector2 Axis => _axis;
        public override bool HasAxis => _isHolding && _axis != Vector2.zero;

        public void Update()
        {
            if (UnityEngine.Input.touchCount == 0)
            {
                _axis = Vector2.zero;
                _isHolding = false;
                return;
            }

            Touch touch = UnityEngine.Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPosition = touch.position;
                    _isHolding = true;
                    _axis = Vector2.zero;
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    Vector2 delta = touch.position - _startPosition;
                    Debug.Log($"Delta: {delta}, Axis: {_axis}");
                    if (delta.magnitude > DeadZone)
                        _axis = delta.normalized;
                    else
                        _axis = Vector2.zero;
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _axis = Vector2.zero;
                    _isHolding = false;
                    break;
            }
        }
    }
}