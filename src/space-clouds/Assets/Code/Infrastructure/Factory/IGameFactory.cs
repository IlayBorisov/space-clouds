using Code.Infrastructure.Services;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        void CreateHero(GameObject at);
        void CreateHud();
        void CreateCloudSpawner();
    }
}