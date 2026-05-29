using Code.Gameplay.Common.Entity;
using Code.Gameplay.Common.Extensions;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public void CreateHero(GameObject at) =>
            _assets.Instantiate(AssetPath.HeroPath, at.transform.position);

        public void CreateHud() =>
            _assets.Instantiate(AssetPath.HudPath);

        public void CreateCloudSpawner() =>
            CreateEntity.Empty()
                .With(x => x.isCloudSpawner = true)
                .AddSpawnInternal(2f)
                .AddSpawnTimer(0f);
    }
}