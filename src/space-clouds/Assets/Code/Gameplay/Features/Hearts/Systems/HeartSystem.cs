using Code.Common;
using Code.Common.Cameras;
using Code.Gameplay.Features.Hearts.Service;
using Entitas;

namespace Code.Gameplay.Features.Hearts.Systems
{
    public class HeartSystem : IExecuteSystem
    {
        private readonly IHeartsService _heartsService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _hero;

        private int _lastScoreThreshold;
        private int _lastScore;
        
        public HeartSystem(GameContext game, IHeartsService heartsService, ICameraProvider cameraProvider)
        {
            _heartsService = heartsService;
            _cameraProvider = cameraProvider;

            _hero = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero,
                GameMatcher.Score, GameMatcher.Health));

        }
        public void Execute()
        {
            foreach (GameEntity hero in _hero)
            {
                int threshold = (hero.Score / 10) * 10;
                
                if (threshold > _lastScoreThreshold && hero.Health < 3)
                {
                    _heartsService.SpawnHeart(SpawnHelper.RandomTopPosition(_cameraProvider));
                    _lastScoreThreshold = threshold;
                }
            }
        }
    }
}