using System;
using Code.Infrastructure;
using Code.Services.Input;
using UnityEngine;

namespace Code.Player
{
    public class HeroMove : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;
        public  float MovementSpeed;
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Update()
        {
            float moveX = _inputService.Axis.x;
            float moveY = _inputService.Axis.y;
            
            Vector2 velocity = new Vector2(moveX * MovementSpeed, moveY * MovementSpeed);
            Rigidbody2D.linearVelocity = velocity;

            if (moveX != 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Sign(moveX);
                transform.localScale = scale;
            }
        }
    }
}