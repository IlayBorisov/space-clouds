using UnityEngine;

namespace Code.Gameplay.Features.Wind.Service
{
    public class WindService : IWindService
    {
        private Vector2 _windDirection;

        private readonly WindConfig _config;

        private float _timer;
        private float _windForce;
        private float _cloudSpeedMultiplier;

        public Vector2 WindDirection => _windDirection;
        public float WindForce => _windForce;
        public float BaseCloudSpeed => _config.BaseCloudSpeed;
        public float CloudSpeedMultiplier => _cloudSpeedMultiplier;

        public WindService(WindConfig config)
        {
            _config = config;
            SwitchWind();
        }

        public void Update(float deltaTime)
        {
            _timer -= deltaTime;
            if (_timer <= 0)
                SwitchWind();
        }

        private void SwitchWind()
        {
            _windForce  = Random.Range(_config.MinWindForce, _config.MaxWindForce);
            _windDirection  = Random.value > 0.5f ? Vector2.right : Vector2.left;
            _timer = Random.Range(_config.MinWindDuration, _config.MaxWindDuration);
            _cloudSpeedMultiplier = Random.Range(_config.MinCloudSpeedMultiplier, _config.MaxCloudSpeedMultiplier);
        }
    }
}