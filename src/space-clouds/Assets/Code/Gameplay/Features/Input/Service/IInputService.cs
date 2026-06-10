using Code.Infrastructure;
using UnityEngine;

namespace Code.Gameplay.Features.Input.Service
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
        bool HasAxis { get; }
    }
}