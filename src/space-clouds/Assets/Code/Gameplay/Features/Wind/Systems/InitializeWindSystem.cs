using Code.Gameplay.Common.Extensions;
using Code.Gameplay.Features.Wind.Configs;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Wind.Systems
{
    public class InitializeWindSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly WindConfig _config;


        public InitializeWindSystem(GameContext gameContext, WindConfig config)
        {
            _gameContext = gameContext;
            _config = config;
        }

        public void Initialize()
        {
            _gameContext.CreateEntity()
                .With(x => x.isWindEntity = true)
                .AddWindTimer(0f)
                .AddWindForce(_config.MinWindForce)
                .AddWindDirection(Vector2.right)
                .AddWindSpeedMultiplier(_config.MinCloudSpeedMultiplier);
        }
    }
}