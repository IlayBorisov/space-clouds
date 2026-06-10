using Code.Gameplay.Features.Wind.Configs;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Wind.Systems
{
    public class WindTimerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _winds;
        private readonly WindConfig _config;

        public WindTimerSystem(GameContext gameContext, WindConfig config)
        {
            _config = config;
            _winds = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.WindEntity, GameMatcher.WindTimer));
        }
        
        public void Execute()
        {
            foreach (GameEntity wind in _winds)
            {
                wind.ReplaceWindTimer(wind.WindTimer - Time.deltaTime);
            
                if (wind.WindTimer <= 0)
                {
                    wind.ReplaceWindTimer(Random.Range(_config.MinWindDuration, _config.MaxWindDuration));
                    
                    if (Random.value < _config.NoWindChance)
                    {
                        wind.ReplaceWindForce(0f);
                    }
                    else
                    {
                        wind.ReplaceWindForce(Random.Range(_config.MinWindForce, _config.MaxWindForce));
                        wind.ReplaceWindDirection(Random.value > 0.5f ? Vector2.right : Vector2.left);
                    }
                    wind.ReplaceWindSpeedMultiplier(Random.Range(_config.MinCloudSpeedMultiplier, _config.MaxCloudSpeedMultiplier));
                }
            }
        }
    }
}