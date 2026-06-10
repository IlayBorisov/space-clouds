using UnityEngine;

namespace Code.Gameplay.GameCycle.Services
{
    public class InitialPointService : IInitialPointService
    {
        public Vector3 GetInitialPoint()
        {
            GameObject initialPoint = GameObject.FindWithTag("InitialPoint");
            return initialPoint != null ? initialPoint.transform.position : Vector3.zero;
        }
    }
}