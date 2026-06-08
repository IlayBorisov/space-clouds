using UnityEngine;

namespace Code.Gameplay.Features.Wind.Service
{
    public interface IWindService
    {
        Vector2 WindDirection { get; }
        float WindForce { get; }
        float BaseCloudSpeed { get; }
        float CloudSpeedMultiplier { get;  }
        void Update(float deltaTime);
    }
}