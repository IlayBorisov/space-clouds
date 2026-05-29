using Code.Infrastructure.Services;
using UnityEngine;

namespace Code.Gameplay.Input.Service
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
        bool HasAxis { get; }
    }
}