using Entitas;
using UnityEngine;

namespace Code.Gameplay.GameCycle.Systems
{
    public class GamePauseSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pauseRequests;

        public GamePauseSystem(GameContext gameContext)
        {
            _pauseRequests = gameContext.GetGroup(GameMatcher.GamePaused);
        }

        public void Execute()
        {
            Time.timeScale = _pauseRequests.count > 0 ? 0f : 1f;
        }
    }
}