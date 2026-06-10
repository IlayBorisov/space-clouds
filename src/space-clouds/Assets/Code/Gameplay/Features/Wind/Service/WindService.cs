using Code.Gameplay.Features.Wind.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Wind.Service
{
    public class WindService : IWindService
    {
        private readonly WindConfig _config;
        private readonly GameContext _gameContext;

        public float BaseCloudSpeed =>
            _config.BaseCloudSpeed;

        public WindService(GameContext game, WindConfig config)
        {
            _gameContext = game;
            _config = config;
        }

        public Vector2 GetWindDirection()
        {
            var wind = GetWindEntity();
            return wind != null ? wind.WindDirection : Vector2.right;
        }

        public float GetWindForce()
        {
            var wind = GetWindEntity();
            return wind != null ? wind.WindForce : 1f;
        }

        public float GetSpeedMultiplier()
        {
            var wind = GetWindEntity();
            return wind != null ? wind.WindSpeedMultiplier : 1f;
        }

        private GameEntity GetWindEntity() =>
            _gameContext.GetGroup(GameMatcher.WindEntity).GetSingleEntity();
    }
}