using UnityEngine;

namespace Code.Gameplay.Features.Wind.Service
{
    public interface IWindService
    {
        float BaseCloudSpeed { get; }
        Vector2 GetWindDirection();
        float GetWindForce();
        float GetSpeedMultiplier();
    }
}