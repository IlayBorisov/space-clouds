using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.GameCycle.Systems
{
    public class ClearCloudsOnRestartSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _clouds;
        private readonly List<GameEntity> _buffer = new(1);
        
        public ClearCloudsOnRestartSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.RestartRequest));
            _clouds = game.GetGroup(GameMatcher.Cloud);
        }
        public void Execute()
        {
            foreach (GameEntity hero in _heroes.GetEntities(_buffer))
            {
                foreach (GameEntity cloud in _clouds.GetEntities())
                {
                    if (cloud.hasTransform)
                        Object.Destroy(cloud.Transform.gameObject);
                    cloud.Destroy();
                }
            }
        }
    }
}